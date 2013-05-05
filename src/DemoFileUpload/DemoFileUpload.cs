using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;
using System.Html.IO;
using System;

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
			FileUpload fu= new FileUpload();
			Div logFu = new Div ();
			SubmitButton sbFu= new SubmitButton (null, bt => {
				bt.ClassName = "btn btn-info";
				bt.Text ("Upload");
				bt.Disabled=true;
				bt.OnClick (ev => {
					ev.PreventDefault();
					"uploading".LogInfo(2000);
				});
			});


			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				new Form (div, f => {
					f.Append(fu);										
					f.Append(sbFu);
				});
				div.Append(logFu);

			}).AppendTo (parent);

			fu.FileSelected += u => {
				fu.Input( i=>{
					sbFu.Disable(i.Files.Count==0);
					ShowFileInfo( i.Files, logFu );
				});
			};


			//------------------------------------------------------
			"Image upload".Header (3).AppendTo (parent);
			ImgUpload iu= new ImgUpload();
			Div logIm = new Div ();
			SubmitButton sbIm= new SubmitButton (null, bt => {
				bt.ClassName = "btn btn-info";
				bt.Text ("Upload");
				bt.Disabled=true;
				bt.OnClick (ev => {
					ev.PreventDefault();
					"uploading".LogInfo(2000);
				});
			});
						
			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				new Form (div, f => {
					f.Append(iu);										
					f.Append(sbIm);
				});
				div.Append(logIm);
			}).AppendTo (parent);
			
			iu.FileSelected += u => {
				iu.Input( i=>{ 
					sbIm.Disable(i.Files.Count==0);
					ShowFileInfo( i.Files, logIm );
				});

			};

		}

	}
}

