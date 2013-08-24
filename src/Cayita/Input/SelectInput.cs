using System;
using System.Html;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class SelectInput<T> : Input<T>
	{
		[InlineCode("Cayita.UI.SelectInput({T})()")]
		public SelectInput(){
		}

		[IntrinsicProperty]
		public bool Multiple {
			get;
			set;
		}
		[IntrinsicProperty]
		public ElementCollection Options
		{
			get	{
				return null;
			}
		}
		[IntrinsicProperty]
		public int SelectedIndex {
			get;
			set;
		}
		[IntrinsicProperty]
		public int Size {
			get;
			set;
		}


		public OptionAtom<T> SelectedOption {
			get{ return null;}
		}

		//
		// Methods
		//
		public void Add (OptionAtom<T> option)
		{
		}
		public void Add (OptionAtom<T> option, int index)
		{
		}
		public void Add (OptionAtom<T> option, OptionAtom<T> before)
		{
		}

		[InlineCode("{this}.addValue({value},{text},{selected})")]
		public void Add (T value, string text=null, bool selected=false){
		}

		[InlineCode("{this}.addValue({value},null,{selected})")]
		public void Add (T value,bool selected){
		}

		[InlineCode("{this}.addOption({option})")] 
		public void Add(Action<OptionAtom<T>> option)
		{
		}

		public void Remove (int index)
		{
		}


		public void RemoveOption(OptionAtom<T> value)
		{
		}


		public void RemoveValue(T value)
		{
		}


		public void RemoveAll()
		{
		}
	

		public List<OptionAtom<T>> Selected{
			get{ return null;}
		}

		[InlineCode("{this}.selectOption({option},{selected})")]
		public void Select(OptionAtom<T> option, bool selected=true)
		{
		}

		[InlineCode("{this}.selectValue({value},{selected})")]
		public void Select(T value, bool selected=true)
		{
		}

		[InlineCode("{this}.selectAll({selected})")]
		public void SelectAll(bool selected=true)
		{
		}


		[InlineCode("{this}.loadData({data},{optFn},{append})")]
		public void Load<TData>(IList<TData> data, Func<TData,OptionAtom<T>> optFn,bool append =false)
		{
		}

		[InlineCode("{this}.loadList({data},{append})")]
		public void Load(IList<T> data, bool append=false){
		}

	}

}

