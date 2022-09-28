using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Newtonsoft.Json;

namespace Library.Services
{
    internal class FileWriter
    {
        private readonly StreamWriter _writeStream;
        private readonly string _path = @"Library.json";

        public FileWriter()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    File.Create(_path);
                }
                _writeStream = new StreamWriter(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void WriteToFile(List<Book> booksList)
        {
            _writeStream.WriteLine(JsonConvert.SerializeObject(booksList));
            _writeStream.Close();
        }
    }
}
