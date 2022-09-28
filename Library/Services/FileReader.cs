using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Newtonsoft.Json;

namespace Library.Services
{
    internal class FileReader
    {
        private readonly StreamReader _readStream;
        private readonly string _path = @"Library.json";

        public FileReader()
        {
            try
            {
                if (!File.Exists(_path))
                {
                    using (File.Create(_path)) ;
                }
                _readStream = new StreamReader(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public List<Book> GetFileData()
        {
            var booksList = JsonConvert.DeserializeObject<List<Book>>(_readStream.ReadToEnd());
            _readStream.Close();
            return booksList;
        }
    }
}
