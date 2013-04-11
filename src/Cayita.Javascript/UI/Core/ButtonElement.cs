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

		[InlzineCode("$({this}).attr('type', {type})")]
		public void Type(string type)
		{
			
		}
		[InlineCode("$({this}).attr('type')")]
		public string Type()
		{
			return null;
		}

	}
}

