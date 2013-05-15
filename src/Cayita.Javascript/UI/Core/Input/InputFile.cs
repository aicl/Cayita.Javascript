using System;
using System.Html;

namespace Cayita.UI
{
	public class InputFile:InputBase<InputFile>
	{
		protected InputFile(){}
		
		public InputFile(Element parent,  Action<FileElement> element)
			:base(parent,"file" )
		{
			element.Invoke( Element());
		}
		
		
		public InputFile (Element parent)
			:base(parent,"file")
		{}
		
		
		public new FileElement Element()
		{
			return base.Element().As<FileElement>() ;
		}

	}
	
}

