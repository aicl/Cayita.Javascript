using System;
using System.Runtime.CompilerServices;
using Cayita.UI;
using System.Collections.Generic;

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

		[InlineCode("new FormData({form}.element())")]
		public FormData (Form form)
		{
		}

		public void Append(string key, object value)
		{
		}

		public void Append(string key, FileElement value, string name)
		{
		}

		public void Append(InputElement value)
		{
		}

		[ScriptSkip]
		public TypeOption<JsDictionary<string, object>,Array> AsTypeOption()
		{
			return null;
		}


	}
}

