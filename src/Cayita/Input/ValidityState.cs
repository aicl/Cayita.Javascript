using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Object")]
	public class ValidityState
	{

		[IntrinsicProperty]
		public bool BadInput {
			get{ return false;}
		}
	

		[IntrinsicProperty]
		public bool CustomError {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool PatternMismatch {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool RangeOverflow {
			get{ return false;}
		}


		[IntrinsicProperty]
		public bool RangeUnderflow {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool StepMismatch {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool TooLong {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool TypeMismatch {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool Valid {
			get{ return false;}
		}

		[IntrinsicProperty]
		public bool ValueMissing {
			get{ return false;}
		}


	}
}

