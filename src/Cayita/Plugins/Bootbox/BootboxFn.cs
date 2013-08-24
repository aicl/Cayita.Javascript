using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita
{

	public static partial class Plugins{

		[PreserveCase]
		public static  BootboxOptions BootboxOptions()
		{
			return UI.Cast<BootboxOptions>(new { 
				onEscape= (Action)(()=>{})
			});

		}


		public static void ShowBootboxDialog(string message, IEnumerable<BootboxHandler> handlers=null, BootboxOptions options=null)
		{
			Bootbox.Dialog (message, handlers?? new BootboxHandler[0], options?? new BootboxOptions());
		}

	}


}

