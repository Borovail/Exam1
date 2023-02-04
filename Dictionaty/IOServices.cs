using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class IOServices
    {
        readonly string _path;

        public IOServices(string path)
        {
            _path = path;
        }

        void SaveData(List<string> vocabulary)
        {
            using (StreamWriter writer = File.CreateText(_path))
            {
                string output = JsonConvert.SerializeObject(vocabulary);
                writer.WriteLine(output);
            }
        }

        List<string> LoadData()
        {
            if (!File.Exists(_path))
            {
                File.CreateText(_path).Dispose();
                return new List<string>();
            }

            using (var reader = File.OpenText(_path))
            {
                var vocabulary = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<string>>(vocabulary);
            }
        }

    }
}
