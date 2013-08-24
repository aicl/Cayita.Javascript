using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported]
	public sealed class PopoverObject
	{
		[InlineCode ("{this}.popover('show')")]
		public void Show(){
		}

		[InlineCode ("{this}.popover('toggle')")]
		public void Toggle(){
		}

		[InlineCode ("{this}.popover('hide')")]
		public void Hide(){
		}

		[InlineCode ("{this}.popover('destroy')")]
		public void Destroy(){
		}


		[InlineCode("Cayita.Plugins.popoverInit({this},{options})")]
		public void Init(PopoverOptions options){
		}

	}
}

