using System;
using Cayita.UI;
using System.Html;

namespace Cayita
{
	public class ImgUpload:FileUpload<ImgUpload>
	{
		ImgUploadConfig cfg;
		ImageElement img;
		DivElement divNew;
		DivElement divExists;

		public ImgUpload (Element parent=null):base(parent)
		{
			Init ( new ImgUploadConfig());
		}
		
		public ImgUpload(Element parent, Action<ImgUploadConfig> config):base(parent)
		{
			var c = new ImgUploadConfig ();
			config.Invoke (c);
			Init (c);
		}
		
		public ImgUpload(Element parent, ImgUploadConfig config):base(parent)
		{
			Init (config);
		}
		
		void Init(ImgUploadConfig config )
		{
			cfg = config;
			
			var e = Element ();

			new Div (d => {
				d.ClassName = "fileupload-new thumbnail";
				d.Style.Width = cfg.ImgWidth;
				d.Style.Height = cfg.ImgHeight;
				img = new Image (d, i => i.Src = cfg.ImgSrc).Element ();
				divNew = d;
			}).	AppendTo(e);

			new  Div (d => {
				d.ClassName = "fileupload-preview fileupload-exists thumbnail";
				d.Style.Width = cfg.ImgWidth;
				d.Style.Height = cfg.ImgHeight;
				d.Style.LineHeight = "20px";
				divExists=d;
			}).AppendTo(e);

			new Div ( d => {									
				new Span(d, sp=>{
					sp.ClassName="btn btn-file";
					new Span(sp, sl=>{
						sl.ClassName="fileupload-new";
						new Icon(sl, i=>{
							i.ClassName=cfg.SelectIconClass;
						});
						var t= Document.CreateElement("ctxt");
						t.AppendTo(sl);
						t.InnerHTML=cfg.SelectText??"";
					});
					
					new Span(sp, sl=>{
						sl.ClassName="fileupload-exists";
						new Icon(sl, i=>{
							i.ClassName=cfg.SelectIconClass;
						});
						var t= Document.CreateElement("ctxt");
						t.AppendTo(sl);
						t.InnerHTML=cfg.SelectText??"";
					});
					
					new InputFile(sp, i=>{
						i.Name=cfg.Fieldname;
						i.Accept=cfg.Accept;
						Input= i;
					});
				});
				
				new Anchor(d, a=>{
					a.ClassName="btn fileupload-exists";
					a.SetAttribute("data-dismiss","fileupload");
					
					new Icon(a, i=>{
						i.ClassName=cfg.RemoveIconClass;
					});
					
					var t= Document.CreateElement("ctxt");
					t.AppendTo(a);
					t.InnerHTML=cfg.RemoveText??"";
					
				});
												
			}).AppendTo(e);
		}

		public ImgUpload ImgSrc(string src)
		{
			cfg.ImgSrc = src;
			img.Src = src;
			return this;
		}

		public ImgUpload ImgWidth(string width)
		{
			cfg.ImgWidth = width;
			divNew.Style.Width = width;
			divExists.Style.Width = width;
			return this;
		}

		public ImgUpload ImgHeight(string height)
		{
			cfg.ImgHeight = height;
			divNew.Style.Height = height;
			divExists.Style.Height = height;
			return this;
		}


	}
	
	public class ImgUploadConfig:FileUploadConfig
	{
		public ImgUploadConfig():base()
		{
			Accept = "image/*";
			ImgSrc = "http://www.placehold.it/200x150/EFEFEF/AAAAAA&text=no+image";
			ImgWidth = "200px";
			ImgHeight = "150px";
		}
		

		public string ImgSrc { get; set; }
		public string ImgWidth { get; set; }
		public string ImgHeight { get; set; }
	}
}


