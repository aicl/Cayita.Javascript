using System.Runtime.CompilerServices;
using jQueryApi;

namespace Cayita
{


	public static  class JQueryFn
	{

		[InlineCode("{jq}[{pluginName}]({method},{options})")]
		internal static jQueryObject Execute(this jQueryObject jq, string pluginName, string method=null, object options=null)
		{
			return null;
		}

		[InlineCode("{jq}[{pluginName}]({method},{options})")]
		internal static T Execute<T>(this jQueryObject jq, string pluginName, string method=null, object options=null)
			where T: class
		{
			return default(T);
		}

		[InlineCode("{e}.data.context")]
		public static T GetContext<T>(this jQueryEvent e)
		{
			return default(T);
		}

		[InlineCode("{e}.delegateTarget")]
		internal static Atom GetDelegateTarget(this jQueryEvent e)
		{
			return null;
		}

	}
}

