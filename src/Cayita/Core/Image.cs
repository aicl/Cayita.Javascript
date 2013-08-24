using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Image:Atom
	{
		[InlineCode("Cayita.UI.Atom('img',null,null)")]
		public Image ()
		{
		}


		[InlineCode("Cayita.UI.Atom('img',null,null,null, {action},{parent})")]
		public Image (Atom parent, Action<Image> action=null)
		{
		}

		[InlineCode("Cayita.UI.Atom('img',null,null,null, {action})")]
		public Image (Action<Image> action)
		{
		}

		[IntrinsicProperty]
		public string Src {
			get;
			set;
		}

		[IntrinsicProperty]
		public string Alt {
			get;
			set;
		}

		[IntrinsicProperty]
		public int Width {
			get;
			set;
		}

		[IntrinsicProperty]
		public int Height {
			get;
			set;
		}

	}
}

