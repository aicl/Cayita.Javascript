using System.Runtime.CompilerServices;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class Paragraph:Atom
	{
		[InlineCode("Cayita.UI.Atom('p',null,null)")]
		public Paragraph(){}

		[InlineCode("Cayita.UI.Atom('p',null,{className})")]
		public Paragraph(string className){}

	}
}

