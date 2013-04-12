using System.Runtime.CompilerServices;
using System.Html;
using Cayita.UI;

namespace Modals
{
	[IgnoreNamespace]
	public class DemoPanels
	{
		public DemoPanels ()
		{
		}
		
		public static void Execute(Element parent)
		{
			"Modals".Header (2).AppendTo (parent);
			
			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				
				div.Append( new Button(div,b=>{

				}));
				
				div.Append(@"");
				
			}).AppendTo(parent);
			
					
		}
		
	}
}



/*
new Div(null, div=>{
	div.ClassName="bs-docs-example";

	div.Append( new Button(div,b=>{
		b.Text("Simple Modal Dialog I");
		b.OnClick(evt=> Bootbox.Dialog("Your App Text: cayita is awesome....") );
	}));

	div.Append(@"");
					
}).AppendTo(parent);
*/

