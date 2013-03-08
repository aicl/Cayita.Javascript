using System.Runtime.CompilerServices;

namespace System.Html
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class LabelElement:Element
	{
		LabelElement ()
		{
		}

		[InlineCode("$({this}).attr('for', {fieldId})")]
		public void For(string fieldId)
		{

		}
		[InlineCode("$({this}).attr('for')")]
		public string For()
		{
			return null;
		}
	}
}