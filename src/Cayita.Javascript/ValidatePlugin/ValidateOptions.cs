using System;
using System.Runtime.CompilerServices;
using System.Html;
using jQueryApi;

namespace Cayita.Javascript.Plugins
{
	[Serializable]
	[IgnoreNamespace]
	public class ValidateOptions
	{
		protected Action<FormElement> SubmitHandler {get;set;}
		protected Action<InputElement> Highlight {get;set;}
		protected Action<InputElement> Unhighlight {get;set;}
		protected Action<jQueryObject> Success {get;set;}
		protected string ValidClass {get;set;}
		protected string ErrorClass {get;set;}


		public ValidateOptions ()
		{
			ErrorClass= "error";
			ValidClass="success";

			SetHighlightHandler( element=>{
				element.JQuery().Closest(".control-group").RemoveClass(ValidClass).AddClass(ErrorClass);

			});
			SetSuccessHandler( label=>{
				label.Closest(".control-group").RemoveClass(ErrorClass).AddClass(ValidClass);
			});

			SetUnhighlightHandler( element=>{
				element.JQuery().Closest(".control-group").RemoveClass(ErrorClass);
				
			});
		}
		
		protected dynamic Messages = new {};
		protected dynamic Rules = new {};

		public ValidateOptions SetErrorClass(string className)
		{
			ErrorClass= className;
			return this;
		}

		public ValidateOptions SetValidClass(string className)
		{
			ValidClass= className;
			return this;
		}

		/// <summary>
		/// Callback for handling the actual submit when the form is valid.
		/// Gets the form as the only argument. 
		/// Replaces the default submit. 
		/// The right place to submit a form via Ajax after it validated
		/// </summary>
		/// <param name='handler'>
		/// Handler (FormElement)
		/// </param>
		public ValidateOptions SetSubmitHandler (Action<FormElement> handler)
		{
			SubmitHandler= handler;
			return this;
		}

		//unhighlight: function(element, errorClass, validClass)
		//highlight: function(element, errorClass, validClass) {

		/// <summary>
		/// How to highlight invalid fields. 
		/// Set to decide which fields and how to highlight.
		/// callback recives an InputElement
		/// </summary>
		/// <param name='handler'>
		/// Handler. (InputElement)
		/// </param>
		public  ValidateOptions SetHighlightHandler( Action<InputElement> handler)
		{
			Highlight = handler;
			return this;
		}

		/// <summary>
		/// Called to revert changes made by option highlight, same arguments as highlight.
		/// callback recives an InputElement
		/// </summary>
		/// <param name='handler'>
		/// Handler. (InputElement)
		/// </param>
		public  ValidateOptions SetUnhighlightHandler( Action<InputElement> handler)
		{
			Unhighlight = handler;
			return this;
		}


		/// <summary>
		/// Function  its called with the label (as a jQuery object) as its only argument.
		/// That can be used to add a text like "ok!".
		/// </summary>
		/// <param name='handler'>
		/// Handler. (jQueryObejct)
		/// </param>
		public ValidateOptions SetSuccessHandler (Action<jQueryObject> handler)
		{
			Success= handler;
			return this;
		}

		public ValidateOptions AddRule(Action<RuleFor,Message> rule){

			var rulefor= new RuleFor();
			var msg = new Message();
			rule(rulefor, msg);
			if( ! rulefor.Element.HasAttribute("autonumeric"))
				Rules[rulefor.Element.Name] = rulefor.Rule.rl;
			else
			{
				if(rulefor.Rule.rl.max!=null) rulefor.Element.AutoNumeric(new {vMax= rulefor.Rule.rl.max});
				if(rulefor.Rule.rl.min!=null) rulefor.Element.AutoNumeric(new {vMin= rulefor.Rule.rl.min});

				if(rulefor.Rule.rl.range!=null) rulefor.Element.AutoNumeric(
					new {vMin= rulefor.Rule.rl.range.Bottom, vMax= rulefor.Rule.rl.range.Top });
			}
			Messages[rulefor.Element.Name] = msg.msg;

			return this;
		}
		
	}
	
	[Serializable]
	[IgnoreNamespace]
	public class MessageFor
	{
		public MessageFor()
		{
			Message= new Message();
		}
		
		public InputElement  Element  {get;set;}
		public Message Message { get;set;}
	}


	[Serializable]
	[IgnoreNamespace]
	public class RuleFor
	{
		public RuleFor(){
			Rule= new Rule();
		}
		
		public InputElement  Element  {get;set;}
		public Rule Rule { get;set;}
	}
	
	
	[Serializable]
	[IgnoreNamespace]
	public class Message
	{
		protected internal dynamic msg =(dynamic) (new {});

		public Message(){}
		

		public Message Remote(string message)
		{
			msg.remote=message;
			return this;
		}
		

		public Message Required(string message)
		{
			msg.required=message;
			return this;
		}
		

		public Message Email (string message)
		{
			msg.email=message;
			return this;
		}
		

		public Message Url(string message)
		{
			msg.url=message;
			return this;
		}
		

		public Message Date(string message)
		{
			msg.date=message;
			return this;
		}
		

		public Message DateISO(string message)
		{
			msg.dateISO=message;
			return this;
		}
		

		public Message Number(string message)
		{
			msg.number=message;
			return this;
		}
		

		public Message Digits(string message)
		{
			msg.digits=message;
			return this;
		}
		

		public Message Creditcard(string message)
		{
			msg.creditcard=message;
			return this;
		}
		

		public Message EqualTo (string message)
		{
			msg.equalTo=message;
			return this;
		}
		

		public Message  Maxlength  (string message)
		{
			msg.maxlength=message;
			return this;
		}
		

		public Message  Minlength (string message)
		{
			msg.minlength=message;
			return this;
		}
		

		public Message  Max  (string message)
		{
			msg.max=message;
			return this;
		}
		

		public Message  Min (string message)
		{
			msg.min=message;
			return this;
		}
		

		public Message Range (string message)
		{
			msg.range=message;
			return this;
		}
		

		public Message Rangelength (string message)
		{
			msg.rangelength=message;
			return this;
		}
						
		
	}
		
	
	[Serializable]
	[IgnoreNamespace]
	public class Rule
	{
		protected internal dynamic rl =(dynamic) (new {});
		public Rule(){}
		
		/// <summary>
		/// Requests a resource to check the element for validity.
		/// </summary>
		/// <param name='url'>
		/// The URL of the resource to request for serverside validation (String) 
		/// </param>

		public Rule Remote(string url){
			rl.url=url;
			return this;
		}
		
		/// <summary>
		/// Requests a resource to check the element for validity.
		/// see jQuery.ajax for details.
		/// </summary>
		/// <param name='url'>
		/// The URL of the resource to request for serverside validation (String) 
		/// </param>
		/// <param name='method'>
		/// Method : post | get
		/// </param>

		public Rule Remote(string url, string method){
			rl.url= new { url = url, method= method};
			return this;
		}
		/// <summary>
		/// Makes the element always required.
		/// Works with text inputs, selects, checkboxes and radio buttons.
		///	To force a user to select an option from a select box, provide an empty options
		/// like <option value="">Choose...</option>
		/// </summary>
		public Rule Required()
		{
			rl.required=true;
			return this;
		}
		
		/// <summary>
		/// Makes the element required, depending on the result of the given callback.
		///	Works with all kind of text inputs, selects, checkboxes and radio buttons.
		///	To force a user to select an option from a select box, 
		/// provide an empty options like <option value="">Choose...</option>
		/// </summary>
		/// <param name='handler'>
		/// Func<InputElement,bool> 
		/// </param>
		public Rule Required(Func<InputElement,bool> handler)
		{
			rl.required=handler;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a valid email
		/// Works with text inputs
		/// if dependCallback!=null element will be required as valid email depending on callback 
		/// </summary>
		public Rule Email (Func<Element,bool> dependCallback = null)
		{
			if(dependCallback==null) rl= new {email=true, required=true}; 
			else rl.mail= new {depends=dependCallback };
			return this;
		}



		/// <summary>
		/// Makes the element require a valid url
		/// Works with text inputs.
		/// </summary>
		public Rule Url()
		{
			rl.url=true;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a date.
		/// Uses JavaScripts built-in Date to test if the date is valid, and does therefore no sanity checks
		/// Works with text inputs!
		/// </summary>
		public Rule Date()
		{
			rl.date=true;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a ISO date.
		/// Works with text inputs.
		/// </summary>
		/// <returns>
		/// The IS.
		/// </returns>
		public Rule DateISO()
		{
			rl.dateISO=true;
			return this;
		}
		
		
		/// <summary>
		/// Makes the element require a decimal number.
		/// Works with text inputs.
		/// </summary>
		public Rule Number()
		{
			rl.number=true;
			return this;
		}
		
		/// <summary>
		/// Makes the element require digits only.
		/// Works with text input
		/// </summary>
		public Rule Digits()
		{
			rl.digits=true;
			return this;
		}
		/// <summary>
		/// Makes the element require a creditcard number.
		///	Works with text inputs
		/// if dependCallback!=null element will be required as valid creditcard depending on callback 
		/// </summary>
		public Rule Creditcard(Func<Element,bool> dependCallback = null)
		{
			if(dependCallback!=null) rl.creditcard=true; 
			else rl.creditcard= new { depends= dependCallback}; 
			return this;
		}
		
		/// <summary>
		/// Requires the element to be the same as another one
		//  Compares if the value has the same value as the element specified by the parameter.
		/// Works with text inputs.
		/// rules: {
		///		password: "required",
		///		password_again: {
		///			equalTo: "#password"
		///		}
		/// }
		/// </summary>
		/// <value>
		/// The equal to.
		/// </value>
		public Rule EqualTo (TextElement element)
		{
			rl.equalTo="#"+ element.ID;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a given maximum length.
		///	some kind of text input and its value is too short
		///	a set of checkboxes has not enough boxes checked
		///	a select and has not enough options selected
		//	Works with text inputs, selects and checkboxes.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public Rule Maxlength(int value)
		{
			rl.maxlength=value;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a given minimum length.
		///	some kind of text input and its value is too short
		///	a set of checkboxes has not enough boxes checked
		///	a select and has not enough options selected
		//	Works with text inputs, selects and checkboxes.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public Rule  Minlength(int value)
		{
			rl.minlength=value;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a given max.
		//  Works with text inputs
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public Rule  Max (int value)
		{
			rl.max=value;
			return this;
		}
		
		/// <summary>
		/// Makes the element require a given minimum.
		//  Works with text inputs
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public Rule  Min (int value)
		{
			rl.min=value;
			return this;
		}
		
				
		
		/// <summary>
		/// Makes the element require a given value range.
		///Works with text inputs.
		/// </summary>
		/// <param name='range'>
		/// Range.
		/// </param>
		public Rule Range(Range range)
		{
			rl.range = new int[2]{range.Bottom, range.Top};
			return this;
		}
		
		
		/// <summary>
		/// Makes the element require a given value range.
		/// for text input : max and min  length 
		/// for checkboxes  max and min  boxes checked
		///	for select max and min options selected
		///		Works with text inputs.
		/// </summary>
		/// <returns>
		/// The length.
		/// </returns>
		/// <param name='range'>
		/// Range.
		/// </param>
		public Rule RangeLength(Range range)
		{
			rl.rangelength = new int[2]{range.Bottom, range.Top};
			return this;
		}
		
		
	}
	
	
	[Serializable]
	[IgnoreNamespace]
	public class Range
	{
		public Range(){}
		
		public int Top {get;set;}
		public int Bottom {get;set;}
	}
	
	
}

