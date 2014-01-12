using System;
using System.Runtime.CompilerServices;
using System.Net;
using System.Collections.Generic;

namespace Cayita.Net
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class SendFormDataConfig
	{
		[InlineCode("Cayita.Fn.SendFormDataConfig()")]
		public SendFormDataConfig ()
		{
		}

		[IntrinsicProperty]
		public string Url { get; set; }
		[IntrinsicProperty]
		public HttpVerb Verb { get; set; }
		[IntrinsicProperty]
		public Dictionary<XmlHttpRequestEvents,Action<XmlHttpRequestProgressEvent>> Handlers { get; set; }


	}
}

