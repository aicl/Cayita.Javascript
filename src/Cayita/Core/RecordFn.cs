using System;
using System.Runtime.CompilerServices;
using System.Collections;

namespace Cayita
{
	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class RecordFn
	{

		public static void PopulateFrom(this Record data, JsDictionary source)
		{
			var d = (JsDictionary)data;
			foreach (var p in source) {
				if (d.ContainsKey(p.Key)) d[p.Key]=p.Value;
			}
		}

	}
}

