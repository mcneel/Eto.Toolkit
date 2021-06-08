var interop = {};

interop.setFirstNameInWinUI = (firstName) => {
  window.chrome.webview.postMessage(JSON.stringify({
    messageType: 'firstName',
    value: firstName
  }));
};

interop.InitMonaco = () => {
		window.monacoeditor = monaco.editor.create(document.getElementById('container'), {
			value: ['using Rhino.Geometry;', '', 'var p = Point3d(0,0,0);'].join('\n'),
			language: 'csharp'
		});
}
