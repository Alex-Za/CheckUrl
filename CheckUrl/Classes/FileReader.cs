using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckUrl.Classes
{
    class FileReader
    {
        private DataTable data;
        private string filePath;
        private string tableName;
        public FileReader(string filePath, string tableName)
        {
            this.filePath = filePath;
            this.tableName = tableName;
        }
        public DataTable Data
        {
            get
            {
                if (data == null)
                    ReadDataFromExcel(filePath);
                return data;
            }
        }
        private void ReadDataFromExcel(string filePath)
        {
            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    DataTable dataTable = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (c) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    }).Tables[tableName];

                    data = dataTable;
                }
            }
        }
    }
}
