using System;
using System.IO;
using System.Net;
using System.Text;
using NBoilerpipe.Extractors;

namespace Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{

            String url = "http://www.yellowpencil.com/about";
		    //String url = "http://www.l3s.de/web/page11g.do?sp=page11g&link=ln104g&stu1g.LanguageISOCtxParam=en";
//			String url = "http://www.dn.se/nyheter/vetenskap/annu-godare-choklad-med-hjalp-av-dna-teknik";

			String page = String.Empty;
			WebRequest request = WebRequest.Create (url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
			Stream stream = response.GetResponseStream ();
			using (StreamReader streamReader = new StreamReader (stream, Encoding.UTF8)) {
				page = streamReader.ReadToEnd ();
			}
			
			String text = ArticleExtractor.INSTANCE.GetText (page);
			Console.WriteLine ("Text: \n" + text);

            Console.WriteLine();
            Console.WriteLine("Finished test!  Press any key to exit..");
            Console.ReadKey();
		}
	}
}
