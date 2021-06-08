//import * as languages from './languages.js';

let ed = {};

//ed.window = {};
//ed.workspace = {};
//
//ed.window.activeTextEditor = () => {
//  return monaco_editor;
//}
//
//ed.workspace.TextEditorOptions = {
//  insertSpaces = () => {
//    const uts = monaco_editor.getOption(monaco.editor.EditorOption.useTabStops);
//    console.log(uts);
//    return uts
//  }
//}

ed.TextEditorOptions_GetInsertSpaces = () => {
  const insertSpaces = monaco_editor_model.getOptions().insertSpaces;
  return insertSpaces;
}

ed.TextEditorOptions_SetInsertSpaces = (insertSpaces) => {
  const o = JSON.parse(`{"insertSpaces": ${insertSpaces}}`);
  monaco_editor_model.updateOptions(o);
}

ed.TextEditorOptions_GetLineNumbers = () => {
  const lns = monaco_editor.getOption(monaco.editor.EditorOption.lineNumbers).renderType;
  return lns;
}
ed.TextEditorOptions_SetLineNumbers = (lns) => {
  const o = JSON.parse(`{"lineNumbers": "${lns}"}`);
  monaco_editor.updateOptions(o);
}

ed.TextEditorOptions_GetTabSize = () => {
  const tabSize = monaco_editor_model.getOptions().tabSize;
  return tabSize;
}

ed.TextEditorOptions_SetTabSize = (tabSize) => {
  const o = JSON.parse(`{"tabSize": "${tabSize}"}`);
  monaco_editor_model.updateOptions(o);
}

ed.layout = () => {
  //const h = document.documentElement.scrollHeight - 20;
  //console.log(`ed.layout(); h:${h}`);
  //monaco_editor.layout({ height: h });
  monaco_editor.layout();
}

ed.doit = () => {
  return JSON.stringify(window.monaco_editor);
}

ed.getTextDocument = () => {
  const m = window.monaco_editor_model;
  console.log(m);
  return {
    text: m.getValue(),
    lineCount: m.getLineCount()
  };
}

//// window.activeTextEditor https://code.visualstudio.com/api/references/vscode-api#window
//ed.window.activeTextEditor.get = () => {
//  // IStandAloneCodeEditor: https://microsoft.github.io/monaco-editor/api/interfaces/monaco.editor.istandalonecodeeditor.html
//  const e = window.activeTextEditor;
//  return {
//    Document: e.getModel()
//  }
//}

//ed.window.TextEditor.document.get = () => {
//  const e = ed.window.activeTextEditor.get();
//  const d = e.getModel();
//  return {
//    Text: d.getValue(),
//    LineCount: d.getLineCount()
//  }
//}

ed.Window_GetColorThemes = () => {
  // there's no official api to get a list of known themes
  return Array.from(monaco_editor._themeService._knownThemes.keys());
}

ed.Window_GetActiveColorTheme = () => {
  // there's no official api to get the current theme name
  return monaco_editor._themeService._theme.themeName;
}

ed.Window_SetActiveColorTheme = (theme) => {
  monaco.editor.setTheme(theme);
}

ed.Languages_GetLanguages = () => {
  // [lep : ILanguageExtensionPoint] (https://microsoft.github.io/monaco-editor/api/interfaces/monaco.languages.ilanguageextensionpoint.html)
  return monaco.languages.getLanguages().map(lep => lep.id);
}

ed.TextDocument_GetLanguageId = () => {
  //const lang = monaco.editor.getModels()[0].getLanguageIdentifier();
  const langIdentifier = monaco_editor_model.getLanguageIdentifier();
  console.log(langIdentifier.language)
  return langIdentifier.language;
}

ed.TextDocument_SetLanguageId = (langId) => {
  monaco.editor.setModelLanguage(monaco.editor.getModels()[0], langId);
}

ed.TextDocument_GetText = () => {
    return window.monaco_editor.getValue();
}

ed.setText = (text) => {
    //from monaco.d.ts:  export type BuiltinTheme = 'vs' | 'vs-dark' | 'hc-black';
    window.monaco_editor.setValue(text);
}

ed.getPositionAtOffset = (offset) => {
  return monaco.editor.getModels()[0].getPositionAt(offset);
}

ed.getCharacterBeforePosition = (model, position) => {
  if (position.column == 1) return '';
  return model.getValueInRange({
    startLineNumber: position.lineNumber,
    endLineNumber: position.lineNumber,
    startColumn: position.column - 1,
    endColumn: position.column
  });
}

ed.HookupCompletionProvider = () => {
  //function createDependencyProposals(text, range) {
  //    // returning a static list of proposals, not even looking at the prefix (filtering is done by the Monaco editor),
  //    // here you could do a server side lookup
  //    return [
  //        {
  //            label: text,
  //            kind: monaco.languages.CompletionItemKind.Function,
  //            documentation: "The Lodash library exported as Node.js modules.",
  //            insertText: '"lodash": "*"',
  //            range: range
  //        },
  //        {
  //            label: '"express"',
  //            kind: monaco.languages.CompletionItemKind.Function,
  //            documentation: "Fast, unopinionated, minimalist web framework",
  //            insertText: '"express": "*"',
  //            range: range
  //        },
  //        {
  //            label: '"mkdirp"',
  //            kind: monaco.languages.CompletionItemKind.Function,
  //            documentation: "Recursively mkdir, like <code>mkdir -p</code>",
  //            insertText: '"mkdirp": "*"',
  //            range: range
  //        },
  //        {
  //            label: '"my-third-party-library"',
  //            kind: monaco.languages.CompletionItemKind.Function,
  //            documentation: "Describe your library here",
  //            insertText: '"${1:my-third-party-library}": "${2:1.2.3}"',
  //            insertTextRules: monaco.languages.CompletionItemInsertTextRule.InsertAsSnippet,
  //            range: range
  //        }
  //    ];
  //}
  //function createSuggestions(text, range) {
  //    // returning a static list of proposals, not even looking at the prefix (filtering is done by the Monaco editor),
  //    // here you could do a server side lookup
  //    return [
  //        {
  //            label: text,
  //            kind: monaco.languages.CompletionItemKind.Function,
  //            documentation: "The Lodash library exported as Node.js modules.",
  //            insertText: '"lodash": "*"',
  //            range: range
  //        },
  //        {
  //            label: '"express"',
  //            kind: monaco.languages.CompletionItemKind.Function,
  //            documentation: "Fast, unopinionated, minimalist web framework",
  //            insertText: '"express": "*"',
  //            range: range
  //        }
  //    ];
  //}
  monaco.languages.registerCompletionItemProvider('csharp', {
    triggerCharacters: ['.', ' ', '('],
    provideCompletionItems: function(model, position) {
      var textUntilPosition = model.getValueInRange({startLineNumber: 1, startColumn: 1, endLineNumber: position.lineNumber, endColumn: position.column});
      var charAdded = ed.getCharacterBeforePosition(model, position);
      var triggers = ['.', '(', ' '];
      if (!triggers.includes(charAdded)) return { suggestions: [] };
      var range = {
        startLineNumber: position.lineNumber,
        endLineNumber: position.lineNumber,
        startColumn: position.column,
        endColumn: position.column
      };
      var offset = model.getOffsetAt(position);
      var completionsRequest = {
        code: textUntilPosition,
        position: offset,
        ch: charAdded
      };
      var completionsString = window.chrome.webview.hostObjects.sync.csCompletions.GetCompletions(JSON.stringify(completionsRequest));
      var completionsObj = JSON.parse(completionsString);
      var completionsArray = completionsObj.Result;
      var sugg = completionsArray.map(c => ({
        label: c,
        kind: monaco.languages.CompletionItemKind.Method,
        insertText: c
      }));
      //var sugg = createDependencyProposals(compmletionsString, range);
      //var sugg = createSuggestions(x, range);
      return {
        suggestions: sugg
      }
    }
  });
}