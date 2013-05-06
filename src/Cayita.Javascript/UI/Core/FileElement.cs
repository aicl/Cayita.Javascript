using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Html.IO;

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
	
		/// <summary>
		/// Gets or sets the accept.
		/// </summary>
		/// <value>The accepted value : audio/*  video/* image/* image/jpeg, image/png  MIME_type </value>
		/// 
		[IntrinsicProperty]
		public string Accept
		{
			get;set;
		}

	}
}