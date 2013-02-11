using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace Cayita.Javascript.UI
{
	[Serializable]	
	[ScriptNamespace("Cayita.UI")]
	public class SelectedRow
	{
		public SelectedRow (){}

		public string Index {get;set;}
		public TableRowElement Row {get;set;}
	}



}

