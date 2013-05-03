using System;
using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;

namespace Cayita.Javascript
{
	[IgnoreNamespace]
	public class DemoFileUpload
	{
		public DemoFileUpload (){}

		public static void Execute(Element parent)
		{
			
			"File upload".Header (3).AppendTo (parent);
			
			new Div (null, div => {
				div.ClassName = "bs-docs-example";

				new Form (div, f => {

					new FileUpload (f);
										
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

