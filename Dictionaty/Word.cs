using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Words
    {
        public string Word { get; set; }
        public List<string> Translation = new List<string>(); 
       public Words(string w,List<string> t)
        {
            Word = w;
            for (int i = 0; i < t.Count; i++)
            {
                Translation.Add(t[i]);
            }
        }
        public Words()
        {

        }
    }
}
