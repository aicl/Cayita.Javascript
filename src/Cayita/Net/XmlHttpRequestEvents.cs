using System;
using System.Runtime.CompilerServices;

namespace Cayita.Net
{
	[Imported, NamedValues]
	public enum XmlHttpRequestEvents {
		[ScriptName("abort")]
		Abort,
		[ScriptName("error")]
		Error,
		[ScriptName("load")]
		Load,
		[ScriptName("loadend")]
		Loadend,
		[ScriptName("loadstart")]
		Loadstart,
		[ScriptName("progress")]
		Progress,
		[ScriptName("readystatechange")]
		Readystatechange,
		[ScriptName("timeout")]
		Timeout
	}
}

