using System;
using System.Runtime.CompilerServices;

namespace Cayita.UI
{
	[IgnoreNamespace, Imported (ObeysTypeSystem = true)]
	public static class Alertify
	{
		/// <summary>
		/// Creates the log.
		/// </summary>
		/// <param name="logType">Log type: info||success||error </param>
		/// <param name="message">Message.</param>
		/// <param name="delay">Delay in ms, 0 means persistent. defautl=5000 ms</param>
		[InlineCode("Alertify.log.create({logType},{message},{delay})")]
		public static void CreateLog(string logType, string message, int delay=5000)
		{

		}

		[InlineCode("Alertify.log.success({message},{delay})")]
		public static void LogSuccess(string message, int delay=5000)
		{
			
		}

		[InlineCode("Alertify.log.info({message},{delay})")]
		public static void LogInfo(string message, int delay=5000)
		{
			
		}


		/// <summary>
		/// Creates the log.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="delay">Delay in ms, 0 means persistent. defautl=0 ms</param>
		[InlineCode("Alertify.log.error({message},{delay})")]
		public static void LogError(string message, int delay=0)
		{	
		}

	}
}

