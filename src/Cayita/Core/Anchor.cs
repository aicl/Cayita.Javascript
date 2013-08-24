using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Anchor:Atom
	{

		[InlineCode("Cayita.UI.Anchor(null, '#')")]
		public Anchor ()
		{
		}

		[InlineCode("Cayita.UI.Anchor({className},{href},{text})")]
		public Anchor( string className, string href="#", string text=null)
		{
		}

		[IntrinsicProperty]
		public string Href {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Hash {
			get { return "";}
		}


		/// <summary>
		/// Gets or sets the target:  where to open the linked document
		/// </summary>
		/// <value>values: _blank || _parent ||	_self  ||_top || framename</value>
		[IntrinsicProperty]
		public string Target {
			get;
			set;
		}

		/// <summary>
		/// Gets or Sets  the MIME type of the linked document
		/// </summary>
		/// <value>MIME_type</value>
		[IntrinsicProperty]
		public string Type {
			get;
			set;
		}

	}
}

