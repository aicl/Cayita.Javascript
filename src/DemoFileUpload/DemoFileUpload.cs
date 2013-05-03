using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;
using jQueryApi;

namespace Cayita.Javascript
{
	[IgnoreNamespace]
	public class DemoFileUpload
	{
		public DemoFileUpload (){}

		static void ShowFileInfo ( FileUpload fu, Div log)
		{
			log.Empty ();
			fu.Input (i => {
				if(i.Files.Count==0) return ;
				var file = i.Files[0];

				log.Append (string.Format("Name:{0}<br/>Size:{1}<br/>Type:{2}",
				                          file.Name,file.Size,file.Type));
			});


		}

		public static void Execute(Element parent)
		{

			"File upload".Header (3).AppendTo (parent);

			FileUpload fu= new FileUpload();
			Div log = new Div ();
			SubmitButton sb= new SubmitButton (null, bt => {
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
					f.Append(sb);
				});
				div.Append(log);
			}).AppendTo (parent);

			fu.FileSelected += u => {
				fu.Input( i=>sb.Element().Disabled= i.Files.Count==0 );
				ShowFileInfo( fu, log );
			};


			//------------------------------------------------------
			"Image upload".Header (3).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";
				
				new Form (div, f => {
					
					new ImgUpload (f);
					
					new SubmitButton (f, bt => {
						bt.ClassName = "btn btn-info";
						bt.Text ("Upload");
						bt.OnClick (ev => {
							ev.PreventDefault ();});
					});
					
				});
				
			}).AppendTo (parent);

		}

	}
}

