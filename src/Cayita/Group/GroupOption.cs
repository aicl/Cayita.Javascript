using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class GroupOption<T>:Label
	{

		public T Value {
			[InlineCode("{this}.go.input.get_value()")]get;
			[InlineCode("{this}.go.input.set_value({value})")]set;
		}

		public bool Checked{
			[InlineCode("{this}.go.input.checked")]get;
			[InlineCode("{this}.go.input.checked={value}")]set;
		}

		public CheckInput<T> Input { 
			[InlineCode("{this}.go.input")]
			get { return null; }
		}


	}
	

}

