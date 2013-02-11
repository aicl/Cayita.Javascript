/*
* Firebug Console API as defined in http://getfirebug.com/wiki/index.php/Console_API
*
*/

using System.Runtime.CompilerServices;

namespace Cayita.Javascript.Firebug
{
	[Imported]
	[ModuleName(null)]
	[IgnoreNamespace]
	[ScriptName("console")]
	public static class Console 
	{
		/// <summary>
		///   Writes a message to the console. You may pass as many arguments as you'd like, and they will be joined together in a space-delimited line.
		/// </summary>
		[ExpandParams] public static void Log(params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console. You may pass as many arguments as you'd like, and they will be joined together in a space-delimited line.      
		/// </summary>
		/// <param name="format">A string containing printf-like string substitution patterns.</param>
		[ExpandParams] public static void Log(string format, params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console, including a hyperlink to the line where it was called.
		/// </summary>
		[ExpandParams] public static void Debug(params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console, including a hyperlink to the line where it was called.
		/// </summary>
		/// <param name="format">A string containing printf-like string substitution patterns.</param>
		[ExpandParams] public static void Debug(string format, params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console with the visual "info" icon and color coding and a hyperlink to the line where it was called.
		/// </summary>      
		[ExpandParams] public static void Info(params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console with the visual "info" icon and color coding and a hyperlink to the line where it was called.
		/// </summary>
		/// <param name="format">A string containing printf-like string substitution patterns.</param>
		[ExpandParams] public static void Info(string format, params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console with the visual "warning" icon and color coding and a hyperlink to the line where it was called.
		/// </summary>
		[ExpandParams] public static void Warn(params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console with the visual "warning" icon and color coding and a hyperlink to the line where it was called.
		/// </summary>
		/// <param name="format">A string containing printf-like string substitution patterns.</param>
		[ExpandParams] public static void Warn(string format, params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console with the visual "error" icon and color coding and a hyperlink to the line where it was called.
		/// </summary>
		[ExpandParams] public static void Error(params object[] data) {}
		
		/// <summary>
		///   Writes a message to the console with the visual "error" icon and color coding and a hyperlink to the line where it was called.
		/// </summary>
		/// <param name="format">A string containing printf-like string substitution patterns.</param>
		[ExpandParams] public static void Error(string format, params object[] data) {}
		
		/// <summary>
		///   Tests that an expression is true. If not, it will write a message to the console and throw an exception.
		/// </summary>
		/// <param name="expression">The boolean expression to test.</param>      
		public static void Assert(bool expression) {}
		
		/// <summary>
		///   Tests that an expression is true. If not, it will write a message to the console and throw an exception.
		/// </summary>
		/// <param name="expression">The boolean expression to test.</param>      
		public static void Assert(bool expression, string message) {}
		
		/// <summary>
		///   Clears the console.
		/// </summary>
		public static void Clear() {}
		
		/// <summary>
		///   Prints an interactive listing of all properties of the object. This looks identical to the view that you would see in the DOM tab.
		/// </summary>
		public static void Dir(object obj) {}
		
		/// <summary>
		///   Prints the XML source tree of an HTML or XML element. This looks identical to the view that you would see in the HTML tab. You can click on any node to inspect it in the HTML tab.
		/// </summary>
		[ScriptName("dirxml")]
		public static void DirXml(object obj) {}
		
		/// <summary>
		///   Prints an interactive stack trace of JavaScript execution at the point where it is called.
		/// </summary>
		public static void Trace(string label) {}
		
		/// <summary>
		///   Writes a message to the console and opens a nested block to indent all future messages sent to the console. Call Console.GroupEnd() to close the block.
		/// </summary>
		[ExpandParams] public static void Group(string label, params object[] data) {}
		
		/// <summary>
		///   Like console.group(), but the block is initially collapsed.
		/// </summary>
		[ExpandParams] public static void GroupCollapsed(string label, params object[] data) {}
		
		/// <summary>
		///   Closes the most recently opened block created by a call to Console.Group() or Console.GroupCollapsed()
		/// </summary>
		public static void GroupEnd() {}
		
		/// <summary>
		///   Creates a new timer under the given name. Call console.timeEnd(name) with the same name to stop the timer and print the time elapsed.
		/// </summary>
		public static void Time(string label) {}
		
		/// <summary>
		///   Stops a timer created by a call to console.time(name) and writes the time elapsed.
		/// </summary>
		public static void TimeEnd(string label) {}
		
		/// <summary>
		///   Creates a time stamp, which can be used together with HTTP traffic timing to measure when a certain piece of code was executed.
		/// </summary>
		public static void TimeStamp(string label) {}
		
		/// <summary>
		///   Turns on the JavaScript profiler. 
		/// </summary>
		public static void Profile() {}
		
		/// <summary>
		///   Turns on the JavaScript profiler. 
		/// </summary>
		/// <param name="title">The optional argument title would contain the text to be printed in the header of the profile report.</param>
		public static void Profile(string title) {}
		
		/// <summary>
		///   Turns off the JavaScript profiler and prints its report.
		/// </summary>
		public static void ProfileEnd() {}
		
		/// <summary>
		///   Writes the number of times that the line of code where count was called was executed.       
		/// </summary>
		public static void Count() {}
		
		/// <summary>
		///   Writes the number of times that the line of code where count was called was executed. 
		/// </summary>
		/// <param name="title">The optional argument title will print a message in addition to the number of the count.</param>
		public static void Count(string title) {}
		
		/// <summary>
		///   Prints an error message together with an interactive stack trace of JavaScript execution at the point where the exception occurred.
		/// </summary>
		[ExpandParams] public static void Exception(object error, params object[] data) {}
		
		/// <summary>
		///   Allows to log provided data using tabular layout. The method takes one required parameter that represents table-like data (array of arrays or list of objects). The optional columns parameter can be used to specify columns and/or properties to be logged (see more at softwareishard.com).
		/// </summary>
		/// <param name="data">The table-like data (array of arrays or list of objects)</param>
		public static void Table(object data) {}
		
		/// <summary>
		///   Allows to log provided data using tabular layout. The method takes one required parameter that represents table-like data (array of arrays or list of objects). The optional columns parameter can be used to specify columns and/or properties to be logged (see more at softwareishard.com).
		/// </summary>
		/// <param name="data">The table-like data (array of arrays or list of objects)</param>
		/// <param name="columns">Can be used to specify columns and/or properties to be logged (see more at softwareishard.com)</param>
		public static void Table(object data, object columns) {}
	}
}