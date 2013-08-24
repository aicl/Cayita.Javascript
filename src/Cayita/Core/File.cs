using System.Runtime.CompilerServices;

namespace System.Html.IO
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public class File
	{
		File ()
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