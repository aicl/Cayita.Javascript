using System;
using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public class NumericOptions
	{
		[InlineCode("Cayita.Plugins.NumericOptions()")]
		public NumericOptions ()
		{
		}

		public decimal MaxValue {
			[InlineCode("{this}.vMax")]get;
			[InlineCode("{this}.vMax={value}")]set;

		}

		public decimal MinValue {
			[InlineCode("{this}.vMin")]get;
			[InlineCode("{this}.vMin={value}")]set;

		}
		/// <summary>
		/// Gets or sets the decimal places.
		/// </summary>
		/// <value>enter the number of decimal places
		/// Only needed if you want to override the number of decimal places that are set by the MinValue & MaxValue</value>
		public int DecimalPlaces {
			[InlineCode("{this}.mDec")]get;
			[InlineCode("{this}.mDec={value}")]set;

		}

		public string CurrencySymbol {
			[InlineCode("{this}.aSign")]get;
			[InlineCode("{this}.aSign={value}")]set;

		}

		/// <summary>
		/// Gets or sets the currency symbol placement.
		/// </summary>
		/// <value>The currency symbol placement: p=prefix, s=suffix</value>
		public string CurrencySymbolPlacement {
			[InlineCode("{this}.pSign")]get;
			[InlineCode("{this}.pSign={value}")]set;

		}

		public string ThousandSeparator{
			[InlineCode("{this}.aSep")]get;
			[InlineCode("{this}.aSep={value}")]set;
		}

		public string DecimalSeparator{
			[InlineCode("{this}.aDec")]get;
			[InlineCode("{this}.aDec={value}")]set;
		}

		/// <summary>
		/// Gets or sets the rounding method.
		/// </summary>
		/// <value>The rounding method:
		/// 'S'	Round-Half-Up Symmetric (default)
		/// 'A'	Round-Half-Up Asymmetric
		///	's'	 Round-Half-Down Symmetric (lower case s)
		///		'a'	 Round-Half-Down Asymmetric (lower case a)
		///		'B'	 Round-Half-Even "Bankers Rounding"
		///		'U'	 Round Up "Round-Away-From-Zero"
		///		'D'	 Round Down "Round-Toward-Zero" - same as truncate
		///		'C'	 Round to Ceiling "Toward Positive Infinity"
		///		'F'	 Round to Floor "Toward Negative Infinity"vv
		/// </value>
		public string RoundingMethod{
			[InlineCode("{this}.mRound")]get;
			[InlineCode("{this}.mRound={value}")]set;
		}
		/// <summary>
		/// Controls input display behavior : empty||zero||sign
		/// </summary>
		/// <value>'empty'	 allows input to be empty (no value) (default)
		/// 'zero' input field will have at least a zero value
		///	'sign' the currency symbol is always present</value>
		public string Empty{
			[InlineCode("{this}.wEmpty")]get;
			[InlineCode("{this}.wEmpty={value}")]set;
		}

		/// <summary>
		/// Controls if leading zeros are allowed: allow||deny||keep
		/// </summary>
		/// <value> 'allow' (default) ||  'deny' || 'keep'</value>
		public string LeadingZero{
			[InlineCode("{this}.lZero")]get;
			[InlineCode("{this}.lZero={value}")]set;
		}

	}
}

