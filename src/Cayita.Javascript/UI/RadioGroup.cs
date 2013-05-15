using System;
using System.Html;
using System.Collections.Generic;

namespace Cayita.UI
{
	public class RadioGroup:GroupBase<RadioGroup,InputRadio>
	{

		public RadioGroup(Element parent):base("radio", parent)
		{
		}
		
		public RadioGroup(ElementBase parent):base("radio", parent.Element())
		{
		}
		
		public RadioGroup():base("radio")
		{
			
		}



		public RadioGroup (Element parent, string text, string fieldName, IList<GroupItem> items, bool inline=true)
			:base("radio", parent, text, fieldName, items, inline)
		{


		}




	}
	
}
