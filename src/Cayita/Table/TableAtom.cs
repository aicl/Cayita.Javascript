using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Html;

namespace Cayita
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true), ScriptName ("Element")]
	public class TableAtom:Atom
	{
		[InlineCode("Cayita.UI.TableAtom()")]
		public TableAtom ()
		{
		}


		[IntrinsicProperty]
		public ElementCollection Cells
		{
			get
			{
				return null;
			}
		}
		[IntrinsicProperty]
		public ElementCollection Rows
		{
			get
			{
				return null;
			}
		}
		[IntrinsicProperty]
		public ElementCollection tBodies
		{
			get
			{
				return null;
			}
		}
		[IntrinsicProperty]
		public Element tFoot
		{
			get
			{
				return null;
			}
		}
		[IntrinsicProperty]
		public ElementCollection tHead
		{
			get
			{
				return null;
			}
		}

		[IntrinsicProperty]
		public Atom Body { 
			get {return null;}
		} 

		//
		// Methods
		//
		public void DeleteRow (int index=-1)
		{
		}



		public TableRowAtom GetFirstRow ()
		{
			return null;
		}


		public TableRowAtom GetLastRow ()
		{
			return null;
		}


		public TableRowAtom GetRowByIndex (int index)
		{
			return null;
		}


		public TableRowAtom InsertRow (int index=-1)
		{
			return null;
		}

		public TableRowAtom[] GetRows(){
			return null;
		}


	}
}

