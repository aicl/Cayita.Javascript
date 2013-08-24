using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita
{
	public static partial class Plugins
	{
		[PreserveCase]
		public static PopoverOptions PopoverOptions()
		{
			return UI.Cast<PopoverOptions> (new {animation=true, placement = "right",trigger = "click",title="", content="" });
		}


		[InstanceMethodOnFirstArgument, ScriptName ("popover")]
		public static PopoverObject Popover (this jQueryObject q, PopoverOptions options=null)
		{
			return null;
		}

		public static PopoverObject Popover (this Element e, PopoverOptions options=null)
		{
			return Popover (jQuery.FromElement(e), options?? new PopoverOptions());
		}


		public static void PopoverInit(PopoverObject o, PopoverOptions options)
		{
			o.Destroy ();
			Popover (UI.Cast<jQueryObject>(o), options); 
		}

	}
}

