using System.Runtime.CompilerServices;

namespace Cayita
{

	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class GroupOption<T>:Label
	{

		public T Value {
			[InlineCode("{this}.input.get_value()")]get;
			[InlineCode("{this}.input.set_value({value})")]set;
		}

		public bool Checked{
			[InlineCode("{this}.input.checked")]get;
			[InlineCode("{this}.input.checked={value}")]set;
		}

		[IntrinsicProperty]
		public CheckInput<T> Input { 
			get ;
			internal set;
		}


	}
	

}

