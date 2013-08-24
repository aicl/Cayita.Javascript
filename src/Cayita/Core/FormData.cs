using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita
{

	[Imported (ObeysTypeSystem = true)]
	public class FormData
	{
		[InlineCode("new FormData()")]
		public FormData ()
		{
		}


		[InlineCode("new FormData({form})")]
		public FormData (Form form)
		{
		}

		public void Append(string key, object value)
		{
		}

		public void Append(string key, FileInput value, string name)
		{
		}

		public void Append(Input value)
		{
		}

		[ScriptSkip]
		public TypeOption<JsDictionary<string, object>,Array> AsTypeOption()
		{
			return null;
		}


	}

}

