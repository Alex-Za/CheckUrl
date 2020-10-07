using CheckUrl.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckUrl
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileReader fileReader = new FileReader(args[0], args[1]);
                ProcessingUrl processingUrl = new ProcessingUrl(fileReader);
                ImageRequest imageRequest = new ImageRequest();
                List<string> responses = new List<string>();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


                int i = 1;
                foreach (string url in processingUrl.UrlList)
                {
                    string response = imageRequest.GetHttpStatusCode(url);
                    responses.Add(response);
                    Console.Write("\rОбработанно строк: {0}", i);
                    i++;
                }

                foreach (string resp in responses)
                {
                    Console.WriteLine(resp);
                }

                Console.Read();
            } catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
            
        }
    }
}
