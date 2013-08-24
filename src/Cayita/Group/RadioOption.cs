using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class RadioOption<T>:GroupOption<T>
	{
		[InlineCode("Cayita.UI.RadioOption({T})()")]
		public RadioOption(){
		}

		[InlineCode("Cayita.UI.RadioOption({T})({value},{text},{selected})")]
		public RadioOption(T value, string text="", bool selected=false ){
		}

		[InlineCode("Cayita.UI.RadioOption({T})({value},'',{selected})")]
		public RadioOption(T value, bool selected ){
		}
	}

}
