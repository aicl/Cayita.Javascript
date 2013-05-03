using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.IO;

namespace System.Html
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class FileElement:Element
	{

		[IntrinsicProperty]
		public IList<File>  Files {
			get { return null; }
		}


		[IntrinsicProperty]
		public string DefaultValue
		{
			get
			{
				return null;
			}
		}
		
		[IntrinsicProperty]
		public FormElement Form
		{
			get
			{
				return null;
			}
		}
		
		[IntrinsicProperty]
		public string Name {
			get;
			set;
		}
		
		[IntrinsicProperty]
		public string Type
		{
			get;
			set;
		}
		
		[IntrinsicProperty]
		public string Value
		{
			get;
			set;
		}
		
		//
		// Methods
		//
		public void Select ()
		{
		}
	

	}
}