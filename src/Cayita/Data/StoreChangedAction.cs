using System;
using System.Runtime.CompilerServices;

namespace Cayita.JData
{
	public enum StoreChangedAction{
		None,

		Created,
		Read,
		Updated,
		Destroyed,
		Patched,

		Added,
		Inserted,
		Replaced,
		Removed,
		Cleared,
		Loaded,
		Filtered
	}
}

