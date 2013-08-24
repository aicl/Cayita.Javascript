using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Cayita.JData;
using jQueryApi;


namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoSearchBox
	{
		public DemoSearchBox ()
		{
		}

		public static void Execute(Atom parent)
		{

			var countryStore1 = new CountryStore (); 
			var sb1 = new SearchBox<Country> (countryStore1,  
			                                  CountryStore.DefineColumnsWithFlags (), 
			                                  new CountrySearchBoxConfig ());

			sb1.LocalFilter = (rec,v) => rec.Name.ToUpper ().StartsWith (v.ToUpper());

			sb1.RowSelected += (sb, sr) => {  
				if (sr != null)  
					("selected: {0}-{1} ".Fmt(sb.IndexValue, sb.TextValue)).LogInfo ();
				else  
					"nothing selected".LogInfo ();  
			};

			countryStore1.Read ();

			parent.JQuery.Append ("Local filter I".Header(4)).Append (sb1);


			var countryStore2 = new CountryStore (); 
			var sb2 = new SearchBox<Country> (countryStore2,  
			                                   new CountrySearchBoxConfig {SearchButton=true});

			sb2.LocalFilter = (rec,v) => rec.Name.ToUpper ().StartsWith (v.ToUpper());

			sb2.RowSelected += (sb, sr) => {  
				if (sr != null)  
					("selected: {0}-{1} ".Fmt(sb.IndexValue, sb.TextValue)).LogInfo ();
				else  
					"nothing selected".LogInfo ();  
			};

			Firebug.Console.Log ("countrystore2 reading");
			countryStore2.Read ();
			Firebug.Console.Log ("countrystore2 read");

			parent.JQuery.Append ("Local filter II".Header(4)).Append (sb2);


			var countryRemote =new CountryStore (o=>{
				o.LocalPaging=false;
				o.PageNumber=null; //no paged for this demo 
			}); 

			var sb3 = new SearchBox<Country> (countryRemote,  CountryStore.DefineColumnsWithFlags (),
			                                    new CountrySearchBoxConfig());

			parent.JQuery.Append ("Remoter filter".Header(4)).Append (sb3);


			parent.Append ("C# code".Header(3));

			var rq =jQuery.GetData<string> ("code/demosearchbox.html");
			rq.Done (s=> {
				var code=new Div();
				code.InnerHTML= s;
				parent.Append(code);
			});

		}
	}

	[PreserveMemberCase]  
	public class Country:Record 
	{  
		public Country (){}  
		public string Code { get; set; }  
		public string Name { get; set; }  
	}


	public class CountrySearchBoxConfig:SearchBoxConfig
	{  
		public CountrySearchBoxConfig()  
		{  
			Placeholder="type country name";  
			TextField="Name";  
			ResetButton=true;  
			MinLength = 1;
		}  
	}  


	public  class CountryStore:Store<Country> 
	{
		public  CountryStore (Action<ReadOptions> options=null)
		{
			IdProperty = "Code";
			Api.Url="json/countriesResponse.json"; 
			Api.DataProperty="Countries";  
			Api.ReadMethod = "";

			LastOption.PageNumber = 0;
			LastOption.PageSize = 10;
			LastOption.LocalPaging = true;
			if (options != null)  
				options.Invoke (LastOption);

			var baseReadFn = ReadFn;
			ReadFn=ro=>{
				Firebug.Console.Log("0. custom readFn");
				return baseReadFn(ro).Done(t=>{ // mimic server side 
					Firebug.Console.Log("1. custom read.....", LastOption);
					var qp = LastOption.Request;
					if( qp.ContainsKey("Name") )  
					{
						Firebug.Console.Log("2. custom read.....", qp);
						var n = qp["Name"].ToString();  
						("Request: "+ n ).LogInfo();  
						Filter(f=> f.Name.ToUpper().StartsWith(  n.ToUpper() ) );  
					}  
				});  ;
			};

		}

		public static List<TableColumn<Country>> DefineColumns()  
		{  
			List<TableColumn<Country>> columns= new List<TableColumn<Country>>();  
			columns.Add (new TableColumn<Country> ("Name","Country"));  
			return columns;  
		}  

		public static List<TableColumn<Country>> DefineColumnsWithFlags()  
		{  
			List<TableColumn<Country>> columns= new List<TableColumn<Country>>();  
			columns.Add (new TableColumn<Country> ("Name", "Country", (f,c) => {  
				var par = new Paragraph();
				var img = new Image();
				img.Src="img/flags/" + f.Code.ToLower () + ".png";  
				img.Style.MarginRight = "8px";  
				par.Append(img);
				par.Append(f.Name);
				c.Append(par);

			}));  

			return columns;  
		}  

	}

}

