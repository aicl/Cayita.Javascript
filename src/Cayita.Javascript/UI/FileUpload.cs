using System;
using Cayita.UI;
using System.Html;

namespace Cayita.UI
{
	public class FileUpload:Div
	{
		FileUploadConfig cfg;

		public FileElement Input {
			get;
			private set;
		}


		public FileUpload (Element parent=null):base(parent)
		{
			Init ( new FileUploadConfig());
		}

		public FileUpload(Element parent, Action<FileUploadConfig> config):base(parent)
		{
			var c = new FileUploadConfig ();
			config.Invoke (c);
			Init (c);
		}

		public FileUpload(Element parent, FileUploadConfig config):base(parent)
		{
			Init (config);
		}

		void Init(FileUploadConfig config )
		{
			cfg = config;

			var e = Element ();
			e.ClassName = "fileupload fileupload-new";
			e.SetAttribute ("data-provides", "fileupload");
			new Div ( d => {
				d.ClassName="input-append";
				new Div(d, inpt=>{
					inpt.ClassName= "uneditable-input span"+ cfg.SpanSize;
					new Icon(inpt, i=> i.ClassName="icon-file fileupload-exists");
					new Span(inpt, s=> s.ClassName="fileupload-preview");
				});

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
						Input=i;
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

				JQuery().On("change.fileupload",evt=>{
					OnFileSelected();
				});

			}).AppendTo(e);
		}


		public event Action<FileUpload> FileSelected=f=>{};

		protected virtual void OnFileSelected()
		{
			FileSelected (this);
		}
	}

	public class FileUploadConfig
	{
		public FileUploadConfig()
		{
			SelectIconClass = "icon-folder-open";
			RemoveIconClass = "icon-remove";
			Fieldname = "";
			//PlaceHolder = "";
			SpanSize = 3;

		}

		public string SelectText {get;set;}
		public string SelectIconClass { get; set; }
		public string RemoveText {get;set;}
		public string RemoveIconClass { get; set; }
		public string Fieldname { get; set; }
		public int SpanSize { get; set; }
		//public string PlaceHolder { get; set; }
	}
}


//http://markusslima.github.io/bootstrap-filestyle/  api ?
// ver implementacion: http://blueimp.github.io/jQuery-File-Upload/
// leer : http://duckranger.com/2012/06/pretty-file-input-field-in-bootstrap/

// var f = document.getElementById("fu"); 
// $f.on("change.fileupload", function(evt){console.log("change",evt)});
// ver evt.target que es un input con el valor del archivo. ( es el input type="file")

//https://developer.mozilla.org/en-US/docs/DOM/XMLHttpRequest/Using_XMLHttpRequest#Submitting_forms_and_uploading_files
//https://developer.mozilla.org/en-US/docs/DOM/XMLHttpRequest/FormData/Using_FormData_Objects
/*

<input type="hidden" value="" name="">

<form id="fu" method="post" action="/api/admin/image" enctype="multipart/form-data">
<div class="fileupload fileupload-new" data-provides="fileupload">

	<div class="fileupload-new thumbnail" style="width: 200px; height: 150px;"><img src="https://googledrive.com/host/0B5PxAJVNHVdKaGFMczUxX2RRSkk/img/form.demo-1.png"></div>
	<div class="fileupload-preview fileupload-exists thumbnail" style="max-width: 200px; max-height: 150px; line-height: 20px;"></div>

    <div>
	  <span class="btn btn-file">
		  <span class="fileupload-new">
		  	<i class="icon-folder-open"></i>
		  	<ctxt>Select</ctxt>
		  </span>
		  <span class="fileupload-exists">
		  	<i class="icon-folder-open"></i>
		  	<ctxt>Select</ctxt>
		  </span>
		  <input id="file" type="file" name="Filename">
	  </span>
	  <a href="#" class="btn fileupload-exists" data-dismiss="fileupload" title="remove">
		  <input type="hidden" value="" name="">
		  <i class="icon-remove"></i>
		  <ctxt>Remove</ctxt>
	  </a>
	</div>
</div>
<input class="btn" type="submit"  value="Upload" />
</form>



<div class="fileupload fileupload-exists" data-provides="fileupload">
	<div class="input-append">
    	<div class="uneditable-input span3">
    		<i class="icon-file fileupload-exists"></i>
    		<span class="fileupload-preview">texture.css</span>
    	</div>
    	<span class="btn btn-file">
    		<span class="fileupload-new">Select file</span>
    		<span class="fileupload-exists">Change</span>
    		<input type="file" name="Filename">
    	</span>
    	<a href="#" class="btn fileupload-exists" data-dismiss="fileupload">Remove</a>
    </div>
</div>



function sendForm2() {
 
  var
    oOutput = document.getElementById("output"),
    oData = new FormData(document.getElementById("fu")); 

 
  oData.append("CustomField", "This is some extra data");
 
  var oReq = new XMLHttpRequest();
  oReq.open("POST", "stash.php", true);
  oReq.onload = function(oEvent) {
    if (oReq.status == 200) {
      oOutput.innerHTML = "Uploaded!";
    } else {
      oOutput.innerHTML = "Error " + oReq.status + " occurred uploading your file.<br \/>";
    }
  };
 
  oReq.send(oData);
 
}

*/
