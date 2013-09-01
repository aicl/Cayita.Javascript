using System;
using System.Runtime.CompilerServices;

namespace Cayita
{


	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class AnchorIcon:Anchor
	{
		[InlineCode("Cayita.UI.AnchorIcon()")]
		public AnchorIcon ()
		{
		}

		[InlineCode("Cayita.UI.AnchorIcon({iconClass})")]
		public AnchorIcon (string iconClass)
		{
		}

		[InlineCode("Cayita.UI.AnchorIcon(null,{action},{parent})")]
		public AnchorIcon(Atom parent, Action<AnchorIcon> action=null){}


		[InlineCode("Cayita.UI.AnchorIcon(null,{action},null)")]
		public AnchorIcon(Action<AnchorIcon> action){}


		[IntrinsicProperty]
		public CssIcon  Icon{ get; protected internal set; }

		public string IconClass{ get; set; }

	}

	public static partial class UI
	{
		public static AnchorIcon AnchorIcon(string iconClass, Action<Atom> action, Atom parent)
		{
			var e = Anchor().As<AnchorIcon> ();
			e.SetToAtomProperty ("icon", new CssIcon (iconClass));
			e.SetToAtomProperty ("get_iconClass", (Func<string>)(() => e.Icon.ClassName));
			e.SetToAtomProperty ("set_iconClass", (Action<string>)((v) => e.Icon.ClassName = v));
			e.Append (e.Icon);

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);

			return e;
		}
	}

}

