using System.Html;

namespace Cayita.UI
{
	
	public class CheckGroup:GroupBase<CheckGroup,InputCheckbox>
	{
		
		public CheckGroup(Element parent):base("checkbox", parent)
		{
		}
		
		public CheckGroup(ElementBase parent):base("checkbox", parent.Element())
		{
		}
		
		public CheckGroup():base("checkbox")
		{
			
		}
		
	}
}

