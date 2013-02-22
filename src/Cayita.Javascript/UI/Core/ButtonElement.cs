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

		[IntrinsicProperty]
		public string Type
		{
			get
			{
				return null;
			}
			set	{}
		}

	}
}

