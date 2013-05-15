using System.Html;
using System.Runtime.CompilerServices;
using Cayita.UI;
using jQueryApi;
using Cayita.Plugins;
using Aicl.Calamar.Scripts.Modelos;
using System.Collections.Generic;
using System;
using System.Linq;
using Cayita.Data;

namespace Aicl.Calamar.Scripts.ModuloGastos
{
	[IgnoreNamespace]
	public class MainModule
	{

		int sq=0;
		public MainModule (){}

		Div SearchDiv {get;set;}
		Div FormDiv {get;set;}
		Div GridDiv {get;set;}
		Form Form {get;set;}

		HtmlGrid<Gasto> GridGastos {get;set;}
		Store<Gasto> StoreGastos {get;set;}
		SelectedRow SelectedGasto {get;set;}
		List<TableColumn<Gasto>> Columns {get;set;}

		Button BNew {get;set;}
		Button BDelete {get;set;}
		Button BList {get;set;}

		Store<Concepto> StoreConceptos {get;set;}
		Store<Fuente> StoreFuentes {get;set;}

		SelectField<Concepto> cbConcepto;
		SelectField<Fuente> cbFuente;

		void DefineStores ()
		{
			StoreConceptos = new Store<Concepto>();
			StoreConceptos.SetReadApi(api=>{api.Url="json/conceptoResponse.json";});
			
			StoreFuentes = new Store<Fuente>();
			StoreFuentes.SetReadApi(api=>api.Url="json/fuenteResponse.json");

			StoreGastos = new Store<Gasto>();
			StoreGastos.SetReadApi(api=> {api.Url="json/gastoResponse.json";});

		}
						
		public static void Execute(Element parent )
		{
			var m = new MainModule();
			m.DefineStores();
			m.DefineTableColumns();
			m.Paint(parent);
			m.StoreConceptos.Read();
			m.StoreFuentes.Read();
			m.GridEvents();
		}

		void Paint(Element parent)
		{

			new Div(parent, div=>{
				div.ClassName="span6 offset2 well";
				div.Hide();
			}) ;
			
			SearchDiv= new Div(default(Element), searchdiv=>{
				searchdiv.ClassName= "span6 offset2 nav";

				var inputFecha=new InputText(searchdiv, ip=>{
					ip.ClassName="input-medium search-query";
					ip.SetAttribute("data-mask","99.99.9999");
					ip.PlaceHolder("dd.mm.aaaa");
				}).Element(); 
				
				new IconButton(searchdiv, (abn, ibn)=>{
					ibn.ClassName="icon-search icon-large";
					abn.JQuery().Click(evt=>{
						if( ! inputFecha.Value.IsDateFormatted()){
							Alert.Error(SearchDiv.Element(),"Digite una fecha valida",false);
							return;
						}
						LoadGastos( inputFecha.Value.ToServerDate() );

					});
				});

				BNew= new IconButton(searchdiv, (abn, ibn)=>{
					ibn.ClassName="icon-plus-sign icon-large";
					abn.JQuery().Click(evt=>{
						FormDiv.FadeIn();
						GridDiv.FadeOut();
						Form.Element().Reset();
						BDelete.Element().Disabled=true;
					});
				});

				BDelete=new IconButton(searchdiv, (abn, ibn)=>{
					ibn.ClassName="icon-remove-sign icon-large";
					abn.Disabled=true;
					abn.JQuery().Click(evt=>{
						RemoveRow();
					});
				});

				BList= new IconButton(searchdiv, (abn, ibn)=>{
					ibn.ClassName="icon-reorder icon-large";
					abn.Disabled=true;
					abn.JQuery().Click(evt=>{
						FormDiv.Hide ();
						GridDiv.FadeIn();
						abn.Disabled=true;
					});
				});
				
			});
			SearchDiv.AppendTo(parent);
						
			FormDiv= new Div(default(Element), formdiv=>{
				formdiv.ClassName="span6 offset2 well";
				Form = new Form(formdiv, f=>{
					f.ClassName="form-horizontal";

					var inputId= new InputText(f, e=>{
						e.Name="Id";
						e.Hide();
					}); 

					cbConcepto=new SelectField<Concepto>(f, (e)=>{
						e.Name="IdConcepto";
						e.ClassName="span12";
					}, 
					StoreConceptos,
					fc=>{
						return new HtmlOption( opt=>{
							opt.Value= fc.Id.ToString();
							opt.Text = fc.Nombre;
						}).Element();
					}, 
					new SelectedOption<Concepto>{
						Option = new HtmlOption( o=>{
							o.Value="";
							o.Text="Select Concepto ...";
						}).Element()
					});

					
					cbFuente= new SelectField<Fuente>(f, (e)=>{
						e.Name="IdFuente";
						e.ClassName="span12";
					}, 
					StoreFuentes,
					fc=>{
						return new HtmlOption( opt=>{
							opt.Value= fc.Id.ToString();
							opt.Text = fc.Nombre;
						}).Element();
					}, 
					new SelectedOption<Fuente>{
						Option = new HtmlOption( o=>{
							o.Value="";
							o.Text="Select Fuente ...";
						}).Element()
					});

					
					var fieldValor= new TextField(f,(field)=>{
						field.ClassName="span12";
						field.Name="Valor";
						field.PlaceHolder("$$$$$$$$$$");
						field.AutoNumeric();

					});
					
					new TextField(f,(field)=>{
						field.ClassName="span12";
						field.Name="Beneficiario";
						field.PlaceHolder("Pagado a ....");
					});
					
					new TextField(f,(field)=>{
						field.ClassName="span12";
						field.Name="Descripcion";
						field.PlaceHolder("Descripcion");
					});
										
					var bt = new SubmitButton(f, b=>{
						b.JQuery().Text("Guardar");
						b.LoadingText(" Guardando ...");
						b.AddClass("btn-info btn-block") ;
					});
					
					var vo = new ValidateOptions()
						.SetSubmitHandler( form=>{
							bt.ShowLoadingText();
							var result =new Gasto();
							form.LoadTo(result);

							Firebug.Console.Log("guardando", form.Serialize(), result);
							if(string.IsNullOrEmpty(inputId.Value()) )
								AppendRow(result);
							else
								try{

									UpdateRow(result);
							}
							catch(Exception e){
								Firebug.Console.Log("ex ",e);
							}
							
							form.Reset();
							bt.ResetLoadingText();
							
						})
							.AddRule((rule, msg)=>{
								rule.Element=fieldValor.Input;
								rule.Rule.Required();
								msg.Required("Digite el valor del gasto");
							})

							.AddRule((rule, msg)=>{
								rule.Element=cbConcepto.Input;
								rule.Rule.Required();
								msg.Required("Seleccione el concepto");
							})
							
							.AddRule((rule, msg)=>{
								rule.Element=cbFuente.Input;
								rule.Rule.Required();
								msg.Required("Seleccione al fuente del pago");
							});
					
					f.Validate(vo);				
				});
			});

			FormDiv.AppendTo(parent);
						
			GridDiv= new  Div(default(Element), gdiv=>{
				gdiv.ClassName="span10";
				GridGastos= new HtmlGrid<Gasto>(gdiv, StoreGastos,Columns);
				gdiv.Hide();
			});

			GridDiv.AppendTo(parent);	

		}

		void LoadGastos (string date)
		{
			//StoreGastos.Read().Always(a=>{
			FormDiv.Hide();
			GridDiv.FadeIn();
			//});
		}

		void RemoveRow ()
		{
			StoreGastos.Remove( GridGastos.GetSelectedRow().Record);
			BDelete.Element().Disabled=true;
			BList.Element().Disabled=true;
			FormDiv.Hide();
			GridDiv.FadeIn();
		}

		void AppendRow (Gasto data)
		{
			data.Id= ++sq;
			StoreGastos.Add(data);
			BDelete.Element().Disabled=true;
			BList.Element().Disabled=false;
		}


		void UpdateRow (Gasto data)
		{
			StoreGastos.Replace(data);

			BList.Element().Disabled=true;
			FormDiv.Hide();
			GridDiv.FadeIn();
		}

		void GridEvents ()
		{
			GridGastos.RowSelected+=(gd, sr)=>{
				BDelete.Element ().Disabled = false;
				BList.Element ().Disabled = false;
				Form.Element ().Reset ();
				if(sr!=null) Form.Element ().Load (sr.Record);
				GridDiv.Hide ();
				FormDiv.Element ().FadeIn ();
			};
		}

		void DefineTableColumns()
		{
			Columns= new List<TableColumn<Gasto>>();
			
			Columns.Add( new TableColumn<Gasto>{
				Header=  new TableCell(cell=>{
					new Anchor(cell, a=>{a.Text("Concepto");});
				}).Element(),
				Value = f=> {
					return new TableCell( cell=>{
						new Anchor(cell, a=>{
							a.Text(StoreConceptos.FirstOrDefault(q=>q.Id.ToString()== f.IdConcepto.ToString() ).Nombre);
						});
					} ).Element(); }
			});
			
			Columns.Add( new TableColumn<Gasto>{
				Header=  new TableCell(cell=>{ cell.Text("Fuente"); }).Element(),
				Value = f=> { return new TableCell( cell=>{cell.SetValue(StoreFuentes.FirstOrDefault(q=>q.Id.ToString()==f.IdFuente.ToString()).Nombre); } ).Element(); }
			});
			
			Columns.Add( new TableColumn<Gasto>{
				Header=  new TableCell(cell=>{ cell.Text("Valor"); cell.Style.TextAlign= "right"; }).Element(),
				Value = f=> { return new TableCell( cell=>{cell.SetValue(f.Valor.ToString());  cell.AutoNumeric(); }) .Element(); }
			});
			
			Columns.Add( new TableColumn<Gasto>{
				Header=  new TableCell(cell=>{cell.Text("Pagado a");}).Element(),
				Value = f=> { return new TableCell( cell=>{	cell.SetValue(f.Beneficiario);} ).Element();					
				}
			});
			
			Columns.Add( new TableColumn<Gasto>{
				Header=  new TableCell(cell=>{cell.Text("Detalle");}).Element(),
				Value = f=> { return new TableCell( cell=>{	cell.SetValue(f.Descripcion);} ).Element();					
				}
			});			
		}
	}

}

