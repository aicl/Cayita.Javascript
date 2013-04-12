using System.Runtime.CompilerServices;

namespace System.Html
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class LabelElement:Element
	{
		LabelElement ()
		{
		}

		public string For {
			[InlineCode("$({this}).attr('for')")]
			get;
			[InlineCode("$({this}).attr('for', {value})")]
			set;
		}
	}
}