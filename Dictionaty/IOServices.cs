using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void SaveData<T>(T vocabulary)
        {
            using (StreamWriter writer = File.CreateText(_path))
            {
                string output = JsonConvert.SerializeObject(vocabulary);
                writer.WriteLine(output);
            }
        }

        public BindingList<Words> LoadData()
        {
            var data= new BindingList<Words>();
            var trans= new List<string>();
            trans.Add("");

            data.Add(new Words ("", trans ));
            if (!File.Exists(_path))
            {
                File.CreateText(_path).Dispose();
                return new BindingList<Words>();
            }

            using (var reader = File.OpenText(_path))
            {
                var vocabulary = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Words>>(vocabulary);
            }
        }

    }
}
