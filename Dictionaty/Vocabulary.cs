using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Vocabulary
    {
        IOServices _ioServices;
        BindingList<Word> _vocabulary;
        public Vocabulary(string path)
        {
            _ioServices = new IOServices(path);

            try
            {
                _vocabulary = _ioServices.LoadData();
            }
            catch
            {
                Console.WriteLine("Something went wrong(-_-)");
            }

            _vocabulary.ListChanged += _vocabulary_ListChanged;
        }

        private void _vocabulary_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemAdded)
            {
                _ioServices.SaveData(sender);
            }
        }

        public void AddNewWord(string word, string translation)
        {
            _vocabulary.Add(new Word { Word = word, Translation = translation });
        }

        public void CheckExistingDirectionary(ref string path, string name)
        {
            if (!File.Exists(path + name))
            {
                Console.WriteLine("This type of vocabulary alredy exist");
            }

            path += name;
            Console.WriteLine("Vocabulary seccesfully created");
        }
        public void CheckNoExistingDirectionary(ref string path, string name)
        {
            if (!File.Exists(path + name))
            {
                path += name;
            }
            Console.WriteLine("This type of vocabulary does not exist");
        }
    }

}
