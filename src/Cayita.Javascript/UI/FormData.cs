using System;
using System.Runtime.CompilerServices;
using Cayita.UI;

namespace System.Html
{
	[Imported (ObeysTypeSystem = true)]
	public class FormData
	{
		[InlineCode("new FormData()")]
		public FormData ()
		{
		}

		[InlineCode("new FormData({form})")]
		public FormData (FormElement form)
		{
		}

		public void Append(string key, object value)
		{
		}
	}
}

