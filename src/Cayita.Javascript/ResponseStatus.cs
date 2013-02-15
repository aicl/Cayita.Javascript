using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Cayita.Javascript.Ajax
{
	[Serializable]	
	[ScriptNamespace("Cayita.Ajax")]
	[PreserveMemberCase]

	public class ResponseError
	{
		public ResponseError(){}
		public ResponseStatus ResponseStatus{get;set;}
	}

	[Serializable]	
	[ScriptNamespace("Cayita.Ajax")]
	[PreserveMemberCase]
	public class ResponseStatus
	{
		public ResponseStatus ()
		{
		}
		public string ErrorCode {get;set;}
		public string Message {get;set;}
		public IList<AppError> Errors{get;set;}
	}


	[Serializable]	
	[ScriptNamespace("Cayita.Ajax")]
	[PreserveMemberCase]
	public class AppError
	{
		public AppError(){}

		public string ErrorCode {get;set;}
		public string FieldName {get;set;}
		public string Message {get;set;}

	}


}

//responseText:
//{"ResponseStatus":
//	{ "ErrorCode":"MySqlException",
//	  "Message":"Cannot add or update a child row: a foreign key constraint fails (`RegistroIngresosEgresos`.`Gasto`, CONSTRAINT `fk_Gasto_IdFuente_Id` FOREIGN KEY (`IdFuente`) REFERENCES `Fuente` (`Id`))",
//	   "Errors":[]
//	}
//}"

/*
buildErrorMessage=function(jqXHR){
	var msg= '<p>'+ jqXHR.status+'</p>' +'<p>'+ jqXHR.statusText+'</p>'
	var response= JSON.parse(jqXHR.responseText||'{}');
	if(response.ResponseStatus){
		if(response.ResponseStatus.Errors){
			for (var i=0;i<response.ResponseStatus.Errors.length;i++){
				msg = msg+'<p>'+ response.ResponseStatus.Errors[i].Message +'</p>' 
			}
		}
		else{
			msg = msg+ '<p>'+ response.ResponseStatus.Message +'</p>' 
		}
	}
	return msg;
}
*/