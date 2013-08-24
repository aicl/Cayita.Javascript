using System.Runtime.CompilerServices;
using System;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName("File")]
	public class LocalFile
	{
		LocalFile ()
		{
		}

		[IntrinsicProperty]
		public JsDate LastModifiedDate { get { return null; } }

		[IntrinsicProperty]
		public string Name { get { return null; } }

		[IntrinsicProperty]
		public int Size { get { return 0; } }

		[IntrinsicProperty]
		public string WebkitRelativePath { get { return null; } }

		[IntrinsicProperty]
		public string Type { get { return null; } }
	}
}

