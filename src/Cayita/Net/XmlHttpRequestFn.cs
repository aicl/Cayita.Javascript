using System;
using System.Net;
using Cayita.Net;
using System.Runtime.CompilerServices;
using System.Html;
using System.Collections.Generic;

namespace Cayita
{
	public static partial class Fn
	{

		public static  XmlHttpRequest AddEventListener(this XmlHttpRequest request,
			 XmlHttpRequestEvents type, Action<XmlHttpRequestProgressEvent> handler)
		{
			((dynamic)request).addEventListener (type, handler, false);
			return request;
		}

		public static  XmlHttpRequest RemoveEventListener(this XmlHttpRequest request,
			XmlHttpRequestEvents type, Action<XmlHttpRequestProgressEvent> handler)
		{
			((dynamic)request).removeEventListener (type, handler, false);
			return request;
		}


		public static XmlHttpRequest Send (this FormData fd, SendFormDataConfig config){
			var rq = new XmlHttpRequest ();
			rq.Open (config.Verb , config.Url);
			foreach (var h in config.Handlers)
				rq.AddEventListener (h.Key, h.Value);

			((dynamic)rq).send (fd);
			return rq;
		}

		[PreserveCase]
		internal static  SendFormDataConfig SendFormDataConfig()
		{
			return UI.Cast<SendFormDataConfig>(new { 
				verb="POST",
				handlers= new  Dictionary<XmlHttpRequestEvents,Action<XmlHttpRequestProgressEvent>> ()
			});

		}


	}
}

