using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TableHead:TableBand
	{
		[InlineCode("Cayita.UI.TableHead()")]
		public TableHead ()
		{
		}
	}
}

