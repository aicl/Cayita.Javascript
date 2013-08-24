using System;

namespace Cayita
{
	public static partial class UI
	{
		public static  ImgPicture ImgPicture(string src, string text, Action<ImgPicture> action, Atom parent)
		{
			var e = new Anchor ("c-icon").As<ImgPicture>();

			e.Img = new Image ();
			if (!src.IsNullOrEmpty ())
				e.Img.Src = src;

			e.Label = new Label ("c-icon-label");
			e.Text = text ?? "";

			e.JQuery.Append (e.Img).Append (e.Label);

			e.SetToAtomProperty("get_text", (Func<string>)( ()=> e.Label.Text));
			e.SetToAtomProperty("set_text", (Action<string>)( (v)=> e.Label.Text=v));

			e.SetToAtomProperty("get_src",  (Func<string>)( ()=> e.Img.Src));
			e.SetToAtomProperty("set_src", (Action<string>)( (v)=> e.Img.Src=v));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);


			return e;

		}

		public static  CssPicture CssPicture(string src, string text, Action<CssPicture> action, Atom parent)
		{
			var e = new Anchor ("c-icon").As<CssPicture>();

			e.Img = new CssIcon (src);

			e.Label = new Label ("c-icon-label");
			e.Text = text ?? "";

			e.JQuery.Append (e.Img).Append (e.Label);

			e.SetToAtomProperty("get_text", (Func<string>)( ()=> e.Label.Text));
			e.SetToAtomProperty("set_text", (Action<string>)( (v)=> e.Label.Text=v));

			e.SetToAtomProperty("get_src",  (Func<string>)( ()=> e.Img.ClassName));
			e.SetToAtomProperty("set_src", (Action<string>)( (v)=> e.Img.ClassName=v));

			if (action != null)
				action (e);

			if (parent != null)
				parent.Append (e);


			return e;

		}


	}
}

