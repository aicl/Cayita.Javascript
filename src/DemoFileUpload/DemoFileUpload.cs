using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;
using System.Html.IO;

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

		public static void Execute(Element parent)
		{
			"File upload".Header (3).AppendTo (parent);

			var logFu = new Div ();
			var fu= new FileUpload();

			var sbFu = new SubmitButton ()
				.AddClass ("btn-info")
					.IconClass ("icon-upload")
					.Text ("Upload")
					.Disable (true);

			sbFu.Clicked+= (b,ev) => {
				ev.PreventDefault();
				( "uploading: " + fu.Input.Files[0].Name).LogInfo(2000) ;
			};

			new Div ()
				.ClassName ("bs-docs-example")
					.Append (new Form ()
					        .Append (fu)
					         .Append (sbFu))
					.Append (logFu)
					.AppendTo (parent);

			fu.FileSelected += u => {
				sbFu.Disable(fu.Input.Files.Count==0);
				ShowFileInfo( fu.Input.Files, logFu );

			};


			//------------------------------------------------------
			"Image upload".Header (3).AppendTo (parent);
			var iu= new ImgUpload();
			var logIm = new Div ();
			var sbIm= new SubmitButton ()
				.AddClass ("btn-info")
					.IconClass ("icon-upload")
					.Text ("Upload")
					.Disable (true);
			
			sbIm.Clicked+= (b,ev) => {
				ev.PreventDefault();
				( "uploading: " +iu.Input.Files[0].Name).LogInfo(2000) ;
			};
						
			new Div ()
				.ClassName ("bs-docs-example")
					.Append (new Form ()
					         .Append (iu)
					         .Append (sbIm))
					.Append (logIm)
					.AppendTo (parent);
			
			iu.FileSelected += u => {
				sbIm.Disable(iu.Input.Files.Count==0);
				ShowFileInfo(iu.Input.Files, logIm );
			};

		}

	}
}

