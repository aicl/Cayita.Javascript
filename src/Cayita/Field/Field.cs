using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class Field<T>:ControlGroup 
	{

		public Input<T> Input {
			[InlineCode("{this}.cg.input")]
			get{ return null; }

		}

		public T Value {
			[InlineCode("{this}.cg.input.get_value()")] get;
			[InlineCode("{this}.cg.input.set_value({value})")] set;
		}

		public string Name {
			[InlineCode("{this}.cg.input.name")] get;
			[InlineCode("{this}.cg.input.name={value}")] set;
		}

		public string Placeholder {
			[InlineCode("{this}.cg.input.placeholder")] get;
			[InlineCode("{this}.cg.input.placeholder={value}")] set;
		}

		public bool Required {
			[InlineCode("{this}.cg.input.required")] get;
			[InlineCode("{this}.cg.input.required={value}")] set;
		}


		public bool ReadOnly {
			[InlineCode("{this}.cg.input.readOnly")] get;
			[InlineCode("{this}.cg.input.readOnly={value}")] set;
		}

		public int MaxLength {
			[InlineCode("{this}.cg.input.maxLength")] get;
			[InlineCode("{this}.cg.input.maxLength={value}")] set;
		}

		public int MinLength {
			[InlineCode("{this}.cg.input.get_minLength()")] get;
			[InlineCode("{this}.cg.input.set_minLength({value})")] set;
		}

		[InlineCode("{this}.cg.input.select()")]
		public void Select()
		{
		}

		[InlineCode("{this}.cg.input.focus()")]
		public new void Focus()
		{
		}

		[InlineCode("{this}.cg.appendAddon({atom})")]
		public  void AppendAddOn(Element atom)
		{
		}

		[InlineCode("{this}.cg.appendStringAddon({content})")]
		public  void AppendAddOn(string content)
		{
		}

		[InlineCode("{this}.cg.prependAddon({atom})")]
		public  void PrependAddOn(Element atom)
		{
		}

		[InlineCode("{this}.cg.prependStringAddon({content})")]
		public  void PrependAddOn(string content)
		{
		}


		public event jQueryEventHandler Changed {
			[InlineCode("{this}.add_changed({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_changed({value})")]
			remove
			{
			}
		}

	}
}
