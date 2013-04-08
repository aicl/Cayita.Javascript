using System;
using System.Html;
using jQueryApi;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	[ScriptName("StringExt")]
	public static class StringExtensions
	{
		public static Element Header (this string text,  int size, Element parent)
		{
			var h = Document.CreateElement ("h" + size.ToString ());
			h.InnerHTML= text;
			parent.AppendChild(h);
			return h;
		}


		public static Element Header (this string text,  int size, jQueryObject parent)
		{
			var h = Document.CreateElement ("h" + size.ToString ());
			h.InnerHTML= text;
			parent.Append (h);
			return h;
		}

		public static Element Header (this string text,  int size)
		{
			var h= Document.CreateElement ("h" + size.ToString ());
			h.InnerHTML= text;
			return h;
		}

		public static Element Paragraph (this string text,   Element parent)
		{
			var h = Document.CreateElement ("p" );
			h.InnerHTML= text;
			parent.AppendChild(h);
			return h;
		}

		public static Element Paragraph (this string text,  jQueryObject parent)
		{
			var h = Document.CreateElement ("p");
			h.InnerHTML= text;
			parent.Append (h);
			return h;
		}

		public static Element Paragraph (this string text)
		{
			var h = Document.CreateElement ("p");
			h.InnerHTML= text;
			return h;
		}

	}
}

