using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;
using System.Html.IO;
using jQueryApi;

namespace Cayita.Javascript
{
	[IgnoreNamespace]
	public class DemoFileUpload
	{
		public DemoFileUpload (){}

		public static void Execute(Element parent)
		{
			"File upload".Header (3).AppendTo (parent);

			var logFu = new Div ();
			var fu= new FileUpload();
			var bFu = CreateUploadButton (fu);
			CreatePanel (parent, logFu, fu, bFu);
			fu.FileSelected += u => OnFileSelected (logFu, fu, bFu);

			//------------------------------------------------------
			"Image upload".Header (3).AppendTo (parent);
			var iu= new ImgUpload();
			var logIm = new Div ();
			var bIm= CreateUploadButton (iu);
			CreatePanel (parent, logIm, iu, bIm);
			iu.FileSelected += u => OnFileSelected (logIm, iu, bIm);

			ShowCode (parent);

		}

		static void OnFileSelected<T> (Div logDiv, FileUpload<T> fileupload, Button bUpload) where T: ElementBase
		{
			bUpload.Disable (fileupload.Input.Files.Count == 0);
			ShowFileInfo (fileupload.Input.Files, logDiv);
		}

		static Button CreateUploadButton<T> (FileUpload<T> fu) where T: ElementBase
		{
			var bFu = new Button ().AddClass ("btn-info").IconClass ("icon-upload")
				.Text ("Upload").Disable (true).LoadingText ("uploading");
			bFu.Clicked += (b, ev) => SendFile (b, ev, fu.Input);
			return bFu;
		}
		
		static void CreatePanel<T> (Element parent, Div logFu, FileUpload<T> fu, Button bFu) where T: ElementBase
		{
			new Div ().ClassName ("bs-docs-example").Append (fu).Append (bFu).Append (logFu).AppendTo (parent);
		}

		static void ShowFileInfo ( IList<File> files, Div log)
		{
			log.Empty ();
			if(files.Count==0) return ;
			var file = files[0]; 
			log.Append (string.Format("Name:{0}<br>Size:{1}<br>Type:{2}<br>LastModifiedDate:{3}",
			                          file.Name,
			                          file.Size,
			                          file.Type,
			                          file.LastModifiedDate.Format("dd-MM-yyyy HH:mm:ss")));
		}
		
		static void SendFile (Button b, jQueryEvent ev, FileElement input)
		{
			b.ShowLoadingText ();
			var fd = new FormData ();
			fd.Append ("userfile", input.Files [0]);
			
			var rq = fd.Send ("SaveFile");
			rq.Done (() => "File Uploaded".LogSuccess (5000));
			rq.Fail (() => rq.GetError ().StatusText.LogError ());
			rq.Always (() => b.ResetLoadingText ());
			
		}

		static void ShowCode(Element parent)
		{
			parent.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;Execute(Element&nbsp;parent)&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""File&nbsp;upload""</span><span>.Header&nbsp;(3).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;logFu&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;();&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fu=&nbsp;<span class=""keyword"">new</span><span>&nbsp;FileUpload();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bFu&nbsp;=&nbsp;CreateUploadButton&nbsp;(fu);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;CreatePanel&nbsp;(parent,&nbsp;logFu,&nbsp;fu,&nbsp;bFu);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;fu.FileSelected&nbsp;+=&nbsp;u&nbsp;=&gt;&nbsp;OnFileSelected&nbsp;(logFu,&nbsp;fu,&nbsp;bFu);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""comment"">//------------------------------------------------------</span><span>&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""Image&nbsp;upload""</span><span>.Header&nbsp;(3).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;iu=&nbsp;<span class=""keyword"">new</span><span>&nbsp;ImgUpload();&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;logIm&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bIm=&nbsp;CreateUploadButton&nbsp;(iu);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;CreatePanel&nbsp;(parent,&nbsp;logIm,&nbsp;iu,&nbsp;bIm);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;iu.FileSelected&nbsp;+=&nbsp;u&nbsp;=&gt;&nbsp;OnFileSelected&nbsp;(logIm,&nbsp;iu,&nbsp;bIm);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;OnFileSelected&lt;T&gt;&nbsp;(Div&nbsp;logDiv,&nbsp;FileUpload&lt;T&gt;&nbsp;fileupload,&nbsp;Button&nbsp;bUpload)&nbsp;where&nbsp;T:&nbsp;ElementBase&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bUpload.Disable&nbsp;(fileupload.Input.Files.Count&nbsp;==&nbsp;0);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;ShowFileInfo&nbsp;(fileupload.Input.Files,&nbsp;logDiv);&nbsp;&nbsp;</span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">static</span><span>&nbsp;Button&nbsp;CreateUploadButton&lt;T&gt;&nbsp;(FileUpload&lt;T&gt;&nbsp;fu)&nbsp;where&nbsp;T:&nbsp;ElementBase&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;bFu&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;Button&nbsp;().AddClass&nbsp;(</span><span class=""string"">""btn-info""</span><span>).IconClass&nbsp;(</span><span class=""string"">""icon-upload""</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Text&nbsp;(<span class=""string"">""Upload""</span><span>).Disable&nbsp;(</span><span class=""keyword"">true</span><span>).LoadingText&nbsp;(</span><span class=""string"">""uploading""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;bFu.Clicked&nbsp;+=&nbsp;(b,&nbsp;ev)&nbsp;=&gt;&nbsp;SendFile&nbsp;(b,&nbsp;ev,&nbsp;fu.Input);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;bFu;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;CreatePanel&lt;T&gt;&nbsp;(Element&nbsp;parent,&nbsp;Div&nbsp;logFu,&nbsp;FileUpload&lt;T&gt;&nbsp;fu,&nbsp;Button&nbsp;bFu)&nbsp;where&nbsp;T:&nbsp;ElementBase&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;().ClassName&nbsp;(</span><span class=""string"">""bs-docs-example""</span><span>).Append&nbsp;(fu).Append&nbsp;(bFu).Append&nbsp;(logFu).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""""><span>}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;ShowFileInfo&nbsp;(&nbsp;IList&lt;File&gt;&nbsp;files,&nbsp;Div&nbsp;log)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;log.Empty&nbsp;();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">if</span><span>(files.Count==0)&nbsp;</span><span class=""keyword"">return</span><span>&nbsp;;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;file&nbsp;=&nbsp;files[0];&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;log.Append&nbsp;(string.Format(""Name:{0}&nbsp;&nbsp;</span></li><li class=""""><span>Size:{1}&nbsp;&nbsp;</span></li><li class=""alt""><span>Type:{2}&nbsp;&nbsp;</span></li><li class=""""><span>LastModifiedDate:{3}"",&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.Name,&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.Size,&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.Type,&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.LastModifiedDate.Format(<span class=""string"">""dd-MM-yyyy&nbsp;HH:mm:ss""</span><span>)));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;SendFile&nbsp;(Button&nbsp;b,&nbsp;jQueryEvent&nbsp;ev,&nbsp;FileElement&nbsp;input)&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;b.ShowLoadingText&nbsp;();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;fd&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;FormData&nbsp;();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;fd.Append&nbsp;(<span class=""string"">""userfile""</span><span>,&nbsp;input.Files&nbsp;[0]);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;rq&nbsp;=&nbsp;fd.Send&nbsp;(<span class=""string"">""SaveFile""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;rq.Done&nbsp;(()&nbsp;=&gt;&nbsp;<span class=""string"">""File&nbsp;Uploaded""</span><span>.LogSuccess&nbsp;(5000));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;rq.Fail&nbsp;(()&nbsp;=&gt;&nbsp;rq.GetError&nbsp;().StatusText.LogError&nbsp;());&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;rq.Always&nbsp;(()&nbsp;=&gt;&nbsp;b.ResetLoadingText&nbsp;());&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">public static void Execute(Element parent)
{
	""File upload"".Header (3).AppendTo (parent);
	
	var logFu = new Div ();
	var fu= new FileUpload();
	var bFu = CreateUploadButton (fu);
	CreatePanel (parent, logFu, fu, bFu);
	fu.FileSelected += u =&gt; OnFileSelected (logFu, fu, bFu);
	
	//------------------------------------------------------
	""Image upload"".Header (3).AppendTo (parent);
	var iu= new ImgUpload();
	var logIm = new Div ();
	var bIm= CreateUploadButton (iu);
	CreatePanel (parent, logIm, iu, bIm);
	iu.FileSelected += u =&gt; OnFileSelected (logIm, iu, bIm);
	
}

static void OnFileSelected&lt;T&gt; (Div logDiv, FileUpload&lt;T&gt; fileupload, Button bUpload) where T: ElementBase
{
	bUpload.Disable (fileupload.Input.Files.Count == 0);
	ShowFileInfo (fileupload.Input.Files, logDiv);
}

static Button CreateUploadButton&lt;T&gt; (FileUpload&lt;T&gt; fu) where T: ElementBase
{
	var bFu = new Button ().AddClass (""btn-info"").IconClass (""icon-upload"")
		.Text (""Upload"").Disable (true).LoadingText (""uploading"");
	bFu.Clicked += (b, ev) =&gt; SendFile (b, ev, fu.Input);
	return bFu;
}

static void CreatePanel&lt;T&gt; (Element parent, Div logFu, FileUpload&lt;T&gt; fu, Button bFu) where T: ElementBase
{
	new Div ().ClassName (""bs-docs-example"").Append (fu).Append (bFu).Append (logFu).AppendTo (parent);
}

static void ShowFileInfo ( IList&lt;File&gt; files, Div log)
{
	log.Empty ();
	if(files.Count==0) return ;
	var file = files[0]; 
	log.Append (string.Format(""Name:{0}&lt;br&gt;Size:{1}&lt;br&gt;Type:{2}&lt;br&gt;LastModifiedDate:{3}"",
	                          file.Name,
	                          file.Size,
	                          file.Type,
	                          file.LastModifiedDate.Format(""dd-MM-yyyy HH:mm:ss"")));
}

static void SendFile (Button b, jQueryEvent ev, FileElement input)
{
	b.ShowLoadingText ();
	var fd = new FormData ();
	fd.Append (""userfile"", input.Files [0]);
	
	var rq = fd.Send (""SaveFile"");
	rq.Done (() =&gt; ""File Uploaded"".LogSuccess (5000));
	rq.Fail (() =&gt; rq.GetError ().StatusText.LogError ());
	rq.Always (() =&gt; b.ResetLoadingText ());
	
}
</textarea></div>");

		}

	}
}

