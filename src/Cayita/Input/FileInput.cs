using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class FileInput:Input<string>
	{
		[InlineCode("Cayita.UI.FileInput()")]
		public FileInput ()
		{
		}

		[IntrinsicProperty]
		public LocalFile[]  Files {
			get { return null; }
		}

		[IntrinsicProperty]
		public Form Form
		{
			get
			{
				return null;
			}
		}


		/// <summary>
		/// Gets or sets  accepted type files.
		/// </summary>
		/// <value>accepted types : audio/*  video/* image/* image/jpeg, image/png  MIME_type </value>
		[IntrinsicProperty]
		public string Accept
		{
			get;
			set;
		}

		[IntrinsicProperty]
		public bool Multiple
		{
			get;
			set;
		}

	}
}

