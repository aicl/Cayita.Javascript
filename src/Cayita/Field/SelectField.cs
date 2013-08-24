using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class SelectField<T>:Field<T>
	{

		[InlineCode("Cayita.UI.SelectField({T})()")]
		public SelectField()
		{
		}


		[InlineCode("Cayita.UI.SelectField({T})()")]
		public SelectField(string type)
		{
		}

		[InlineCode("Cayita.UI.SelectField({T})(null, {action},{parent})")]
		public SelectField(Atom parent, Action<SelectField<T>> action=null){}




		public new SelectInput<T> Input {
			[InlineCode("{this}.input")]
			get{ return null; }

		}

	}
}

