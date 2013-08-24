using System;

namespace Cayita
{
	public static partial class UI
	{
		public static Button Button (string text, string className, string type, Action<Atom> action=null, Atom parent=null )
		{
			return  Atom("button", type??"button", className??"btn", text,action, parent).As<Button>();
		}

		public static ResetButton ResetButton ( string text, Action<Atom> action, Atom parent )
		{
			return  Button(text, "btn", "reset",action, parent).As<ResetButton>();
		}


		public static SubmitButton SubmitButton (  string text, Action<Atom> action, Atom parent )
		{
			return  Button( text, "btn", "submit", action, parent).As<SubmitButton>();
		}

		public static ButtonIcon ButtonIcon(string iconClass, Action<Atom> action, Atom parent)
		{
			var e = Button (null,"btn", "button",null, null).As<ButtonIcon> ();
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

