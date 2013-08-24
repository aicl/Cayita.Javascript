using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class SpinnerIcon:Div
	{
		[InlineCode("Cayita.UI.SpinnerIcon({message})")]
		public SpinnerIcon (string message)
		{
		}

		[IntrinsicProperty]
		public CssIcon Icon { get; internal set; }


	}

	public static partial class UI{

		public static SpinnerIcon SpinnerIcon(string message)
		{
			var e = Atom ("div", null, "well well-large lead").As<SpinnerIcon>();
			e.Icon = Atom ("i", null, "icon-spinner icon-spin icon-2x pull-left").As<CssIcon>();
			e.Append (e.Icon);
			e.Text = !message.IsNullOrEmpty () ? message : "";

			return e;
		}
	}

}

