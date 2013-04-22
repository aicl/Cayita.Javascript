using System;
using System.Html;
using Cayita.UI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Cayita.Javascript
{
	[IgnoreNamespace]
	public class DemoSearchBox
	{
		public DemoSearchBox ()
		{
		}


		public static void Execute(Element parent)
		{
			"SearchBox Local I".Header (3).AppendTo (parent);
			var countryStore1 = new CountryStore (o => o.LocalPaging = true);
			var config1 = new CountrySearchBoxConfig{
				LocalFilter= (t,v)=> t.Name.ToUpper().StartsWith(v.ToUpper()),
				OnRowSelectedHandler=(sb, sr)=>{
					if(sr!=null)
							("selected: "+ sr.Record.Code+" " +sr.Record.Name).LogInfo();
					else
						"nothing selected".LogInfo();
				}
			};

			new Div (div => {
				div.ClassName = "bs-docs-example";
				new SearchBox<Country> (div, countryStore1, config1, DefineColumnsWithFlags ());

			}).AppendTo (parent);
			countryStore1.Read ();

	
			"SearchBox Local II".Header (3).AppendTo (parent);
			var countryStore2 = new CountryStore (o=>o.LocalPaging=true);
			var config2 = new CountrySearchBoxConfig{
				LocalFilter= (t,v)=> t.Name.ToUpper().StartsWith(v.ToUpper()),
				SearchButton=true,
			};

			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore2, config2);

			}).AppendTo(parent);
			countryStore2.Read ();

			
			"SearchBox Remote".Header (3).AppendTo (parent);
			var countryStore3 = new CountryStore (o => {
				o.PageSize = null;  // no paged for this demo 
				o.PageNumber = null;
			});
			var config3 = new CountrySearchBoxConfig{MinLength=1};

			new Div( div=>{
				div.ClassName="bs-docs-example";
				new SearchBox<Country>(div, countryStore3,  config3, DefineColumns());
				
			}).AppendTo(parent);

			"CSharp Code:".Header (3).AppendTo (parent);
			ShowCode (parent);
			ShowCountry (parent);
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
				new Paragraph (c, p => {							
					p.Append (new Image (i => {
						i.Src = "img/flags/" + f.Code.ToLower () + ".png";
						i.Style.MarginRight = "8px";
					}));
					p.Append (f.Name);
				});
			}));

			return columns;
		}

		class CountrySearchBoxConfig:SearchBoxConfig<Country>
		{
			public CountrySearchBoxConfig()
			{
				PlaceHolder="type country name";
				TextField="Name";
				IndexField="Code";
				ResetButton=true;
			}
		}



		static void ShowCode (Element parent)
		{
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;Execute(Element&nbsp;parent)&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""SearchBox&nbsp;Local&nbsp;I""</span><span>.Header&nbsp;(3).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;countryStore1&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;CountryStore&nbsp;(o&nbsp;=&gt;&nbsp;o.LocalPaging&nbsp;=&nbsp;</span><span class=""keyword"">true</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;config1&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;CountrySearchBoxConfig{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LocalFilter=&nbsp;(t,v)=&gt;&nbsp;t.Name.ToUpper().StartsWith(v.ToUpper()),&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnRowSelectedHandler=(sb,&nbsp;sr)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">if</span><span>(sr!=null)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class=""string"">""selected:&nbsp;""</span><span>+&nbsp;sr.Record.Code+</span><span class=""string"">""&nbsp;""</span><span>&nbsp;+sr.Record.Name).LogInfo();&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">else</span><span>&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""nothing&nbsp;selected""</span><span>.LogInfo();&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div&nbsp;(div&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;div.ClassName&nbsp;=&nbsp;<span class=""string"">""bs-docs-example""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SearchBox&lt;Country&gt;&nbsp;(div,&nbsp;countryStore1,&nbsp;config1,&nbsp;DefineColumnsWithFlags&nbsp;());&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;countryStore1.Read&nbsp;();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""SearchBox&nbsp;Local&nbsp;II""</span><span>.Header&nbsp;(3).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;countryStore2&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;CountryStore&nbsp;(o=&gt;o.LocalPaging=</span><span class=""keyword"">true</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;config2&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;CountrySearchBoxConfig{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LocalFilter=&nbsp;(t,v)=&gt;&nbsp;t.Name.ToUpper().StartsWith(v.ToUpper()),&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SearchButton=<span class=""keyword"">true</span><span>,&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;div=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;div.ClassName=<span class=""string"">""bs-docs-example""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SearchBox&lt;Country&gt;(div,&nbsp;countryStore2,&nbsp;config2);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}).AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;countryStore2.Read&nbsp;();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""SearchBox&nbsp;Remote""</span><span>.Header&nbsp;(3).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;countryStore3&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;CountryStore&nbsp;(o&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o.PageSize&nbsp;=&nbsp;null;&nbsp;&nbsp;<span class=""comment"">//&nbsp;no&nbsp;paged&nbsp;for&nbsp;this&nbsp;demo&nbsp;</span><span>&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o.PageNumber&nbsp;=&nbsp;null;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;config3&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;CountrySearchBoxConfig{MinLength=1};&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(&nbsp;div=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;div.ClassName=<span class=""string"">""bs-docs-example""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;SearchBox&lt;Country&gt;(div,&nbsp;countryStore3,&nbsp;&nbsp;config3,&nbsp;DefineColumns());&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}).AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""string"">""CSharp&nbsp;Code:""</span><span>.Header&nbsp;(3).AppendTo&nbsp;(parent);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;ShowCode&nbsp;(parent);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">static</span><span>&nbsp;List&lt;TableColumn&lt;Country&gt;&gt;&nbsp;DefineColumns()&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TableColumn&lt;Country&gt;&gt;&nbsp;columns=&nbsp;<span class=""keyword"">new</span><span>&nbsp;List&lt;TableColumn&lt;Country&gt;&gt;();&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;columns.Add&nbsp;(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;Country&gt;&nbsp;(</span><span class=""string"">""Name""</span><span>,</span><span class=""string"">""Country""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;columns;&nbsp;&nbsp;</span></span></li><li class=""""><span>}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">static</span><span>&nbsp;List&lt;TableColumn&lt;Country&gt;&gt;&nbsp;DefineColumnsWithFlags()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TableColumn&lt;Country&gt;&gt;&nbsp;columns=&nbsp;<span class=""keyword"">new</span><span>&nbsp;List&lt;TableColumn&lt;Country&gt;&gt;();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;columns.Add&nbsp;(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;Country&gt;&nbsp;(</span><span class=""string"">""Name""</span><span>,&nbsp;</span><span class=""string"">""Country""</span><span>,&nbsp;(f,c)&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Paragraph&nbsp;(c,&nbsp;p&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Append&nbsp;(<span class=""keyword"">new</span><span>&nbsp;Image&nbsp;(i&nbsp;=&gt;&nbsp;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Src&nbsp;=&nbsp;<span class=""string"">""img/flags/""</span><span>&nbsp;+&nbsp;f.Code.ToLower&nbsp;()&nbsp;+&nbsp;</span><span class=""string"">"".png""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.Style.MarginRight&nbsp;=&nbsp;<span class=""string"">""8px""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;p.Append&nbsp;(f.Name);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}));&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;columns;&nbsp;&nbsp;</span></span></li><li class=""""><span>}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">class</span><span>&nbsp;CountrySearchBoxConfig:SearchBoxConfig&lt;Country&gt;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;CountrySearchBoxConfig()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PlaceHolder=<span class=""string"">""type&nbsp;country&nbsp;name""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextField=<span class=""string"">""Name""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IndexField=<span class=""string"">""Code""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResetButton=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">public static void Execute(Element parent)
{
	""SearchBox Local I"".Header (3).AppendTo (parent);
	var countryStore1 = new CountryStore (o =&gt; o.LocalPaging = true);
	var config1 = new CountrySearchBoxConfig{
		LocalFilter= (t,v)=&gt; t.Name.ToUpper().StartsWith(v.ToUpper()),
		OnRowSelectedHandler=(sb, sr)=&gt;{
			if(sr!=null)
				(""selected: ""+ sr.Record.Code+"" "" +sr.Record.Name).LogInfo();
			else
				""nothing selected"".LogInfo();
		}
	};
	
	new Div (div =&gt; {
		div.ClassName = ""bs-docs-example"";
		new SearchBox&lt;Country&gt; (div, countryStore1, config1, DefineColumnsWithFlags ());
		
	}).AppendTo (parent);
	countryStore1.Read ();
	
	
	""SearchBox Local II"".Header (3).AppendTo (parent);
	var countryStore2 = new CountryStore (o=&gt;o.LocalPaging=true);
	var config2 = new CountrySearchBoxConfig{
		LocalFilter= (t,v)=&gt; t.Name.ToUpper().StartsWith(v.ToUpper()),
		SearchButton=true,
	};
	
	new Div( div=&gt;{
		div.ClassName=""bs-docs-example"";
		new SearchBox&lt;Country&gt;(div, countryStore2, config2);
		
	}).AppendTo(parent);
	countryStore2.Read ();
	
	
	""SearchBox Remote"".Header (3).AppendTo (parent);
	var countryStore3 = new CountryStore (o =&gt; {
		o.PageSize = null;  // no paged for this demo 
		o.PageNumber = null;
	});
	var config3 = new CountrySearchBoxConfig{MinLength=1};
	
	new Div( div=&gt;{
		div.ClassName=""bs-docs-example"";
		new SearchBox&lt;Country&gt;(div, countryStore3,  config3, DefineColumns());
		
	}).AppendTo(parent);
	
	""CSharp Code:"".Header (3).AppendTo (parent);
	ShowCode (parent);
	
}


public static List&lt;TableColumn&lt;Country&gt;&gt; DefineColumns()
{
	List&lt;TableColumn&lt;Country&gt;&gt; columns= new List&lt;TableColumn&lt;Country&gt;&gt;();
	columns.Add (new TableColumn&lt;Country&gt; (""Name"",""Country""));
	return columns;
}

public static List&lt;TableColumn&lt;Country&gt;&gt; DefineColumnsWithFlags()
{
	List&lt;TableColumn&lt;Country&gt;&gt; columns= new List&lt;TableColumn&lt;Country&gt;&gt;();
	columns.Add (new TableColumn&lt;Country&gt; (""Name"", ""Country"", (f,c) =&gt; {
		new Paragraph (c, p =&gt; {							
			p.Append (new Image (i =&gt; {
				i.Src = ""img/flags/"" + f.Code.ToLower () + "".png"";
				i.Style.MarginRight = ""8px"";
			}));
			p.Append (f.Name);
		});
	}));
	
	return columns;
}

class CountrySearchBoxConfig:SearchBoxConfig&lt;Country&gt;
{
	public CountrySearchBoxConfig()
	{
		PlaceHolder=""type country name"";
		TextField=""Name"";
		IndexField=""Code"";
		ResetButton=true;
	}
}</textarea></div>");

		}


		public static void ShowCountry(Element parent){
			parent.Append (@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-cpp""><li class=""alt""><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""""><span>[Serializable]&nbsp;&nbsp;</span></li><li class=""alt""><span>[PreserveMemberCase]&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;Country&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;Country&nbsp;(){}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;string&nbsp;Code&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;string&nbsp;Name&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;</span></li><li class=""alt""><span>[IgnoreNamespace]&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;CountryStore:Store&lt;Country&gt;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;CountryStore(Action&lt;ReadOptions&gt;&nbsp;options=null):base()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ro&nbsp;=&nbsp;GetLastOption&nbsp;();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ro.PageNumber&nbsp;=&nbsp;0;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ro.PageSize&nbsp;=&nbsp;10;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">if</span><span>&nbsp;(options&nbsp;!=&nbsp;null)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;options.Invoke&nbsp;(ro);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetIdProperty&nbsp;(<span class=""string"">""Code""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetReadApi(api=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;api.Url=<span class=""string"">""json/countriesResponse.json""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;api.DataProperty=<span class=""string"">""Countries""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;override&nbsp;IDeferred&lt;Country&gt;&nbsp;Read(Action&lt;ReadOptions&gt;&nbsp;options=null,&nbsp;</span><span class=""datatypes"">bool</span><span>&nbsp;clear=</span><span class=""keyword"">true</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;base.Read&nbsp;(options,&nbsp;clear)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Done(t=&gt;{&nbsp;<span class=""comment"">//&nbsp;mimic&nbsp;server&nbsp;side</span><span>&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;qp&nbsp;=&nbsp;GetLastOption().QueryParams;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">if</span><span>(&nbsp;qp.ContainsKey(</span><span class=""string"">""Name""</span><span>)&nbsp;)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;n&nbsp;=&nbsp;qp[<span class=""string"">""Name""</span><span>].ToString();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class=""string"">""Request:&nbsp;""</span><span>+&nbsp;n&nbsp;).LogInfo();&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Filter(f=&gt;&nbsp;f.Name.ToUpper().StartsWith(&nbsp;&nbsp;n.ToUpper()&nbsp;)&nbsp;);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">[IgnoreNamespace]
[Serializable]
[PreserveMemberCase]
public class Country
{
	public Country (){}
	public string Code { get; set; }
	public string Name { get; set; }
}

[IgnoreNamespace]
public class CountryStore:Store&lt;Country&gt;
{
	public CountryStore(Action&lt;ReadOptions&gt; options=null):base()
	{
		var ro = GetLastOption ();
		ro.PageNumber = 0;
		ro.PageSize = 10;
		
		if (options != null)
			options.Invoke (ro);
		
		SetIdProperty (""Code"");
		
		SetReadApi(api=&gt;{
			api.Url=""json/countriesResponse.json"";
			api.DataProperty=""Countries"";
		});
	}
	
	public override IDeferred&lt;Country&gt; Read(Action&lt;ReadOptions&gt; options=null, bool clear=true)
	{					
		return base.Read (options, clear)
			.Done(t=&gt;{ // mimic server side
				var qp = GetLastOption().QueryParams;
				if( qp.ContainsKey(""Name"") )
				{
					var n = qp[""Name""].ToString();
					(""Request: ""+ n ).LogInfo();
					Filter(f=&gt; f.Name.ToUpper().StartsWith(	n.ToUpper() ) );
				}
			});
	}
	
}
</textarea></div>");
		}

	}
}
