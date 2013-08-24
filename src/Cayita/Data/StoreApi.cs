using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.JData
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class StoreApi<T>
	{
		[InlineCode("Cayita.Data.StoreApi({T})()")]
		public StoreApi()
		{
		}

		[IntrinsicProperty]
		public string Url { get; set; }
		[IntrinsicProperty]
		public string DataType { get; set; }
		[IntrinsicProperty]
		public string DataProperty { get; set; }
		[IntrinsicProperty]
		public string TotalCountProperty { get; set; }
		[IntrinsicProperty]
		public string HtmlProperty { get; set; }
		[IntrinsicProperty]
		public  JsDictionary<string, Func<T,object>> Converters { get; set; }
		[IntrinsicProperty]
		public string CreateMethod{ get; set; }
		[IntrinsicProperty]
		public string ReadMethod{ get; set; }
		[IntrinsicProperty]
		public string UpdateMethod{ get; set; }
		[IntrinsicProperty]
		public string DestroyMethod{ get; set; }
		[IntrinsicProperty]
		public string PatchMethod{ get; set; }


		public Func<string> CreateApiFn{  get; set; }

		public string CreateApi{ 
			get { return null; } 
		}


		public Func<string> ReadApiFn{  get; set; }

		public string ReadApi{ 
			get { return null; } 
		}


		public Func<string> UpdateApiFn{  get; set; }

		public string UpdateApi{ 
			get { return null; } 
		}


		public Func<string> DestroyApiFn{  get; set; }

		public string DestroyApi{ 
			get { return null; } 
		}


		public Func<string> PatchApiFn{  get; set; }

		public string PatchApi{ 
			get { return null; } 
		}

	}
}

