using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class SearchBoxConfig
	{

		[InlineCode("Cayita.UI.SearchBoxConfig()")]
		public SearchBoxConfig ()
		{
		}

		[IntrinsicProperty]
		public string TextField { get; set; }

		[IntrinsicProperty]
		public string Name { get; set; }

		[IntrinsicProperty]
		public bool Required { get; set; }

		[IntrinsicProperty]
		public bool Paged { get; set; }

		[IntrinsicProperty]
		public bool SearchButton { get; set; }

		[IntrinsicProperty]
		public bool ResetButton { get; set; }

		[IntrinsicProperty]
		public int Delay { get; set; }

		//public bool AutoSelect { get; set; }

		[IntrinsicProperty]
		public int MinLength {get;set;}

		[IntrinsicProperty]
		public string SearchIconClassName {get;set;}

		[IntrinsicProperty]
		public string ResetIconClassName {get;set;}


		[IntrinsicProperty]
		public string Placeholder {get;set;}

	}
}

