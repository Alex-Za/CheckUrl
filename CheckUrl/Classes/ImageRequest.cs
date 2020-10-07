using CheckUrl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckUrl.Classes
{
    class ImageRequest : HttpRequest
    {
        public string GetHttpStatusCode(string url)
        {
            string result = "";
            var request = HttpWebRequest.Create(url);
            request.Method = "GET";
            //request.Method = "HEAD";
            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        result = response.StatusCode.ToString();
                        response.Close();
                    }
                }
                if (result == "OK")
                {
                    result = "images" + url.Substring(24);
                }
                return result;
            }
            catch (WebException)
            {
                return "404";
            }
            
        }
    }
}
