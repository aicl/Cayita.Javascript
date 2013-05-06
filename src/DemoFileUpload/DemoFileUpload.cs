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
				
	}
}

