using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;
using System.Collections.Generic;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public abstract class GroupBase<T>:ControlGroup
	{
		public ElementCollection Options
		{
			[InlineCode("{this}.get_options()")]
			get	{
				return null;
			}
		}

		[InlineCode("{this}.addOption({option})")]
		public void Add(GroupOption<T> option)
		{
		}

		[InlineCode("{this}.addValue({value},{text},{selected})")]
		public void Add (T value, string text=null, bool selected=false){
		}

		[InlineCode("{this}.addValue({value},null,{selected})")]
		public void Add (T value, bool selected){
		}

		[InlineCode("{this}.loadList({data},{append})")]
		public void Load (IEnumerable<T> data, bool append=false){
		}


		[InlineCode("{this}.removeOption({option})")]
		public void RemoveOption(GroupOption<T> option)
		{
		}

		[InlineCode("{this}.removeValue({value})")]
		public void RemoveValue(T value)
		{
		}

		[InlineCode("{this}.removeAll()")]
		public void RemoveAll()
		{
		}

		[InlineCode("{this}.getOptions()")]
		public GroupOption<T>[] GetOptions()
		{
			return null;
		}

		[InlineCode("{this}.getChecked()")]
		public GroupOption<T> GetChecked()
		{
			return null;
		}

		[InlineCode("{this}.checkValue({value},{selected})")]
		public void Check(T value, bool selected=true )
		{
		}

		[InlineCode("{this}.checkOption({option},{selected})")]
		public void Check(GroupOption<T> option, bool selected=true )
		{
		}

		[InlineCode("{this}.checkAll({selected})")]
		public void CheckAll(bool selected=true )
		{
		}

		[InlineCode("{this}.disableValue({value},{disable})")]
		public void Disable(T value, bool disable=true )
		{
		}

		[InlineCode("{this}.disableOption({option},{disable})")]
		public void Disable(GroupOption<T> option, bool disable=true )
		{
		}

		[InlineCode("{this}.disableAll({disable})")]
		public void DisableAll(bool disable=true )
		{
		}


		[InlineCode("{this}.loadData({data},{optFn},{append})")]
		public void Load<TData>(IList<TData> data, Func<TData,GroupOption<T>> optFn,bool append =false)
		{
		}


		public bool Inline {
			[InlineCode("{this}.is_inline()")] get;
			[InlineCode("{this}.inline({value})")] set;
		}

		public string Name {
			[InlineCode("{this}.get_name()")] get;
			[InlineCode("{this}.set_name({value})")] set;
		}


		public event jQueryEventHandler Checked {
			[InlineCode("{this}.add_checked({value})")]
			add 
			{
			}
			[InlineCode("{this}.remove_checked({value})")]
			remove
			{
			}
		}
	

		public bool Required {
			[InlineCode("{this}.is_required()")]get;
			[InlineCode("{this}.required({value})")]set;
		}

	}
	
}
