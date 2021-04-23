function Apply-ImportCorrection {
		param (
			[string]$file,
			[string]$target,
			[string]$update,
			[int]$iteration = 1
		)
		Write-Host "Applying import fix #$($iteration)"
		$orig = Get-Content $file
		[String[]] $fileModified = @()
		Foreach($line in $orig)
		{
			if ($line.Trim() -like $target) {
				$fileModified += $update
			} else {
				$fileModified += $line
			}
		}
		Set-Content $file $fileModified
}

# Clone the monaco-editor
git clone https://github.com/microsoft/monaco-editor.git;

# Start by building YAML into the monaco-editor project
cd monaco-editor

# Add the monaco-yaml package, then install everything
npm add monaco-yaml
npm i

# Update metadata.js to add the yaml language
$fileName = "./metadata.js"
$fileOrig = Get-Content $fileName

[String[]] $fileModified = @()
Foreach($line in $fileOrig)
{
    $fileModified += $line
    if ($line.Trim() -match "PLUGINS: \[")
    {
        #Add these lines after the selected pattern
        $fileModified += "{name: 'monaco-yaml', contrib: 'vs/language/yaml/monaco.contribution', modulePrefix: 'vs/language/yaml', 'paths': {src: '/monaco-yaml/lib/dev', 'npm/dev': 'node_modules/monaco-yaml/lib/dev', 'npm/min': 'node_modules/monaco-yaml/lib/min', esm: 'node_modules/monaco-yaml/lib/esm'}},"
    }
}
Set-Content $fileName $fileModified

# Register the YAML worker in the exports
$fileName = "./ci/webpack.config.js"
$fileOrig = Get-Content $fileName
[String[]] $fileModified = @()
$e = 0
Foreach($line in $fileOrig)
{
    if ($line.Trim() -match "entry: \{") {
        $e = 1
    }
    if ($e -eq 1 -and $line.Trim() -match "\}\,")
    {
        $fileModified += "`t`t`"yaml.worker`": 'monaco-yaml/esm/yaml.worker'"
        $e = 0
    }
    $fileModified += $line
}
Set-Content $fileName $fileModified

#Fix #1
#npm run release
#Error: Non-relative import for unknown module: monaco-editor/esm/vs/editor/editor.worker in \monaco-editor\node_modules\monaco-yaml\esm\yaml.worker.js
Apply-ImportCorrection -file "./node_modules/monaco-yaml/lib/esm/yaml.worker.js" -target "import * as worker from 'monaco-editor/esm/vs/editor/editor.worker';" -update "import * as worker from 'monaco-editor-core/esm/vs/editor/editor.worker';" -iteration 1

#Fix #2
#npm run release
#Error: Non-relative import for unknown module: js-yaml in J:\Code\monaco\monaco-editor\node_modules\monaco-yaml\lib\esm\_deps\yaml-language-server\lib\esm\languageservice\services\yamlSchemaService.js
Apply-ImportCorrection -file "./node_modules/monaco-yaml/lib/esm/_deps/yaml-language-server/lib/esm/languageservice/services/yamlSchemaService.js" -target "import * as yaml from 'js-yaml';" -update "import * as yaml from '../../../../../../../../../js-yaml';" -iteration 2

#Fix #3
#npm run release
#Error: Non-relative import for unknown module: yaml-ast-parser-custom-tags in J:\Code\monaco\monaco-editor\node_modules\monaco-yaml\lib\esm\_deps\yaml-language-server\lib\esm\languageservice\parser\recursivelyBuildAst.js
Apply-ImportCorrection -file "./node_modules/monaco-yaml/lib/esm/_deps/yaml-language-server/lib/esm/languageservice/parser/recursivelyBuildAst.js" -target "import * as Yaml from 'yaml-ast-parser-custom-tags';" -update "import * as Yaml from '../../../../../../../../yaml-ast-parser-custom-tags';" -iteration 3

#Fix #4
#npm run release
#Error: Non-relative import for unknown module: yaml-ast-parser-custom-tags in J:\Code\monaco\monaco-editor\node_modules\monaco-yaml\lib\esm\_deps\yaml-language-server\lib\esm\languageservice\parser\yamlParser07.js
Apply-ImportCorrection -file "./node_modules/monaco-yaml/lib/esm/_deps/yaml-language-server/lib/esm/languageservice/parser/yamlParser07.js" -target "import * as Yaml from 'yaml-ast-parser-custom-tags';" -update "import * as Yaml from '../../../../../../../../yaml-ast-parser-custom-tags';" -iteration 4

#Fix #5
#npm run release
#Error: Non-relative import for unknown module: js-yaml in J:\Code\monaco\monaco-editor\node_modules\monaco-yaml\lib\esm\_deps\yaml-language-server\lib\esm\languageservice\utils\parseUtils.js
Apply-ImportCorrection -file "./node_modules/monaco-yaml/lib/esm/_deps/yaml-language-server/lib/esm/languageservice/utils/parseUtils.js" -target "import { Schema, Type } from 'js-yaml';" -update "import { Schema, Type } from '../../../../../../../../js-yaml';" -iteration 5

#Build the release
npm run release

# Clone the BlazorMonaco project
cd ..
git clone https://github.com/WhitWaldo/BlazorMonaco.git

#Ok, now copy everything from /release into BlazorMonaco
cd BlazorMonaco

# Remove the existing monaco editor output from BlazorMonaco
$monacoDestPath = "./BlazorMonaco/wwwroot/lib/monaco-editor"
rm -R $monacoDestPath

# Copy the releases from monaco-editor into the dest path
$monacoSrcPath1 = "../monaco-editor/release/min"
$monacoSrcPath2 = "../monaco-editor/release/min-maps"

Copy-Item -Path $monacoSrcPath1 -Destination "$monacoDestPath/min" -Recurse
Copy-Item -Path $monacoSrcPath2 -Destination "$monacoDestPath/min-maps" -Recurse
Write-Host "Successfully copied updated monaco-editor into BlazorMonaco project"

# Update editor.main.js to delay loading the yaml editor until monaco has loaded
Write-Host "Updating editor.main.js to delay loading the yaml editor until monaco has loaded"
$block1=@'
function wait(timeout) {
	return new Promise(resolve => {
		setTimeout(resolve, timeout);
	});
}

async function loadYamlWhenMonacoKnown() {
'@
$block2=@'
	console.log("Waiting on monaco...")
	var monacoDefined = false;
	while (!monacoDefined) {
		try {
			monaco;
			monacoDefined = true;
			console.log("monaco loaded...");
		} catch(e) {
			//Wait 0.1 seconds
			console.log("waiting...");
		}
		await wait(100);
	}
'@
$block3=@'
}
loadYamlWhenMonacoKnown();
'@
$lineList = New-Object Collections.Generic.List[String]
$flag = 0 #Comments
$flag2 = 0 #Logic
$flag3 = 0 #Flags whether comments and logic are done collecting
$commentLines = New-Object Collections.Generic.List[String]
$logicLines = ""

$file = "./BlazorMonaco/wwwroot/lib/monaco-editor/min/vs/editor/editor.main.js"
$orig = Get-Content $file
[String[]] $fileModified = @()
# Capture out each of the comment and logic blocks
Foreach($line in $orig)
{
	# Maintain the pre-buffer until flag3 is set
	If ($flag3 -eq 0) {
		If ($lineList.Count -eq 3) 
		{
			# Move 1 into 0, 2 into 1, remove index 2, add the line to the end
			$lineList[0] = $lineList[1]
			$lineList[1] = $lineList[2]
			$lineList.RemoveAt(2)
			$lineList.Add($line)
		} else {
			# Add indiscriminately
			$lineList.Add($line)
		}
	}
		
	if ($line.Trim().StartsWith("* monaco-yaml version:")) {
		# Dump the lineList into $commentLines
		Foreach($l in $lineList) {
			$commentLines.Add($l)
		}
		
		# Set the comments capture flag
		$flag = 1
	} elseif ($flag -eq 1) {
		# We're capturing the comment lines since we've had a flag on the monaco-yaml line
		If ($line.Trim().StartsWith("*--------")) {
			# Last comment capture line
			$commentLines.Add($line)
			$flag = 0
			
			#Set the flag2 to capture the logic
			$flag2 = 1
		} else {
			$commentLines.Add($line)
		}
	} elseif ($flag2 -eq 1) {
		# We're capturing the logic line here with flag2
		$logicLines = $line
		$flag2 = 0
		$flag3 = 1
	} else {
		$fileModified += $line
	}
}

# At the bottom of the file, write out all the blocks
$fileModified += $block1
Foreach($l in $commentLines) {
	$fileModified += $l
}
$fileModified += $block2
$fileModified += $logicLines
$fileModified += $block3

Set-Content $file $fileModified
Write-Host "`tUpdated"