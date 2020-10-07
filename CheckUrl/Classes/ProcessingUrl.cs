using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckUrl.Classes
{
    class ProcessingUrl
    {
        FileReader fileReader;
        private List<string> urlList;
        public List<string> UrlList
        {
            get
            {
                if (urlList == null)
                {
                    GetImagesUrl();
                }
                return urlList;
            }
        }
        public ProcessingUrl(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public void GetImagesUrl()
        {
            urlList = new List<string>();
            foreach (DataRow row in fileReader.Data.Rows)
            {
                string brand = row.ItemArray[0].ToString().ToLower().Replace(" ", "-").Replace("®", string.Empty);
                string sku = row.ItemArray[1].ToString().ToLower().Replace(" ", string.Empty);
                string url = "https://images.carid.com/" + brand + "/items/" + sku + ".jpg";
                urlList.Add(url);
            }
        }
    }
}
