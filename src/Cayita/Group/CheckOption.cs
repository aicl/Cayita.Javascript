using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class CheckOption<T>:GroupOption<T>
	{
		[InlineCode("Cayita.UI.CheckOption({T})()")]
		public CheckOption(){
		}

		[InlineCode("Cayita.UI.CheckOption({T})({value},{text},{selected})")]
		public CheckOption(T value, string text="", bool selected=false ){
		}

		[InlineCode("Cayita.UI.CheckOption({T})({value},'',{selected})")]
		public CheckOption(T value, bool selected ){
		}
	}

}
