

public static  void Test (){
	var file = Document.GetElementById ("fileToUpload").As<FileInput>().Files[0];
	var fd = new FormData ();
	fd.Append ("UserFile", file.Name);
	fd.Append ("FileToUpload", file);
	var config = new SendFormDataConfig ();
	config.Url = "/api/cor/savefile";
	config.Handlers.Add (XmlHttpRequestEvents.Progress, Progress );

	config.Handlers.Add (XmlHttpRequestEvents.Load, Load);

	config.Handlers.Add (XmlHttpRequestEvents.Readystatechange, Readystatechange);

	config.Handlers.Add (XmlHttpRequestEvents.Abort, (evt) => {
		Firebug.Console.Log("abort", evt);
	});


	fd.Send (config);
}

static void Progress (XmlHttpRequestProgressEvent evt)
{
	Firebug.Console.Log("progress", evt);
}

static void Load (XmlHttpRequestProgressEvent evt)
{
	Firebug.Console.Log("load", evt);
}

static void Readystatechange (XmlHttpRequestProgressEvent evt)
{
	Firebug.Console.Log("readystatechange", evt, evt.Target.Status);
	if(evt.Target.Status==404)
	{
		evt.Target.RemoveEventListener (XmlHttpRequestEvents.Readystatechange, Readystatechange);
		evt.Target.Abort();
	}
}

