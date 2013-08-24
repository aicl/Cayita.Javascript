using System;
using Cayita.JData;
using jQueryApi;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi.UI.Widgets;

namespace Cayita.Demo
{
	[IgnoreNamespace]
	public class DemoMix
	{
		public DemoMix ()
		{
		}

		public static void Execute(Atom parent){

			var store = new Store<MyRecord> ();
			store.LastOption.LocalPaging=true;
			Firebug.Console.Log ("store", store);

			store.Add (MyRecord.Person("Angel Ignacio", "Colmenares", 47));
			store.Add (MyRecord.Person("Claudia", "Espinel", 44));
			store.Add (MyRecord.Person("Billy", "Espinel", 3));

			foreach (var r in store) {
				Firebug.Console.Log ("record", r.Name);
			}

			Firebug.Console.Log ("id ", store.IdProperty);
			Firebug.Console.Log ("id ", store.Count);
			Firebug.Console.Log ("id ", store[0].Age);

			var api = new StoreApi<MyRecord> ();
			Firebug.Console.Log ("st.ReadApi", api.ReadApi);

			api.ReadMethod = "LEER";
			Firebug.Console.Log ("st.ReadApi", api.ReadApi);

			api.ReadMethod = "";
			Firebug.Console.Log ("st.ReadApi", api.ReadApi);

			api.Url = "";
			Firebug.Console.Log ("st.ReadApi", api.ReadApi);

			api.ReadMethod = "LEER";
			Firebug.Console.Log ("st.ReadApi", api.ReadApi);

			api.CreateApiFn = () =>  "Esta es mi createApiFn";
			Firebug.Console.Log ("st.CreateApi", api.CreateApi);


			var work = jQuery.Select ("#work").Empty ();

			var countryStore1 = new MyCountryStore (); 
			var config1 = new MyCountrySearchBoxConfig (); 

			var sb1 = new SearchBox<MyCountry> (countryStore1,  MyCountryStore.DefineColumnsWithFlags (), config1);

			sb1.LocalFilter = (rec,v) => rec.Name.ToUpper ().StartsWith (v.ToUpper());
			work.Append (sb1);

			sb1.RowSelected += (sb, sr) => {  
				if (sr != null)  
					("selected: {0}-{1} ".Fmt(sb.IndexValue, sb.TextValue)).LogInfo ();
				else  
					"nothing selected".LogInfo ();  
			};

			countryStore1.Read ();


			var countryRemote =new MyCountryStore (o=>{
				o.LocalPaging=false;
				o.PageNumber=null;
				o.PageSize=null;
			}); 

			var sb2 = new SearchBox<MyCountry> (countryRemote,  MyCountryStore.DefineColumnsWithFlags (), config1);
			work.Append (sb2);


			var sp = new StorePager<MyRecord> (store);
			Firebug.Console.Log("--------Test sp.Update: ", store.TotalCount, store.Count);
			sp.Update ();
			work.Append (sp);

			var bi = new ButtonIcon ("iconic-home");
			bi.AddClass ("button-large");
			work.Append (bi);

			var x = MyRecord.Person ();
			var t = new Table<MyRecord> (); 
			t.AddRow (x);
			Firebug.Console.Log (t);

			work.Append (t);

			var grid = new Grid<MyRecord> (store);
			grid.RowClicked += (st, r) => {Firebug.Console.Log("handler1", r);};
			grid.RowClicked += (st, r) => {Firebug.Console.Log("handler2", r);};

			grid.KeyDown += (st, k) => {Firebug.Console.Log("keydonw",k);};
			work.Append (grid);



			var b1 = new Button ("Bootbox.Alert");
			b1.Clicked+= (e) => Bootbox.Alert ("Mi primer mensage", ()=>Window.Alert("alert callback"));
			work.Append (b1);

			var b2 = new Button ("Bootbox.Confirm");
			b2.Clicked+= (e) => Bootbox.Confirm ("Mi primer Confirm", (c)=>Window.Alert("confirm callback "+c));
			work.Append (b2);


			var b3 = new Button ("Bootbox.Prompt");
			b3.Clicked+= (e) => Bootbox.Prompt ("Mi primer Prompt", (s)=>Window.Alert("prompt callback "+s));
			work.Append (b3);


			var b4 = new Button ("Bootbox.Dialog I" );
			b4.Clicked+= (e) => Bootbox.Dialog ("Mi Dialog I");
			work.Append (b4);

			var b5 = new Button ("Bootbox.Dialog II");
			b5.Clicked+= (e) => Bootbox.Dialog ("Mi Dialog II",  new BootboxHandler {
				Callback=()=>Window.Alert("Dialog callback"),
				Label="My custom Label"
			});
			work.Append (b5);

			var b6= new Button ("Bootbox.Dialog III");
			b6.Clicked+= (e) => Bootbox.Dialog ("Mi Dialog III",  new BootboxHandler {
				Callback=()=>Window.Alert("Dialog callback"),
				Label="Go"
			},
			new BootboxOptions{Header="El titulo grande"});
			work.Append (b6);



			var form = new Form ();

			form.Append (new TextField{
				Name="Name",
				LabelText="Nombre"
			});


			form.Append (new TextField{
				Name="First",
				LabelText="Apellido",
			});


			form.Append (new IntField{
				Name="Age",
				LabelText="Edad",
			});


			form.Append ( new NumericField{
				Name="Average",
				LabelText="Promedio",
			});


			var lang = new RadioGroup<string>();
			lang.Name="FavouriteLanguage";
			lang.Text="Programming Language";
			lang.Add("Java", "Java 6");
			lang.Add("Basic", "Basic");
			lang.Add("CSharp", "C #");
			lang.Add("Fortran", "FORTRAN");
			form.Append(lang);


			form.Append (new CheckField{
				Text="Active?",
				Name="Active",
			});

			var opt1 = new CheckGroup<int> ();
			opt1.Name="Ids";
			opt1.Add(1, "Opcion 1");
			opt1.Add(2, "Opcion 2");
			opt1.Add(3, "Opcion 3");
			opt1.Add(4, "Opcion 4");
			opt1.Add(5, "Opcion 5");
			opt1.Add(6, "Opcion 6");
			form.Append(opt1);

			var opt2 = new SelectInput<int> ();
			opt2.Name="Selection";
			opt2.Add(1, "Opcion 1");
			opt2.Add(2, "Opcion 2");
			opt2.Add(3, "Opcion 3");
			opt2.Add(4, "Opcion 4");
			opt2.Add(5, "Opcion 5");
			opt2.Add(6, "Opcion 6");
			form.Append(opt2);

			var sel1 =  new SelectInput<int> ();
			sel1.Name="MultipleSelection";
			sel1.Multiple=true;
			sel1.Add(1, "Opcion 1");
			sel1.Add(2, "Opcion 2");
			sel1.Add(3, "Opcion 3");
			sel1.Add(4, "Opcion 4");
			sel1.Add(5, "Opcion 5");
			sel1.Add(6, "Opcion 6");

			form.Append(sel1);

			var dob = new DateInput ();
			dob.Name = "DoB"; 
			form.Append (dob);


			var ll = new DateInput ();
			ll.Name = "LastLog";
			form.Append (ll);

			var mr = MyRecord.Person ();
			form.PopulateFrom (mr);
			work.Append (form);


			var pb = new Button ("Click me !");
			pb.Clicked+= (e) => {
				form.Populate(mr);
				Firebug.Console.Log("datos ", mr); 
				AlertFn.Info(form, "algun mensaje",delay:5000);
				AlertFn.PageAlert(form, "Page alert", "success", 15000);

			};

			work.Append (pb);

			//
			var nl = new NavList ();
			nl.Header = "Soy un Nav List";
			nl.Add ("1", "Primer item");
			nl.Add ("2", "Segundo item", handler:e => Firebug.Console.Log ("click", e), iconClass:"icon-envelope");
			nl.Add (new NavItem{
				Value="3",Text="Tercer Item", Handler= e=>nl.Header="Soy un NaList click 3",IconClass="iconic-home"});

			nl.Add ("4", "Cuarto Item", e => {
				Firebug.Console.Log("click 4", e);
				nl.Header= e.CurrentTarget.As<NavItem>().Value+ e.CurrentTarget.As<NavItem>().Text;

			});

			nl.Add ("5", "Quinto Item", e => {
				Firebug.Console.Log("click 5", e);
				nl.Disable("2");
			});

			work.Append (nl);

			nl.Selected += e => {
				Firebug.Console.Log("nl algun item ha sido seleccionado", e.CurrentTarget);
			};



			var nb = new NavBar ();
			var i = 0;
			nb.Add ("1", "Nav bar 1", e =>{
				Firebug.Console.Log ("Nav bar clicked", e);
				nb.BrandText="Hello Brand " + (++i).ToString() ;
				if(i==1) 
					nb.BrandClicked+= (ev) => Firebug.Console.Log("Brand Clicked ev", ev);
			});

			nb.Add ("2", "Toggle Inverse", e => {
				nb.Inverse=!nb.Inverse;
			});


			var dd = new DropdownMenu ();
			dd.Text = "Dropdown..";
			dd.Nav.Add ("Item 1 in dd");
			dd.Nav.Add ("Item 2 in dd");

			var sm = new DropdownSubmenu ();
			sm.Text="Sub Menu";
			sm.Nav.Add (" 1 en submenu");
			sm.Nav.Add (" 2 en submenu");
			dd.Nav.Add (sm);

			nb.Add (dd);

			var f = new Form ();
			f.ClassName="navbar-search";
			var tib = new TextInput ();
			tib.ClassName = "navbar-query";
			f.Append (tib);
			nb.AddElement (f);

			work.Append (nb);

			nb.BrandClicked+= (e) => Firebug.Console.Log("Brand Clicked si se vera!!", e);

			nb.Selected+= (e) =>  Firebug.Console.Log("Algun item del navbar", e);

			var nd = new DateTime ();
			Firebug.Console.Log ("net date",nd);

			var jd = new JsDate ();

			Firebug.Console.Log ("js date",jd);


			var ff = new FileField ();
			work.Append (ff);

			var ifile = new ImgField ();

			ifile.Thumbnail.Popover (new PopoverOptions{Content="hello popover ", Title="my Title", Placement="top"});

			work.Append (ifile);

			var tf = new TextField ("TEXTField");
			tf.Text = "My label";
			work.Append (tf);

			var di = new DateInput ();
			di.Value = new DateTime ();
			work.Append(di);

			var df = new DateField ( new DatePickerOptions{DateFormat="dd.mm.yy"});
			work.Append (df);

			var nf = new NumericField ("NumericField", "digite su edad");
			nf.Value = 12;
			work.Append (nf);


			var cbf = new CheckField ("MyName", "Accept ?");
			work.Append (cbf);

			var mf = new TextField ();
			mf.PrependAddOn (new CssIcon("icon-envelope"));
			mf.AppendAddOn(  new Button{Text="Hello world"});

			work.Append (mf);

			var cbg = new CheckGroup<int> ();
			cbg.Add (new CheckOption<int>{Value=1, Text="Opcion 1"});
			cbg.Add (new CheckOption<int>{Value=2, Text="Opcion 2"});
			cbg.Add (new CheckOption<int> (3, "Opcion 2", true));
			cbg.Add (4, "Opcion4");
			cbg.Add (5, true);
			cbg.Add (6);
			work.Append (cbg);

			var rdg = new RadioGroup<int> ();
			rdg.Name = "MyRadio";
			rdg.Add( new RadioOption<int>{Value=1, Text="Opcion 1"});
			rdg.Add( new RadioOption<int>{Value=2, Text="Opcion 2"});
			rdg.Add (new RadioOption<int>(3, "Opcion 3"));
			rdg.Add (4, "Radio 4");
			rdg.Add (5 );
			rdg.Add (6,true );

			work.Append (rdg);

			var cbg1 = new CheckGroup<int> ();
			cbg1.Add (new CheckOption<int>{Value=1, Text="Opcion 1"});
			cbg1.Add (new CheckOption<int>{Value=2, Text="Opcion 2"});
			cbg1.Add (new CheckOption<int> (3, "Opcion 2", true));
			cbg1.Add (4, "Opcion4");
			cbg1.Add (5, true);
			cbg1.Add (6);
			cbg1.Checked += e => {
				var g = e.CurrentTarget.As<CheckOption<int>>();
				cbg.Check(g.Value, g.Checked);
				rdg.Check(g.Value, g.Checked);
			};
			work.Append (cbg1);

			cbg1.On ("check", e => Firebug.Console.Log("otro cambio", e), UI.OptionSelector);

			string[] options = new string[] { "Uno", "Dos", "Tres" };
			var cbg2 = new CheckGroup<string> ();
			cbg2.Load (options);
			work.Append (cbg2);


			var si = new SelectInput<int> ();
			si.Add( o=> {o.Text="Opcion 1"; o.Value=1; });
			si.Add( o=> {o.Text="Opcion 2"; o.Value=2; });
			si.Add( o=> {o.Text="Opcion 3"; o.Value=3; });
			si.Add( o=> {o.Text="Opcion 4"; o.Value=4; });
			si.Changed += e => {
				var s = e.CurrentTarget.As<SelectInput<int>>();
				Firebug.Console.Log("select change..", s.Value,
				                    s.SelectedOption);
			};

			work.Append (si);

			var s2 = new SelectInput<string> ();
			s2.Multiple = true;
			s2.Add ("La Primera");
			s2.Add ("La Segunda");
			s2.Add ("La Tercera");
			s2.Add ("La IV");
			s2.Add ("La V");
			s2.Add ("Todas");
			s2.Clicked+= e => {

				var s = e.CurrentTarget.As<SelectInput<string>>();
				Firebug.Console.Log("select change..", s.Value,
				                    s.Selected);
			};
			work.Append (s2);


			var cb1 = new CheckInput ();
			work.Append (cb1);

			var r1 = new RadioInput ();
			work.Append (r1);


			cb1.Changed+=e=>{
				var c = e.Target.As<CheckInput>();
				r1.Checked= !c.Checked;
			};


			var a = new Atom("label");
			a.Text = "Hello World";
			work.Append (a);
			Firebug.Console.Log (a);
			Firebug.Console.Log (a.Text);

			var b =new  Atom("label");

			b.SetTextFn((e,v)=>{
				e.InnerHTML=v;
			});

			b.GetTextFn(e=> e.InnerHTML);

			b.Text = "Hola Mundo !!!";
			work.Append (b);
			Firebug.Console.Log ("b", b);
			Firebug.Console.Log ("b.Text", b.Text);


			var label = new Label ();
			label.InnerHTML = "HOla soy un label";
			label.Text = "Soy el Text de este label";
			label.For = "SomeField";
			work.Append (label);

			var cg1 = new ControlGroup ();
			cg1.LabelText = "Soy un Control group";
			cg1.LabelCssText= "color:red;";
			cg1.Style.BackgroundColor = "blue";
			cg1.Label.For = "ElIdDeAlgunInput";
			work.Append (cg1);
			Firebug.Console.Log (cg1);
			Firebug.Console.Log (cg1.Label);
			Firebug.Console.Log (cg1.Controls);

			var anchor1 = new Anchor ();
			anchor1.Text = "anchor1";
			work.Append (anchor1);
			Firebug.Console.Log (anchor1);

			var anchor2 = new Anchor ("link");
			anchor2.Text = "anchor2";
			work.Append (anchor2);
			Firebug.Console.Log (anchor2);

			var anchor3 = new Anchor ("link", "#work");
			anchor3.Text = "anchor3";
			work.Append (anchor3);
			Firebug.Console.Log (anchor3);

			var anchor4 = new Anchor ("link");
			anchor4.Href = "#work";
			anchor4.Text = "anchor4";
			work.Append (anchor4);
			Firebug.Console.Log (anchor4);


			var ni = new TextInput ();
			ni.Value = "12";

			work.Append (ni);
			Firebug.Console.Log ("int input", ni, ni.Value);

			var nni = new NullableNumericInput ();
			nni.Value = 12;
			nni.Settings.MaxValue = 100;
			nni.Settings.MinValue = 0;
			work.Append (nni);


			var numeric = new NumericInput ();
			work.Append (numeric);
			Firebug.Console.Log ("numeric settings", numeric.Settings);

			anchor4.Clicked += e => {
				e.PreventDefault ();
				Firebug.Console.Log ("anchor 4 clicked", e.Target);
				nni.Value = 20;
			};

			numeric.Changed += e => {
				Firebug.Console.Log ("numeric changed", e.Target, e.Target.As<NumericInput>().Value);
				;
			};

		}
	}


	[PreserveMemberCase]
	public class MyRecord:Record
	{
		static int id=0;

		public MyRecord():base(){
			Ids = new List<int> ();
			MultipleSelection = new List<int> ();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string First { get;set;}
		public int  Age { get;set;}
		public decimal Average { get; set; }
		public string FavouriteLanguage { get; set; }
		public bool Active { get; set; }
		public List<int> Ids { get; set; }
		public int Selection { get; set; }
		public List<int> MultipleSelection { get; set; }

		public DateTime DoB { get; set; }
		public DateTime LastLog { get; set; }
		public DateTime? Nullable { get; set; }

		public void SomeMethod(){
		}


		public static MyRecord Person(string name="NoName", string first= "NoFirst", int age=0 ){
			var mr = new MyRecord ();
			mr.Id = ++MyRecord.id;
			mr.Name = name;
			mr.First = first;
			mr.Age = age;
			mr.Average = 123456.99m;
			mr.FavouriteLanguage = "CSharp";
			mr.Active = true;
			mr.Ids.Add (1);
			mr.Ids.Add (3);
			mr.Ids.Add (4);
			mr.Ids.Add (6);
			mr.Selection = 3;
			mr.MultipleSelection.Add (2);
			mr.MultipleSelection.Add (3);
			mr.MultipleSelection.Add (5);
			mr.DoB = new DateTime (1966, 11, 25);

			return mr;
		}

	}


	[PreserveMemberCase]  
	public class MyCountry:Record 
	{  
		public MyCountry (){}  
		public string Code { get; set; }  
		public string Name { get; set; }  
	}




	public class MyCountrySearchBoxConfig:SearchBoxConfig
	{  
		public MyCountrySearchBoxConfig()  
		{  
			Placeholder="type country name";  
			TextField="Name";  
			ResetButton=true;  
			MinLength = 1;
		}  
	}  


	public  class MyCountryStore:Store<MyCountry> 
	{
		public  MyCountryStore (Action<ReadOptions> options=null)
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

		public static List<TableColumn<MyCountry>> DefineColumns()  
		{  
			List<TableColumn<MyCountry>> columns= new List<TableColumn<MyCountry>>();  
			columns.Add (new TableColumn<MyCountry> ("Name","Country"));  
			return columns;  
		}  

		public static List<TableColumn<MyCountry>> DefineColumnsWithFlags()  
		{  
			List<TableColumn<MyCountry>> columns= new List<TableColumn<MyCountry>>();  
			columns.Add (new TableColumn<MyCountry> ("Name", "Country", (f,c) => {  
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

