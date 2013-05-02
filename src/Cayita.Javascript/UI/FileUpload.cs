using System;

namespace Cayita
{
	public class FileUpload
	{
		public FileUpload ()
		{
		}
	}
}

//http://markusslima.github.io/bootstrap-filestyle/ tomar api
// ver implementacion: http://blueimp.github.io/jQuery-File-Upload/
// leer : http://duckranger.com/2012/06/pretty-file-input-field-in-bootstrap/
/*

<input type="hidden" value="" name="">
<form method="post" action="/api/admin/image" enctype="multipart/form-data">
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
		  <input type="file" name="Filename">
	  </span>
	  <a href="#" class="btn fileupload-exists" data-dismiss="fileupload" title="remove">
		  <input type="hidden" value="" name="">
		  <i class="icon-remove"></i>
		  <ctxt>Remove</ctxt>
	  </a>
	</div>
</div>
<input class="btn" type="submit" name="image" value="Upload" />
</form>
*/