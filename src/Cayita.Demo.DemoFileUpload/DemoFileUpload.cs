using System;
using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoFileUpload
	{
		public DemoFileUpload ()
		{
		}

		public static void Execute(Atom parent)
		{

			var fp = new Div ("bs-docs-example");
			var ff = new FileField (fp);
			var ufb = CreateUploadButton (fp);
			var logf = new Div (fp);

			var imp = new Div ("bs-docs-example");
			var imf = new ImgField (imp);
			var imb = CreateUploadButton (imp);
			var logim = new Div (imp);

			parent.JQuery
				.Append ("File Upload".Header(3))
					.Append (fp)
					.Append ("Image Upload".Header(3))
					.Append (imp);


			var rq =jQuery.GetData<string> ("code/demofileupload.html");
			rq.Done (s=> {
				var code=new Div();
				code.InnerHTML= s;
				parent.JQuery.Append ("C# code".Header(3)).Append(code);
			});



			ff.Changed+= (e) => ShowFileInfo(ufb, logf,ff.Input);
			imf.Changed+= (e) => ShowFileInfo(imb, logim, imf.Input);

			ufb.Clicked+= (e) => SendFile(ufb, ff.Input);
			imb.Clicked+= (e) => SendFile(imb, imf.Input);
		}


		static ButtonIcon CreateUploadButton(Atom parent){
			return  new ButtonIcon (parent, imb=>{ 
				imb.IconClass="icon-upload";
				imb.Text = "Upload";
				imb.AddClass ("btn-info"); 
				imb.Disabled=true;
			});
		}

		static void ShowFileInfo(ButtonIcon bt, Div log, FileInput input)
		{
			log.Empty ();
			bt.Disabled = input.Files.Length == 0;
			foreach (var f in input.Files) {
				log.Append ("Name:{0}<br>Size:{1}<br>Type:{2}<br>LastModifiedDate:{3}<br>"
				            .Fmt(f.Name,f.Size,f.Type,f.LastModifiedDate.ToString("dd-MM-yyyy HH:mm:ss")));
			}

		}

		static void SendFile(ButtonIcon bt, FileInput input)
		{
			bt.Disabled = true;

			var fd = new FormData ();  
			fd.Append ("userfile", input.Files [0]);  

			var rq = fd.Send ("SaveFileUrl");  
			rq.Done (() => "File Uploaded".LogSuccess (5000));  
			rq.Fail (()=> "{0}:{1}".Fmt(rq.Status, rq.StatusText).LogError());
			rq.Always (() => bt.Disabled=false);  

		}

	}
}


