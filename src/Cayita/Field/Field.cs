using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class Field<T>:ControlGroup 
	{

		[IntrinsicProperty]
		public Input<T> Input {
			get;
			internal set;
		}

		public T Value {
			[InlineCode("{this}.input.get_value()")] get;
			[InlineCode("{this}.input.set_value({value})")] set;
		}

		public string Name {
			[InlineCode("{this}.input.name")] get;
			[InlineCode("{this}.input.name={value}")] set;
		}

		public string Placeholder {
			[InlineCode("{this}.input.placeholder")] get;
			[InlineCode("{this}.input.placeholder={value}")] set;
		}

		public bool Required {
			[InlineCode("{this}.input.required")] get;
			[InlineCode("{this}.input.required={value}")] set;
		}


		public bool ReadOnly {
			[InlineCode("{this}.input.readOnly")] get;
			[InlineCode("{this}.input.readOnly={value}")] set;
		}

		public int MaxLength {
			[InlineCode("{this}.input.maxLength")] get;
			[InlineCode("{this}.input.maxLength={value}")] set;
		}

		public int MinLength {
			[InlineCode("{this}.input.get_minLength()")] get;
			[InlineCode("{this}.input.set_minLength({value})")] set;
		}

		[InlineCode("{this}.input.select()")]
		public void Select()
		{
		}

		[InlineCode("{this}.input.focus()")]
		public new void Focus()
		{
		}

		[InlineCode("{this}.appendAddon({atom})")]
		public  void AppendAddOn(Element atom)
		{
		}

		[InlineCode("{this}.appendStringAddon({content})")]
		public  void AppendAddOn(string content)
		{
		}

		[InlineCode("{this}.prependAddon({atom})")]
		public  void PrependAddOn(Element atom)
		{
		}

		[InlineCode("{this}.prependStringAddon({content})")]
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
