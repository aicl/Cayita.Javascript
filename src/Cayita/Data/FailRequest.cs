using System;
using jQueryApi;
using System.Collections.Generic;
using System.Serialization;
using System.Runtime.CompilerServices;

namespace Cayita
{

	public class FailRequest:Record
	{

		internal FailRequest(jQueryXmlHttpRequest request){

			Status = request.Status;
			StatusText = request.StatusText;
			ResponseText = request.ResponseText;

			try
			{
				var r = (dynamic)Json.Parse(request.ResponseText ?? "{}");
				Response= UI.Cast<ResponseStatus>( r.ResponseStatus?? new ResponseStatus());
			}
			catch(Exception){
				Response = new ResponseStatus ();
			}

			if (Response.Message.IsNullOrEmpty () && StatusText == "ValidationException")
				Response.Message = "User/Password Invalid";

			if (Response.ErrorCode.IsNullOrEmpty ()) {
				Response.ErrorCode = StatusText;
			}
		}

		public int Status { get; internal set;}
		public string StatusText { get; internal set;}
		public string ResponseText { get; set; }
		public ResponseStatus Response { get; internal set; }

	}



	[PreserveMemberCase]
	public class ResponseStatus:Record
	{
		internal ResponseStatus()
		{
			Errors = new List<string> ();
			ErrorCode = null;
			Message = null;
		}
		public string ErrorCode {get; internal set;}
		public string Message {get; internal set;}
		public List<string> Errors { get; set;}
	}


}


/*
cayita.fn.getAjaxResponse=function(jqXHR)
                {
                        var resStatus ={ErrorCode:"", Message:"", Errors:[] };
                        var r ={}; try { r= JSON.parse(jqXHR.responseText||'{}'); } catch(err){};
                        if(r.ResponseStatus){
                                if(r.ResponseStatus.Errors){
                                        resStatus.Errors=response.ResponseStatus.Errors;
                                }
                                resStatus.ErrorCode=r.ResponseStatus.ErrorCode;
                                resStatus.Message=r.ResponseStatus.Message;
                        }
                        else{
                                resStatus.ErrorCode=jqXHR.status.toString();
                                resStatus.Message=jqXHR.statusText;
                        }
                        
                        return {ResponseStatus:resStatus, Status:jqXHR.status, StatusText:jqXHR.statusText };
                

}
{"ResponseStatus":{"ErrorCode":"ArgumentException","Message":"Userangelalreadyexists","Errors":[]}}
 */
////{"ResponseStatus":{"ErrorCode":"MySqlException","Message":"Column'Title'cannotbenull","Errors":[]}}