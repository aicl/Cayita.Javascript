using System;
using System.Runtime.CompilerServices;
using System.Net;

namespace Cayita.Net
{
	[IgnoreNamespace, Imported(ObeysTypeSystem = true)]
	public class XmlHttpRequestProgressEvent
	{
		[IntrinsicProperty]
		public bool Bubbles { get; set; }
		[IntrinsicProperty]
		public bool CancelBubble{get;set;}
		[IntrinsicProperty]
		public bool Cancelable {get;set;}
		[IntrinsicProperty]
		public XmlHttpRequest CurrentTarget {get;set;}
		[IntrinsicProperty]
		public bool DefaultPrevented{get;set;}
		[IntrinsicProperty]
		public int EventPhase{get;set;}
		[IntrinsicProperty]
		public bool LengthComputable{get;set;}
		[IntrinsicProperty]
		public long Loaded {get;set;}
		[IntrinsicProperty]
		public long Position {get;set;}
		[IntrinsicProperty]
		public bool ReturnValue{get;set;}
		[IntrinsicProperty]
		public XmlHttpRequest SrcElement {get;set;}
		[IntrinsicProperty]
		public XmlHttpRequest Target {get;set;}
		[IntrinsicProperty]
		public long TimeStamp{get;set;}
		[IntrinsicProperty]
		public long Total {get;set;}
		[IntrinsicProperty]
		public long TotalSize {get;set;}
		[IntrinsicProperty]
		public string Type {get;set;}
	}
}

