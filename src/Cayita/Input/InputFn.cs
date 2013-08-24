using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita
{
	[PreserveMemberCase]
	[IgnoreNamespace]
	public static class InputFn
	{


		public static void SetGroupName(ControlGroup group, string value)
		{
			jQuery.FromElement(group.Controls.El).Attribute ("groupname", value);
			jQuery.Select("input",group.Controls.El).Attribute ("name", value);
		}

		public static string GetGroupName(ControlGroup group) 
		{
			return jQuery.FromElement (group.Controls.El).GetAttribute ("groupname")??"";

		}

		public static void SetGroupInline(ControlGroup group, bool value)
		{
			if (value) {
				jQuery.FromElement (group.Controls.El).Attribute ("inline", "true");
				jQuery.Select("label", group.Controls.El ).AddClass("inline");
			} else {
				jQuery.FromElement (group.Controls.El).RemoveAttr("inline");
				jQuery.Select("label", group.Controls.El ).RemoveClass("inline");
			}

		}
		
		public static bool GetGroupInline(ControlGroup group) 
		{
			return jQuery.FromElement (group.Controls.El).GetAttribute ("inline").IsNullOrEmpty () ? false : true;
		}


	}
}

