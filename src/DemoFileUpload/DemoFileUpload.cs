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

			b.ResetLoadingText ();
		}


		public static void Execute(Element parent)
		{
			"File upload".Header (3).AppendTo (parent);

			var logFu = new Div ();
			var fu= new FileUpload();

			var bFu = new Button ()
				.AddClass ("btn-info")
					.IconClass ("icon-upload")
					.Text ("Upload")
					.Disable (true).
					LoadingText("uploading");

			bFu.Clicked+= (b,ev) => SendFile(b, ev, fu.Input);


			new Div ()
				.ClassName ("bs-docs-example")
					.Append (fu)
					.Append (bFu)
					.Append (logFu)
					.AppendTo (parent);

			fu.FileSelected += u => {
				bFu.Disable(fu.Input.Files.Count==0);
				ShowFileInfo( fu.Input.Files, logFu );

			};


			//------------------------------------------------------
			"Image upload".Header (3).AppendTo (parent);
			var iu= new ImgUpload();
			var logIm = new Div ();
			var bIm= new Button ()
				.AddClass ("btn-info")
					.IconClass ("icon-upload")
					.Text ("Upload")
					.Disable (true);
			
			bIm.Clicked+= (b,ev) => SendFile(b, ev, iu.Input);
						
			new Div ()
				.ClassName ("bs-docs-example")
					.Append (iu)
					.Append (bIm)
					.Append (logIm)
					.AppendTo (parent);
			
			iu.FileSelected += u => {
				bIm.Disable(iu.Input.Files.Count==0);
				ShowFileInfo(iu.Input.Files, logIm );
			};

		}

	}
}

