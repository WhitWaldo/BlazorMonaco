﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorMonaco
{
    public partial class MonacoEditor : MonacoEditorBase
    {
        [Parameter]
        public Func<MonacoEditor, StandaloneEditorConstructionOptions> ConstructionOptions { get; set; }

        [Parameter]
        public EventCallback<MonacoEditor> OnDidCompositionEnd { get; set; }

        [Parameter]
        public EventCallback<MonacoEditor> OnDidCompositionStart { get; set; }

        [Parameter]
        public EventCallback<EditorMouseEvent> OnContextMenu { get; set; }

        // onDidAttemptReadOnlyEdit(listener: () => void) : IDisposable;
        [Parameter]
        public EventCallback<MonacoEditor> OnDidBlurEditorText { get; set; }

        [Parameter]
        public EventCallback<MonacoEditor> OnDidBlurEditorWidget { get; set; }

        [Parameter]
        public EventCallback<MonacoEditor> OnDidChangeConfiguration { get; set; }

        [Parameter]
        public EventCallback<CursorPositionChangedEvent> OnDidChangeCursorPosition { get; set; }

        [Parameter]
        public EventCallback<CursorSelectionChangedEvent> OnDidChangeCursorSelection { get; set; }

        [Parameter]
        public EventCallback<ModelChangedEvent> OnDidChangeModel { get; set; }

        [Parameter]
        public EventCallback<ModelContentChangedEvent> OnDidChangeModelContent { get; set; }

        [Parameter]
        public EventCallback<ModelDecorationsChangedEvent> OnDidChangeModelDecorations { get; set; }

        [Parameter]
        public EventCallback<ModelLanguageChangedEvent> OnDidChangeModelLanguage { get; set; }

        [Parameter]
        public EventCallback<ModelLanguageConfigurationChangedEvent> OnDidChangeModelLanguageConfiguration { get; set; }

        [Parameter]
        public EventCallback<ModelOptionsChangedEvent> OnDidChangeModelOptions { get; set; }

        [Parameter]
        public EventCallback<ContentSizeChangedEvent> OnDidContentSizeChange { get; set; }

        [Parameter]
        public EventCallback<MonacoEditor> OnDidFocusEditorText { get; set; }

        [Parameter]
        public EventCallback<MonacoEditor> OnDidFocusEditorWidget { get; set; }

        [Parameter]
        public EventCallback<EditorLayoutInfo> OnDidLayoutChange { get; set; }

        [Parameter]
        public EventCallback<PasteEvent> OnDidPaste { get; set; }

        [Parameter]
        public EventCallback<ScrollEvent> OnDidScrollChange { get; set; }

        [Parameter]
        public EventCallback<KeyboardEvent> OnKeyDown { get; set; }

        [Parameter]
        public EventCallback<KeyboardEvent> OnKeyUp { get; set; }

        [Parameter]
        public EventCallback<EditorMouseEvent> OnMouseDown { get; set; }

        [Parameter]
        public EventCallback<EditorMouseEvent> OnMouseLeave { get; set; }

        [Parameter]
        public EventCallback<EditorMouseEvent> OnMouseMove { get; set; }

        [Parameter]
        public EventCallback<EditorMouseEvent> OnMouseUp { get; set; }

        private List<string> deltaDecorationIds { get; set; } = new List<string>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Get options
                var options = ConstructionOptions?.Invoke(this);

                // Prepare the line numbers callback
                LineNumbersLambda = options.LineNumbersLambda;
                if (LineNumbersLambda != null)
                {
                    options.LineNumbers = "function";
                    options.LineNumbersLambda = null;
                }

                // Create the editor
                await MonacoEditorBase.Create(Id, options, jsObjectRef);
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        internal override async Task SetEventListeners()
        {
            if (OnDidCompositionEnd.HasDelegate)
                await SetEventListener("OnDidCompositionEnd");
            if (OnDidCompositionStart.HasDelegate)
                await SetEventListener("OnDidCompositionStart");
            if (OnContextMenu.HasDelegate)
                await SetEventListener("OnContextMenu");
            if (OnDidBlurEditorText.HasDelegate)
                await SetEventListener("OnDidBlurEditorText");
            if (OnDidBlurEditorWidget.HasDelegate)
                await SetEventListener("OnDidBlurEditorWidget");
            if (OnDidChangeConfiguration.HasDelegate)
                await SetEventListener("OnDidChangeConfiguration");
            if (OnDidChangeCursorPosition.HasDelegate)
                await SetEventListener("OnDidChangeCursorPosition");
            if (OnDidChangeCursorSelection.HasDelegate)
                await SetEventListener("OnDidChangeCursorSelection");
            if (OnDidChangeModel.HasDelegate)
                await SetEventListener("OnDidChangeModel");
            if (OnDidChangeModelContent.HasDelegate)
                await SetEventListener("OnDidChangeModelContent");
            if (OnDidChangeModelDecorations.HasDelegate)
                await SetEventListener("OnDidChangeModelDecorations");
            if (OnDidChangeModelLanguage.HasDelegate)
                await SetEventListener("OnDidChangeModelLanguage");
            if (OnDidChangeModelLanguageConfiguration.HasDelegate)
                await SetEventListener("OnDidChangeModelLanguageConfiguration");
            if (OnDidChangeModelOptions.HasDelegate)
                await SetEventListener("OnDidChangeModelOptions");
            if (OnDidContentSizeChange.HasDelegate)
                await SetEventListener("OnDidContentSizeChange");
            if (OnDidFocusEditorText.HasDelegate)
                await SetEventListener("OnDidFocusEditorText");
            if (OnDidFocusEditorWidget.HasDelegate)
                await SetEventListener("OnDidFocusEditorWidget");
            if (OnDidLayoutChange.HasDelegate)
                await SetEventListener("OnDidLayoutChange");
            if (OnDidPaste.HasDelegate)
                await SetEventListener("OnDidPaste");
            if (OnDidScrollChange.HasDelegate)
                await SetEventListener("OnDidScrollChange");
            if (OnKeyDown.HasDelegate)
                await SetEventListener("OnKeyDown");
            if (OnKeyUp.HasDelegate)
                await SetEventListener("OnKeyUp");
            if (OnMouseDown.HasDelegate)
                await SetEventListener("OnMouseDown");
            if (OnMouseLeave.HasDelegate)
                await SetEventListener("OnMouseLeave");
            if (OnMouseMove.HasDelegate)
                await SetEventListener("OnMouseMove");
            if (OnMouseUp.HasDelegate)
                await SetEventListener("OnMouseUp");
            await base.SetEventListeners();
        }

        [JSInvokable]
        public override async Task EventCallback(string eventName, string eventJson)
        {
            var jsonOptions = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            switch (eventName)
            {
                case "OnDidCompositionEnd":
                    await OnDidCompositionEnd.InvokeAsync(this);
                    break;
                case "OnDidCompositionStart":
                    await OnDidCompositionStart.InvokeAsync(this);
                    break;
                case "OnContextMenu":
                    if (eventJson != null)
                        await OnContextMenu.InvokeAsync(
                            JsonSerializer.Deserialize<EditorMouseEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidBlurEditorText":
                    await OnDidBlurEditorText.InvokeAsync(this);
                    break;
                case "OnDidBlurEditorWidget":
                    await OnDidBlurEditorWidget.InvokeAsync(this);
                    break;
                case "OnDidChangeConfiguration":
                    await OnDidChangeConfiguration.InvokeAsync(this);
                    break;
                case "OnDidChangeCursorPosition":
                    await OnDidChangeCursorPosition.InvokeAsync(
                        JsonSerializer.Deserialize<CursorPositionChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeCursorSelection":
                    await OnDidChangeCursorSelection.InvokeAsync(
                        JsonSerializer.Deserialize<CursorSelectionChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeModel":
                    await OnDidChangeModel.InvokeAsync(
                        JsonSerializer.Deserialize<ModelChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeModelContent":
                    await OnDidChangeModelContent.InvokeAsync(
                        JsonSerializer.Deserialize<ModelContentChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeModelDecorations":
                    await OnDidChangeModelDecorations.InvokeAsync(
                        JsonSerializer.Deserialize<ModelDecorationsChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeModelLanguage":
                    await OnDidChangeModelLanguage.InvokeAsync(
                        JsonSerializer.Deserialize<ModelLanguageChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeModelLanguageConfiguration":
                    await OnDidChangeModelLanguageConfiguration.InvokeAsync(
                        JsonSerializer.Deserialize<ModelLanguageConfigurationChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidChangeModelOptions":
                    await OnDidChangeModelOptions.InvokeAsync(
                        JsonSerializer.Deserialize<ModelOptionsChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidContentSizeChange":
                    await OnDidContentSizeChange.InvokeAsync(
                        JsonSerializer.Deserialize<ContentSizeChangedEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidFocusEditorText":
                    await OnDidFocusEditorText.InvokeAsync(this);
                    break;
                case "OnDidFocusEditorWidget":
                    await OnDidFocusEditorWidget.InvokeAsync(this);
                    break;
                case "OnDidLayoutChange":
                    if (eventJson != null)
                        await OnDidLayoutChange.InvokeAsync(
                            JsonSerializer.Deserialize<EditorLayoutInfo>(eventJson, jsonOptions));
                    break;
                case "OnDidPaste":
                    if (eventJson != null)
                        await OnDidPaste.InvokeAsync(JsonSerializer.Deserialize<PasteEvent>(eventJson, jsonOptions));
                    break;
                case "OnDidScrollChange":
                    if (eventJson != null)
                        await OnDidScrollChange.InvokeAsync(
                            JsonSerializer.Deserialize<ScrollEvent>(eventJson, jsonOptions));
                    break;
                case "OnKeyDown":
                    if (eventJson != null)
                        await OnKeyDown.InvokeAsync(JsonSerializer.Deserialize<KeyboardEvent>(eventJson, jsonOptions));
                    break;
                case "OnKeyUp":
                    if (eventJson != null)
                        await OnKeyUp.InvokeAsync(JsonSerializer.Deserialize<KeyboardEvent>(eventJson, jsonOptions));
                    break;
                case "OnMouseDown":
                    if (eventJson != null)
                        await OnMouseDown.InvokeAsync(
                            JsonSerializer.Deserialize<EditorMouseEvent>(eventJson, jsonOptions));
                    break;
                case "OnMouseLeave":
                    if (eventJson != null)
                        await OnMouseLeave.InvokeAsync(
                            JsonSerializer.Deserialize<EditorMouseEvent>(eventJson, jsonOptions));
                    break;
                case "OnMouseMove":
                    if (eventJson != null)
                        await OnMouseMove.InvokeAsync(
                            JsonSerializer.Deserialize<EditorMouseEvent>(eventJson, jsonOptions));
                    break;
                case "OnMouseUp":
                    if (eventJson != null)
                        await OnMouseUp.InvokeAsync(
                            JsonSerializer.Deserialize<EditorMouseEvent>(eventJson, jsonOptions));
                    break;
            }

            await base.EventCallback(eventName, eventJson);
        }

        public static MonacoEditor CreateVirtualEditor(string id, string cssClass = null)
        {
            var virtual_editor = new MonacoEditor();
            virtual_editor.Id = id;
            virtual_editor.CssClass = cssClass;
            virtual_editor.jsRuntime = staticJsRuntime;
            virtual_editor.jsObjectRef = DotNetObjectReference.Create(virtual_editor as MonacoEditorBase);
            return virtual_editor;
        }

        #region Instance Methods

        // addContentWidget

        // addOverlayWidget

        // applyFontInfo

        // changeViewZones

        public async Task<string[]> DeltaDecorations(string[] oldDecorationIds, ModelDeltaDecoration[] newDecorations)
        {
            if (jsRuntime == null)
                return default;

            if (oldDecorationIds == null)
                oldDecorationIds = new string[] { };

            // Convert the newDecorations object into a JsonElement to get rid of the properties with null values
            var newDecorationsJson = JsonSerializer.Serialize(newDecorations, new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var newDecorationsElement = JsonSerializer.Deserialize<JsonElement>(newDecorationsJson);
            var newDecorationIds = await jsRuntime.InvokeAsync<string[]>("blazorMonaco.editor.deltaDecorations", Id,
                oldDecorationIds, newDecorationsElement);
            deltaDecorationIds.RemoveAll(d => oldDecorationIds.Any(o => o == d));
            deltaDecorationIds.AddRange(newDecorationIds);
            return newDecorationIds;
        }

        // executeCommand

        // executeCommands

        public async Task<bool> ExecuteEdits(string source, List<IdentifiedSingleEditOperation> edits,
            List<Selection> endCursorState)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<bool>("blazorMonaco.editor.executeEdits", Id, source, edits,
                endCursorState);
        }

        public async Task<bool> ExecuteEdits(string source, List<IdentifiedSingleEditOperation> edits,
            Func<List<ValidEditOperation>, List<Selection>> endCursorState)
        {
            if (jsRuntime == null)
                return default;
            ExecuteEditsLambda = endCursorState;
            return await jsRuntime.InvokeAsync<bool>("blazorMonaco.editor.executeEdits", Id, source, edits, "function");
        }

        private Func<List<ValidEditOperation>, List<Selection>> ExecuteEditsLambda { get; set; }

        [JSInvokable]
        public List<Selection> ExecuteEditsCallback(List<ValidEditOperation> inverseEditOperations)
        {
            Console.WriteLine("ExecuteEditsCallback is called : " + JsonSerializer.Serialize(inverseEditOperations));
            return ExecuteEditsLambda?.Invoke(inverseEditOperations);
        }

        // getAction

        public async Task<string> GetContainerDomNodeId()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<string>("blazorMonaco.editor.getContainerDomNodeId", Id);
        }

        public async Task<double> GetContentHeight()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getContentHeight", Id);
        }

        public async Task<double> GetContentWidth()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getContentWidth", Id);
        }

        // getContribution

        public async Task<EditorLayoutInfo> GetLayoutInfo()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<EditorLayoutInfo>("blazorMonaco.editor.getLayoutInfo", Id);
        }

        // getLineDecorations

        public async Task<TextModel> GetModel()
        {
            if (jsRuntime == null)
                return default;
            var model = await jsRuntime.InvokeAsync<TextModel>("blazorMonaco.editor.getInstanceModel", Id);
            if (model != null)
                model.jsRuntime = jsRuntime;
            return model;
        }

        public async Task<int> GetOffsetForColumn(int lineNumber, int column)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<int>("blazorMonaco.editor.getOffsetForColumn", Id, lineNumber, column);
        }

        public async Task<string> GetOption(EditorOption option)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<string>("blazorMonaco.editor.getOption", Id, (int) option);
        }

        public async Task<List<string>> GetOptions()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<List<string>>("blazorMonaco.editor.getOptions", Id);
        }

        public async Task<EditorOptions> GetRawOptions()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<EditorOptions>("blazorMonaco.editor.getRawOptions", Id);
        }

        public async Task<double> GetScrollHeight()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getScrollHeight", Id);
        }

        public async Task<double> GetScrollLeft()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getScrollLeft", Id);
        }

        public async Task<double> GetScrollTop()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getScrollTop", Id);
        }

        public async Task<double> GetScrollWidth()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getScrollWidth", Id);
        }

        public async Task<Position> GetScrolledVisiblePosition(Position position)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<Position>("blazorMonaco.editor.getScrolledVisiblePosition", Id,
                position);
        }

        public async Task<MouseTarget> GetTargetAtClientPoint(int clientX, int clientY)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<MouseTarget>("blazorMonaco.editor.getTargetAtClientPoint", Id, clientX,
                clientY);
        }

        public async Task<double> GetTopForLineNumber(int lineNumber)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getTopForLineNumber", Id, lineNumber);
        }

        public async Task<double> GetTopForPosition(int lineNumber, int column)
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<double>("blazorMonaco.editor.getTopForPosition", Id, lineNumber, column);
        }

        public async Task<string> GetValue()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<string>("blazorMonaco.editor.getValue", Id);
        }

        public async Task<List<Range>> GetVisibleRanges()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<List<Range>>("blazorMonaco.editor.getVisibleRanges", Id);
        }

        public async Task<bool> HasWidgetFocus()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<bool>("blazorMonaco.editor.hasWidgetFocus", Id);
        }

        // layoutContentWidget

        // layoutOverlayWidget

        // popUndoStop(): boolean;

        public async Task<bool> PushUndoStop()
        {
            if (jsRuntime == null)
                return default;
            return await jsRuntime.InvokeAsync<bool>("blazorMonaco.editor.pushUndoStop", Id);
        }

        // removeContentWidget

        // removeOverlayWidget

        public async Task Render(bool? forceRedraw = null)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.render", Id, forceRedraw);
        }

        public async Task ResetDeltaDecorations()
        {
            if (jsRuntime == null)
                return;
            await DeltaDecorations(deltaDecorationIds.ToArray(), new ModelDeltaDecoration[0]);
        }

        // restoreViewState

        // saveViewState

        public async Task SetModel(TextModel model)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.setInstanceModel", Id, model.Uri);
        }
        
        public async Task SetScrollLeft(int newScrollLeft, ScrollType? scrollType = null)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.setScrollLeft", Id, newScrollLeft, scrollType);
        }

        public async Task SetScrollPosition(int newScrollLeft, int newScrollTop, ScrollType? scrollType = null)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.setScrollPosition", Id, newScrollLeft, newScrollTop,
                scrollType);
        }

        public async Task SetScrollTop(int newScrollTop, ScrollType? scrollType = null)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.setScrollTop", Id, newScrollTop, scrollType);
        }

        public async Task SetValue(string newValue)
        {
            if (jsRuntime == null)
                return;
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.setValue", Id, newValue);
        }

        public async Task UpdateOptions(GlobalEditorOptions options)
        {
            if (jsRuntime == null)
                return;

            // Convert the options object into a JsonElement to get rid of the properties with null values
            var optionsJson = JsonSerializer.Serialize(options, new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            var optionsDict = JsonSerializer.Deserialize<JsonElement>(optionsJson);
            await jsRuntime.InvokeVoidAsync("blazorMonaco.editor.updateOptions", Id, optionsDict);
        }

        #endregion
    }
}
