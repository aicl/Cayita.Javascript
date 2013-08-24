using jQueryApi;

namespace Cayita.Demo
{
	public partial class App
	{

		void GoHomeClick(jQueryEvent evt)
		{
			evt.PreventDefault ();
			GoHome ();
		}
		void GoHome()
		{
			Work.Empty ();
			var rq =jQuery.GetData<string> ("code/demohome.html");
			rq.Done (s=> {		
				Work.InnerHTML= s;
			});

		}
		
		void GoLicense(jQueryEvent evt)
		{
			evt.PreventDefault ();
			Work.Empty ();
			Work.Append (@"<div class=""well"">
			             <p>Copyright AICL.</p>
			             <p>Licensed under the Apache License, Version 2.0 (the ""License""); you may not use this work except in compliance with the License. You may obtain a copy of the License in the LICENSE file, or at:</p><p><a target=""_blank"" href=""http://www.apache.org/licenses/LICENSE-2.0"">http://www.apache.org/licenses/LICENSE-2.0</a></p><p>Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an ""AS IS"" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.</p></div>");

			             }

		void GoContact(jQueryEvent evt)
		{
			evt.PreventDefault ();
			Work.Empty ();
			Work.Append (@"<div class=""well"">
	<p><a target=""_blank"" href=""https://github.com/angelcolmenares"">https://github.com/angelcolmenares</a>
	<p><a target=""_blank"" href=""https://github.com/aicl"">https://github.com/aicl</a>
	</p></div>");

		}

		void GoAbout(jQueryEvent evt)
		{
			evt.PreventDefault ();
			Work.Empty ();
			Work.Append (@"<div class=""well"">
<p>Cayita is a library for building responsive webapps using C#  as base language and the Saltarelle compiler 
<a href=""http://www.saltarelle-compiler.com"" target=""_blank"">
http://www.saltarelle-compiler.com
</a>
</p>
</p></div>");

		}

	}
}

