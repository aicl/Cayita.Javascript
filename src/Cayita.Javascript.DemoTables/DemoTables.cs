using System.Runtime.CompilerServices;
using Cayita.Javascript.UI;
using System.Html;
using System.Collections.Generic;
using Cayita.Javascript.Plugins;

namespace Cayita.Javascript.DemoTables
{
	[IgnoreNamespace]
	public class DemoTables
	{
		public DemoTables (){}

		static UserGrid uGrid;
		static CustomerGrid cGrid;
		static UserForm uForm;

		public static void Execute(Element parent)
		{
			Document.CreateElement("h3").Text("CRUD").AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				uGrid= new UserGrid(div, new UserStore());
				uForm = new UserForm(div, GetLevelOptions());
			}).AppendTo(parent);

			uForm.GetCreateButton().Disabled=false;

			uForm.GetCreateButton().OnClick(evt=>{
				uGrid.SelectRow();
			});

			uForm.GetDestroyButton().OnClick(evt=>{
				uGrid.GetStore().Remove( uGrid.GetSelectedRow().Record );
			});

			uForm.Element().OnChange(e=>{
				uForm.GetSaveButton().Disabled=!uForm.Element().DataChanged();
			});

			uGrid.OnRowSelected+=( (g, sr)=>{
				uForm.GetSaveButton().Disabled=true;
				if(sr!=null)
				{
					uForm.Element().Load<User>( sr.Record);
					uForm.GetDestroyButton().Disabled=false;
				}
				else
				{
					uForm.Element().Load<User>( new User());
					uForm.GetDestroyButton().Disabled=true;
				}
			});

			var vo = new ValidateOptions()
				.SetSubmitHandler( form=>{
					var user = form.LoadTo<User>();
					uGrid.GetStore().Save(user);
					uGrid.SelectRow( user.Id);
				}).AddRule((r,m)=>{
					r.Element= uForm.Element().FindByName<InputElement>("Name");
					r.Rule.Required();
					r.Rule.Minlength(6);
					m.Required("write username");
					m.Minlength("min 6 chars");
				}).AddRule((r,m)=>{
					r.Element= uForm.Element().FindByName<InputElement>("Email");
					r.Rule.Email();
					m.Email("write a valid email address");
				}).AddRule((r,m)=>{
					r.Element= uForm.Element().FindByName<InputElement>("Rating");
					r.Element.AutoNumeric(new {mDec=0,  wEmpty= "zero"});
					r.Rule.Max(10000);
					r.Rule.Min(0);
				});

			uForm.Element().Validate(vo);

			uGrid.GetStore().Read();

			ShowCodeCrud (parent);


			Document.CreateElement("h3").Text("Paged Tables").AppendTo(parent);

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new Div(div, ct=>{
					ct.Style.MinHeight="300px";
					cGrid= new CustomerGrid(ct, new CustomerStore());
				});

				new StorePaging<Customer>(div, cGrid.GetStore());

			}).AppendTo(parent);

			cGrid.GetStore ().Read ();


			Document.CreateElement("h3").Text("Filters").AppendTo(parent);

			CustomerGrid gc= null;

			new Div(null, div=>{
				div.ClassName="bs-docs-example";
				new InputText(div, e=>{
					e.SetPlaceHolder("Country");
					e.On("change", evt=>{
						gc.GetStore().Filter( f=>f.Country.StartsWith(e.Value));
					});
				});

				new Div(div, ct=>{
					ct.Style.MinHeight="300px";
					gc = new CustomerGrid(ct, new CustomerStore());
					new StorePaging<Customer>(div, gc.GetStore());
					gc.GetStore ().Read ();
				});
				
			}).AppendTo(parent);
			


		}

		static  List<RadioItem> GetLevelOptions()
		{
			return 
				new List<RadioItem>(
					new RadioItem[]{
					new RadioItem{Text="A", Value="A"},
					new RadioItem{Text="B", Value="B"},
					new RadioItem{Text="C", Value="C"}
				});
		}

		static void ShowCodeCrud (Element parent)
		{
			new Div (null, div =>  {
				div.ClassName = "bs-docs-code";
				Document.CreateElement("h3").Text("User.cs").AppendTo(div);
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""""><span>[Serializable]&nbsp;&nbsp;</span></li><li class=""alt""><span>[PreserveMemberCase]&nbsp;&nbsp;</span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;User&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;User(){}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">int</span><span>&nbsp;Id&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;Name&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;Address&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;City&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;Email&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;DateTime&nbsp;DoB&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">bool</span><span>&nbsp;IsActive&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;Level&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;UserName&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">string</span><span>&nbsp;Password&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">int</span><span>&nbsp;Rating&nbsp;{&nbsp;</span><span class=""keyword"">get</span><span>;&nbsp;</span><span class=""keyword"">set</span><span>;&nbsp;}&nbsp;&nbsp;</span></span></li><li class=""""><span>}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>[IgnoreNamespace]&nbsp;&nbsp;</span></li><li class=""alt""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;UserStore:Store&lt;User&gt;&nbsp;&nbsp;</span></span></li><li class=""""><span>{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">int</span><span>&nbsp;id=0;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;UserStore():</span><span class=""keyword"">base</span><span>()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetReadApi(api=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;api.Url=<span class=""string"">""json/userResponse.json""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;api.Converters[<span class=""string"">""DoB""</span><span>]=&nbsp;(u)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;u.DoB.ConvertToDate();&nbsp;</span><span class=""comment"">//&nbsp;convert&nbsp;from&nbsp;&nbsp;""DoB"":""\/Date(13651200000+0000)\/""&nbsp;into&nbsp;date&nbsp;</span><span>&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;Save(User&nbsp;record)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">if</span><span>(&nbsp;record.Id==0)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;record.Id=--id;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(record);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">else</span><span>&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Replace(record);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">[IgnoreNamespace]
[Serializable]
[PreserveMemberCase]
public  class User
{
	public User(){}
	public int Id { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }
	public string City { get; set; }
	public string Email { get; set; }
	public DateTime DoB { get; set; }
	public bool IsActive { get; set; }
	public string Level { get; set; }
	public string UserName { get; set; }
	public string Password { get; set; }
	public int Rating { get; set; }
}

[IgnoreNamespace]
public class UserStore:Store&lt;User&gt;
{
	static int id=0;
	
	public UserStore():base()
	{
		SetReadApi(api=&gt;{
			api.Url=""json/userResponse.json"";
			api.Converters[""DoB""]= (u)=&gt;{
				return u.DoB.ConvertToDate(); // convert from  ""DoB"":""\/Date(13651200000+0000)\/"" into date 
			};
		});
	}
	
	public void Save(User record)
	{
		if( record.Id==0)
		{
			record.Id=--id;
			Add(record);
		}
		else
		{
			Replace(record);
		}
	}	
}</textarea></div>");
				Document.CreateElement("h3").Text("UserGrid.cs").AppendTo(div);
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;UserGrid:HtmlGrid&lt;User&gt;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;UserStore&nbsp;us;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;UserGrid&nbsp;(Element&nbsp;parent,&nbsp;UserStore&nbsp;store)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<span class=""keyword"">this</span><span>(parent,&nbsp;store,&nbsp;DefineColumns())&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;UserGrid&nbsp;(Element&nbsp;parent,&nbsp;UserStore&nbsp;store,&nbsp;List&lt;TableColumn&lt;User&gt;&gt;&nbsp;columns)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<span class=""keyword"">base</span><span>(</span><span class=""keyword"">null</span><span>,&nbsp;store,&nbsp;columns)&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;us=store;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;&nbsp;UserStore&nbsp;GetStore(){&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;us;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">static</span><span>&nbsp;List&lt;TableColumn&lt;User&gt;&gt;&nbsp;DefineColumns()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;TableColumn&lt;User&gt;&gt;&nbsp;columns=&nbsp;<span class=""keyword"">new</span><span>&nbsp;List&lt;TableColumn&lt;User&gt;&gt;();&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Name""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Name);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""City""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.City);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Address""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Address);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Birthday""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.DoB.ToString(<span class=""string"">""dd.MM.yyyy""</span><span>));&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Email""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Email);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Rating""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Rating.ToString());&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.AutoNumeric(<span class=""keyword"">new</span><span>&nbsp;{mDec=0});&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.TextAlign=<span class=""string"">""center""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Level""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.SetValue(f.Level);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.Color=&nbsp;f.Level==<span class=""string"">""A""</span><span>?</span><span class=""string"">""green""</span><span>:&nbsp;f.Level==</span><span class=""string"">""B""</span><span>?</span><span class=""string"">""orange""</span><span>:&nbsp;</span><span class=""string"">""red""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.TextAlign=<span class=""string"">""center""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;columns.Add(<span class=""keyword"">new</span><span>&nbsp;TableColumn&lt;User&gt;(){&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Header=&nbsp;<span class=""keyword"">new</span><span>&nbsp;TableCell(c=&gt;&nbsp;c.Text(</span><span class=""string"">""Active&nbsp;?""</span><span>)).Element(),&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Value=&nbsp;(f)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;TableCell(&nbsp;c=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Style.TextAlign=<span class=""string"">""center""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.Append(&nbsp;<span class=""keyword"">new</span><span>&nbsp;Icon(c,&nbsp;i=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;i.ClassName=&nbsp;f.IsActive?&nbsp;<span class=""string"">""icon-ok-circle""</span><span>:&nbsp;</span><span class=""string"">""icon-ban-circle""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element());&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Element();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AfterCellCreate=&nbsp;(f,row)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row.Style.Color=&nbsp;f.IsActive?<span class=""string"">""black""</span><span>:</span><span class=""string"">""grey""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row.AddClass(f.Rating&gt;=10000?&nbsp;<span class=""string"">""success""</span><span>:&nbsp;f.Rating&lt;=5000?</span><span class=""string"">""warning""</span><span>:</span><span class=""string"">""""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;columns;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">[IgnoreNamespace]
public class UserGrid:HtmlGrid&lt;User&gt;
{
	UserStore us;
	
	public UserGrid (Element parent, UserStore store)
		:this(parent, store, DefineColumns())
	{
	}
	
	public UserGrid (Element parent, UserStore store, List&lt;TableColumn&lt;User&gt;&gt; columns)
		:base(null, store, columns)
	{
		AppendTo(parent);
		us=store;
	}
	
	public new  UserStore GetStore(){
		return us;
	}
	
	public static List&lt;TableColumn&lt;User&gt;&gt; DefineColumns()
	{
		List&lt;TableColumn&lt;User&gt;&gt; columns= new List&lt;TableColumn&lt;User&gt;&gt;();
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Name"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.Name);
				}).Element();
			}
		});
		
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""City"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.City);
				}).Element();
			}
		});
		
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Address"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.Address);
				}).Element();
			}
		});
		
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Birthday"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.DoB.ToString(""dd.MM.yyyy""));
				}).Element();
			}
		});
		
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Email"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.Email);
				}).Element();
			}
		});
		
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Rating"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.Rating.ToString());
					c.AutoNumeric(new {mDec=0});
					c.Style.TextAlign=""center"";
				}).Element();
			},
			
		});

		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Level"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.SetValue(f.Level);
					c.Style.Color= f.Level==""A""?""green"": f.Level==""B""?""orange"": ""red"";
					c.Style.TextAlign=""center"";
				}).Element();
			}
		});
		
		columns.Add(new TableColumn&lt;User&gt;(){
			Header= new TableCell(c=&gt; c.Text(""Active ?"")).Element(),
			Value= (f)=&gt;{
				return new TableCell( c=&gt;{
					c.Style.TextAlign=""center"";
					c.Append( new Icon(c, i=&gt;{
						i.ClassName= f.IsActive? ""icon-ok-circle"": ""icon-ban-circle"";
					}).Element());
					
				}).Element();
			},
			AfterCellCreate= (f,row)=&gt;{
				row.Style.Color= f.IsActive?""black"":""grey"";
				row.AddClass(f.Rating&gt;=10000? ""success"": f.Rating&lt;=5000?""warning"":"""");
			}
		});
		
		return columns;
	}	
}
</textarea></div>");

				Document.CreateElement("h3").Text("UserForm.cs").AppendTo(div);
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;UserForm:Form&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;FormElement&nbsp;f;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;ButtonElement&nbsp;GetSaveButton()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;f.FindById&lt;ButtonElement&gt;(</span><span class=""string"">""btn-save""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;ButtonElement&nbsp;GetDestroyButton()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;f.FindById&lt;ButtonElement&gt;(</span><span class=""string"">""btn-destroy""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;ButtonElement&nbsp;GetCreateButton()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;f.FindById&lt;ButtonElement&gt;(</span><span class=""string"">""btn-create""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;UserForm&nbsp;(Element&nbsp;parent,&nbsp;List&lt;RadioItem&gt;&nbsp;levelOptions):</span><span class=""keyword"">base</span><span>(</span><span class=""keyword"">null</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f&nbsp;=&nbsp;Element();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.ClassName=<span class=""string"">""form-horizontal""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Append(<span class=""string"">""&lt;style&gt;.form-horizontal&nbsp;.controls&nbsp;{&nbsp;margin-left:&nbsp;100px;&nbsp;}&nbsp;@media&nbsp;(max-width:&nbsp;480px)&nbsp;{&nbsp;.form-horizontal&nbsp;.controls&nbsp;{&nbsp;margin-left:&nbsp;0px;&nbsp;}&nbsp;}&nbsp;&nbsp;&lt;/style&gt;""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(f,&nbsp;tb=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.ClassName=&nbsp;<span class=""string"">""nav""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;IconButton(tb,&nbsp;(bt,&nbsp;ibn)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ibn.ClassName=<span class=""string"">""icon-file&nbsp;icon-large""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ID=<span class=""string"">""btn-create""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Disabled=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;IconButton(tb,&nbsp;(bt,&nbsp;ibn)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ibn.ClassName=<span class=""string"">""icon-save&nbsp;icon-large""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ID=<span class=""string"">""btn-save""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Type(<span class=""string"">""submit""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Disabled=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;IconButton(tb,&nbsp;(bt,&nbsp;ibn)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ibn.ClassName=<span class=""string"">""icon-remove&nbsp;icon-large""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.ID=<span class=""string"">""btn-destroy""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bt.Disabled=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;InputText(f,&nbsp;e=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""Id""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Hide();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.IsNumeric();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Name""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""Name""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""City""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""City""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Address""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""Address""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Birthday""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""DoB""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Datepicker(<span class=""keyword"">new</span><span>&nbsp;{&nbsp;&nbsp;dateFormat=&nbsp;</span><span class=""string"">""dd.mm.yy""</span><span>&nbsp;});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""Email""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;TextField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Rating""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""Rating""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.AutoNumeric();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;RadioField(f,&nbsp;</span><span class=""string"">""Level""</span><span>,&nbsp;</span><span class=""string"">""Level""</span><span>,&nbsp;levelOptions);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;CheckboxField(f,(l,&nbsp;e)=&gt;{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;l.Text(<span class=""string"">""Is&nbsp;Active?""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Name=<span class=""string"">""IsActive""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.JQuery(<span class=""string"">""label[class='control-label']""</span><span>).CSS(</span><span class=""string"">""width""</span><span>,&nbsp;</span><span class=""string"">""80px""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">[IgnoreNamespace]
public class UserForm:Form
{
	FormElement f;
	
	public ButtonElement GetSaveButton()
	{
		return f.FindById&lt;ButtonElement&gt;(""btn-save"");
	}
	
	public ButtonElement GetDestroyButton()
	{
		return f.FindById&lt;ButtonElement&gt;(""btn-destroy"");
	}
	
	public ButtonElement GetCreateButton()
	{
		return f.FindById&lt;ButtonElement&gt;(""btn-create"");
	}
	
	public UserForm (Element parent, List&lt;RadioItem&gt; levelOptions):base(null)
	{
		f = Element();
		
		f.ClassName=""form-horizontal"";
		f.Append(""&lt;style&gt;.form-horizontal .controls { margin-left: 100px; } @media (max-width: 480px) { .form-horizontal .controls { margin-left: 0px; } }  &lt;/style&gt;"");
		
		new Div(f, tb=&gt;{
			tb.ClassName= ""nav"";
			new IconButton(tb, (bt, ibn)=&gt;{
				ibn.ClassName=""icon-file icon-large"";
				bt.ID=""btn-create"";
				bt.Disabled=true;
			});
			
			new IconButton(tb, (bt, ibn)=&gt;{
				ibn.ClassName=""icon-save icon-large"";
				bt.ID=""btn-save"";
				bt.Type(""submit"");
				bt.Disabled=true;
			});
			
			new IconButton(tb, (bt, ibn)=&gt;{
				ibn.ClassName=""icon-remove icon-large"";
				bt.ID=""btn-destroy"";
				bt.Disabled=true;
			});
		});
		
		new InputText(f, e=&gt;{
			e.Name=""Id"";
			e.Hide();
			e.IsNumeric();
		}); 
		
		new TextField(f,(l, e)=&gt;{
			l.Text(""Name"");
			e.Name=""Name"";
		}); 
		
		new TextField(f,(l, e)=&gt;{
			l.Text(""City"");
			e.Name=""City"";
		}); 
		
		new TextField(f,(l, e)=&gt;{
			l.Text(""Address"");
			e.Name=""Address"";
		}); 
		
		new TextField(f,(l, e)=&gt;{
			l.Text(""Birthday"");
			e.Name=""DoB"";
			e.Datepicker(new {  dateFormat= ""dd.mm.yy"" });
		}); 
		
		new TextField(f,(l, e)=&gt;{
			l.Text(""Email"");
			e.Name=""Email"";
		}); 
		
		new TextField(f,(l, e)=&gt;{
			l.Text(""Rating"");
			e.Name=""Rating"";
			e.AutoNumeric();
		}); 
		
		new RadioField(f, ""Level"", ""Level"", levelOptions);
		
		new CheckboxField(f,(l, e)=&gt;{
			l.Text(""Is Active?"");
			e.Name=""IsActive"";
		}); 
		
		f.JQuery(""label[class='control-label']"").CSS(""width"", ""80px"");
		AppendTo(parent);
	}
}</textarea></div>");

				Document.CreateElement("h3").Text("DemoTables.cs").AppendTo(div);
				div.Append(@"<div class=""dp-highlighter""><div class=""bar""><div class=""tools""><a href=""#"" onclick=""dp.sh.Toolbar.Command('ViewSource',this);return false;"">view plain</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('CopyToClipboard',this);return false;"">copy to clipboard</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('PrintSource',this);return false;"">print</a><a href=""#"" onclick=""dp.sh.Toolbar.Command('About',this);return false;"">?</a></div></div><ol start=""1"" class=""dp-c""><li class=""alt""><span><span>[IgnoreNamespace]&nbsp;&nbsp;</span></span></li><li class=""""><span><span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">class</span><span>&nbsp;DemoTables&nbsp;&nbsp;</span></span></li><li class=""alt""><span>{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;DemoTables&nbsp;(){}&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">static</span><span>&nbsp;UserGrid&nbsp;uGrid;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">static</span><span>&nbsp;UserForm&nbsp;uForm;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">public</span><span>&nbsp;</span><span class=""keyword"">static</span><span>&nbsp;</span><span class=""keyword"">void</span><span>&nbsp;Execute(Element&nbsp;parent)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;Div(</span><span class=""keyword"">null</span><span>,&nbsp;div=&gt;{&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;div.ClassName=<span class=""string"">""bs-docs-example""</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid=&nbsp;<span class=""keyword"">new</span><span>&nbsp;UserGrid(div,&nbsp;</span><span class=""keyword"">new</span><span>&nbsp;UserStore());&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;UserForm(div,&nbsp;GetLevelOptions());&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AppendTo(parent);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetCreateButton().Disabled=<span class=""keyword"">false</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetCreateButton().OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.SelectRow();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetDestroyButton().OnClick(evt=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.GetStore().Remove(&nbsp;uGrid.GetSelectedRow().Record&nbsp;);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().OnChange(e=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetSaveButton().Disabled=!uForm.Element().DataChanged();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.OnRowSelected+=(&nbsp;(g,&nbsp;sr)=&gt;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetSaveButton().Disabled=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">if</span><span>(sr!=</span><span class=""keyword"">null</span><span>)&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().Load&lt;User&gt;(&nbsp;sr.Record);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetDestroyButton().Disabled=<span class=""keyword"">false</span><span>;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">else</span><span>&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().Load&lt;User&gt;(&nbsp;<span class=""keyword"">new</span><span>&nbsp;User());&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.GetDestroyButton().Disabled=<span class=""keyword"">true</span><span>;&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;vo&nbsp;=&nbsp;<span class=""keyword"">new</span><span>&nbsp;ValidateOptions()&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SetSubmitHandler(&nbsp;form=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;user&nbsp;=&nbsp;form.LoadTo&lt;User&gt;();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.GetStore().Save(user);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.SelectRow(&nbsp;user.Id);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((r,m)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element=&nbsp;uForm.Element().FindByName&lt;InputElement&gt;(<span class=""string"">""Name""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Required();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Minlength(6);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Required(<span class=""string"">""write&nbsp;username""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Minlength(<span class=""string"">""min&nbsp;6&nbsp;chars""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((r,m)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element=&nbsp;uForm.Element().FindByName&lt;InputElement&gt;(<span class=""string"">""Email""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Email();&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m.Email(<span class=""string"">""write&nbsp;a&nbsp;valid&nbsp;email&nbsp;address""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).AddRule((r,m)=&gt;{&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element=&nbsp;uForm.Element().FindByName&lt;InputElement&gt;(<span class=""string"">""Rating""</span><span>);&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Element.AutoNumeric(<span class=""keyword"">new</span><span>&nbsp;{mDec=0,&nbsp;&nbsp;wEmpty=&nbsp;</span><span class=""string"">""zero""</span><span>});&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Max(10000);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;r.Rule.Min(0);&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uForm.Element().Validate(vo);&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uGrid.GetStore().Read();&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">static</span><span>&nbsp;&nbsp;List&lt;RadioItem&gt;&nbsp;GetLevelOptions()&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;</span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">return</span><span>&nbsp;&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;List&lt;RadioItem&gt;(&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;RadioItem[]{&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;RadioItem{Text=</span><span class=""string"">""A""</span><span>,&nbsp;Value=</span><span class=""string"">""A""</span><span>},&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;RadioItem{Text=</span><span class=""string"">""B""</span><span>,&nbsp;Value=</span><span class=""string"">""B""</span><span>},&nbsp;&nbsp;</span></span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class=""keyword"">new</span><span>&nbsp;RadioItem{Text=</span><span class=""string"">""C""</span><span>,&nbsp;Value=</span><span class=""string"">""C""</span><span>}&nbsp;&nbsp;</span></span></li><li class=""""><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;&nbsp;</span></li><li class=""alt""><span>&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</span></li><li class=""""><span>}&nbsp;&nbsp;</span></li></ol><textarea style=""display:none;"" class=""originalCode"">[IgnoreNamespace]
public class DemoTables
{
	public DemoTables (){}
	
	static UserGrid uGrid;
	static UserForm uForm;
	
	public static void Execute(Element parent)
	{
		new Div(null, div=&gt;{
			div.ClassName=""bs-docs-example"";
			uGrid= new UserGrid(div, new UserStore());
			uForm = new UserForm(div, GetLevelOptions());
		}).AppendTo(parent);
		
		uForm.GetCreateButton().Disabled=false;
		
		uForm.GetCreateButton().OnClick(evt=&gt;{
			uGrid.SelectRow();
		});
		
		uForm.GetDestroyButton().OnClick(evt=&gt;{
			uGrid.GetStore().Remove( uGrid.GetSelectedRow().Record );
		});
		
		uForm.Element().OnChange(e=&gt;{
			uForm.GetSaveButton().Disabled=!uForm.Element().DataChanged();
		});
		
		uGrid.OnRowSelected+=( (g, sr)=&gt;{
			uForm.GetSaveButton().Disabled=true;
			if(sr!=null)
			{
				uForm.Element().Load&lt;User&gt;( sr.Record);
				uForm.GetDestroyButton().Disabled=false;
			}
			else
			{
				uForm.Element().Load&lt;User&gt;( new User());
				uForm.GetDestroyButton().Disabled=true;
			}
		});
		
		var vo = new ValidateOptions()
			.SetSubmitHandler( form=&gt;{
				var user = form.LoadTo&lt;User&gt;();
				uGrid.GetStore().Save(user);
				uGrid.SelectRow( user.Id);
			}).AddRule((r,m)=&gt;{
				r.Element= uForm.Element().FindByName&lt;InputElement&gt;(""Name"");
				r.Rule.Required();
				r.Rule.Minlength(6);
				m.Required(""write username"");
				m.Minlength(""min 6 chars"");
			}).AddRule((r,m)=&gt;{
				r.Element= uForm.Element().FindByName&lt;InputElement&gt;(""Email"");
				r.Rule.Email();
				m.Email(""write a valid email address"");
			}).AddRule((r,m)=&gt;{
				r.Element= uForm.Element().FindByName&lt;InputElement&gt;(""Rating"");
				r.Element.AutoNumeric(new {mDec=0,  wEmpty= ""zero""});
				r.Rule.Max(10000);
				r.Rule.Min(0);
			});
		
		uForm.Element().Validate(vo);
		
		uGrid.GetStore().Read();
	}
	
	static  List&lt;RadioItem&gt; GetLevelOptions()
	{
		return 
			new List&lt;RadioItem&gt;(
				new RadioItem[]{
				new RadioItem{Text=""A"", Value=""A""},
				new RadioItem{Text=""B"", Value=""B""},
				new RadioItem{Text=""C"", Value=""C""}
			});
	}
}</textarea></div>");
			}).AppendTo (parent);
		}
	}
}
