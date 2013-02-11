using jQueryApi;
using System.Runtime.CompilerServices;
using System.Html;

namespace jQueryApi
{
	[IgnoreNamespace, Imported (IsRealType = true), ScriptName ("$")]
	public static class JQueryApiExtensions
	{
		//[ScriptAlias ("$")]
		//public static jQueryObject Empty(this jQueryObject element)
		//{
		//	return null;
		//}

		#region bootsrap

		[InlineCode ("$({element}).button({action})")]
		public static jQueryObject Button(this ButtonElement element,string action)
		{
			return null;
		}

		[InlineCode ("$({element}).button('loading')")]
		public static jQueryObject ShowLoadingText(this ButtonElement element)
		{
			return null;
		}

		[InlineCode ("$({element}).button('reset')")]
		public static jQueryObject ResetLoadingText(this ButtonElement element)
		{
			return null;
		}

		[InlineCode ("$({element}).toggle()")]
		public static jQueryObject Toggle(this ButtonElement element)
		{
			return null;
		}


		[InlineCode("$({element}).button.defaults.loadingText={value}")]
		public static void LoadingText(this ButtonElement element, string value)
		{
		}


		//--------------div ---------------------------

						
		[InlineCode ("$({element}).button('loading')")]
		public static jQueryObject ShowLoadingText(this DivElement element)
		{
			return null;
		}
		
		[InlineCode ("$({element}).button('reset')")]
		public static jQueryObject ResetLoadingText(this DivElement element)
		{
			return null;
		}
		
		[InlineCode("$({element}).button.defaults.loadingText={value}")]
		public static void LoadingText(this DivElement element, string value){}

		#endregion bootsrap


	}


}

