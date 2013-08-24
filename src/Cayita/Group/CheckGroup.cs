using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CheckGroup<T>:GroupBase<T> {

		[InlineCode("Cayita.UI.CheckGroup({T})()")]
		public CheckGroup(){
		}

	}

}

