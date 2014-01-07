using Cayita.JData;
using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class StorePager<T>:Div where T:Record, new ()
	{
		[InlineCode("Cayita.UI.StorePager({T})({store})")]
		public StorePager(Store<T> store){
		}

		[IntrinsicProperty]
		public Div NavDiv { get;  internal set; }
		[IntrinsicProperty]
		public Div PagerDiv { get; internal set; }
		[IntrinsicProperty]
		public Div InfoDiv { get; internal set; }

		[IntrinsicProperty]
		public ButtonIcon FirstPage{  get;  internal set; }
		[IntrinsicProperty]
		public ButtonIcon PreviousPage{ get; internal set; }
		[IntrinsicProperty]
		public ButtonIcon NextPage{ get; internal set; }
		[IntrinsicProperty]
		public ButtonIcon LastPage{ get;  internal set; }

		[IntrinsicProperty]
		public Label PageLabel { get; internal set; }
		[IntrinsicProperty]
		public TextInput CurrentPage { get; internal set; }
		[IntrinsicProperty]
		public Label TotalPagesLabel { get; internal set; }

		[IntrinsicProperty]
		public Label InfoLabel { get; internal set; }

		public string PageText { protected internal get; set;  }
		public string OfText {  protected internal get; set;  }
		public Func<Store<T>,string> InfoFn { protected internal get; set;  }

		public void Update(){
		}

	}
	
}
