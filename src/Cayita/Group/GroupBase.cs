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
			[InlineCode("{this}.cg.get_options()")]
			get	{
				return null;
			}
		}

		[InlineCode("{this}.cg.addOption({option})")]
		public void Add(GroupOption<T> option)
		{
		}

		[InlineCode("{this}.cg.addValue({value},{text},{selected})")]
		public void Add (T value, string text=null, bool selected=false){
		}

		[InlineCode("{this}.cg.addValue({value},null,{selected})")]
		public void Add (T value, bool selected){
		}

		[InlineCode("{this}.cg.loadList({data},{append})")]
		public void Load (IEnumerable<T> data, bool append=false){
		}



		[InlineCode("{this}.cg.removeOption({option})")]
		public void RemoveOption(GroupOption<T> option)
		{
		}

		[InlineCode("{this}.cg.removeValue({value})")]
		public void RemoveValue(T value)
		{
		}

		[InlineCode("{this}.cg.removeAll()")]
		public void RemoveAll()
		{
		}

		[InlineCode("{this}.cg.getOptions()")]
		public GroupOption<T>[] GetOptions()
		{
			return null;
		}

		[InlineCode("{this}.cg.getChecked()")]
		public GroupOption<T> GetChecked()
		{
			return null;
		}

		[InlineCode("{this}.cg.checkValue({value},{selected})")]
		public void Check(T value, bool selected=true )
		{
		}

		[InlineCode("{this}.cg.checkOption({option},{selected})")]
		public void Check(GroupOption<T> option, bool selected=true )
		{
		}

		[InlineCode("{this}.cg.checkAll({selected})")]
		public void CheckAll(bool selected=true )
		{
		}

		[InlineCode("{this}.cg.disableValue({value},{disable})")]
		public void Disable(T value, bool disable=true )
		{
		}

		[InlineCode("{this}.cg.disableOption({option},{disable})")]
		public void Disable(GroupOption<T> option, bool disable=true )
		{
		}

		[InlineCode("{this}.cg.disableAll({disable})")]
		public void DisableAll(bool disable=true )
		{
		}


		[InlineCode("{this}.loadData({data},{optFn},{append})")]
		public void Load<TData>(IList<TData> data, Func<TData,GroupOption<T>> optFn,bool append =false)
		{
		}


		public bool Inline {
			[InlineCode("{this}.cg.isInline()")] get;
			[InlineCode("{this}.cg.inline({value})")] set;
		}

		public string Name {
			[InlineCode("{this}.cg.get_name()")] get;
			[InlineCode("{this}.cg.set_name({value})")] set;
		}


		public event jQueryEventHandler Checked {
			[InlineCode("{this}.cg.add_checked({value})")]
			add 
			{
			}
			[InlineCode("{this}.cg.remove_checked({value})")]
			remove
			{
			}
		}
	

		public bool Required {
			[InlineCode("{this}.cg.isRequired()")]get;
			[InlineCode("{this}.cg.required({value})")]set;
		}

	}
	
}
