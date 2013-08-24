using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita.JData
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class ReadOptions
	{
		[InlineCode("Cayita.Data.ReadOptions()")]
		public ReadOptions()
		{
		}
		[IntrinsicProperty]
		public string PageSizeParam { get; set; }
		[IntrinsicProperty]
		public string PageNumberParam { get; set; }
		[IntrinsicProperty]
		public string OrderByParam {get;set;}
		[IntrinsicProperty]
		public string OrderTypeParam {	get;set;}

		[IntrinsicProperty]
		public  int? PageNumber {get; set;}
		[IntrinsicProperty]
		public  int? PageSize {get;  set;}
		[IntrinsicProperty]
		public JsDictionary<string,object> Query {get; protected internal set;}
		[IntrinsicProperty]
		public string OrderBy { get; set; }
		[IntrinsicProperty]
		public string OrderType { get; set; }

		[IntrinsicProperty]
		public bool LocalPaging { get; set; }

		[IntrinsicProperty]
		public dynamic DynamicQuery {get; protected internal set;}


		public JsDictionary<string,object> Request {
			get {return null;}
		}

		public object DataForm {
			set{}
		}

	}
}

