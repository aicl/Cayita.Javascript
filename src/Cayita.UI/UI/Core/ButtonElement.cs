using System.Runtime.CompilerServices;

namespace System.Html
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class ButtonElement:Element
	{
		ButtonElement ()
		{
		}
		
		[IntrinsicProperty]
		public FormElement Form
		{
			get
			{
				return null;
			}
		}
		

		public string Type {
			[InlineCode("$({this}).attr('type')")]
			get;
			
			[InlineCode("$({this}).attr('type', {value})")]
			set;
		}

	}
}

