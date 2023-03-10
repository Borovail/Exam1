using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Vocabulary
    {
        IOServices _ioServices;
        BindingList<Words> _vocabulary;

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

        public void AddNewWord(string word, List<string> translation)
        {

            Words words = new Words();
            words.Word = word;
            for (int i = 0; i < translation.Count; i++)
            {
                words.Translation.Add(translation[i]);
            }

            _vocabulary.Add(words);
        }

        public void SearchTranslation(string Searchedword)
        {
            foreach (var words in _vocabulary)
            {

                if (words.Word == Searchedword)
                {

                    foreach (var translation in words.Translation)
                    {
                        Console.Write(translation + " ");
                    }

                    Console.WriteLine();

                    return;
                }

            }

            Console.WriteLine("Unknown word");
        }

        public void DeleteWord(string wordForDelete)
        {

            for (int i = 0; i < _vocabulary.Count; i++)
            {
                if (_vocabulary[i].Word == wordForDelete)
                {
                    _vocabulary.RemoveAt(i);

                    Console.WriteLine(wordForDelete + " seccesfully deleted");

                    return;
                }
            }

            Console.WriteLine("Unknown word");
        }


        public void DeleteTranslation(string Searchedword, string translationForDelete)
        {

            for (int i = 0; i < _vocabulary.Count; i++)
            {

                if (_vocabulary[i].Word == Searchedword)
                {
                    if (_vocabulary[i].Translation.Count == 1)
                    {
                        Console.WriteLine("You can not delete last translation of word");

                        return;
                    }

                    for (int j = 0; j < _vocabulary[i].Translation.Count; j++)
                    {
                        if (_vocabulary[i].Translation[j] == translationForDelete)
                        {
                            _vocabulary[i].Translation.RemoveAt(j);

                            Console.WriteLine(translationForDelete + " seccesfully deleted");

                            return;
                        }
                    }
                }
            }

            Console.WriteLine("Unknown word");
        }

        public void EditWord(string oldword, string neword)
        {
            foreach (var words in _vocabulary)
            {
                if (words.Word == oldword)
                {
                    words.Word = neword;
                }
            }

            _ioServices.SaveData(_vocabulary);
        }
        public void EditTranslation(string word, string oldtranslation, string newtranslation)
        {
            foreach (var words in _vocabulary)
            {
                if (words.Word == word)
                {
                    for (int i = 0; i < words.Translation.Count; i++)
                    {

                        if (words.Translation[i] == oldtranslation)
                        {
                            words.Translation[i] = newtranslation;
                        }

                    }
                }
            }

            _ioServices.SaveData(_vocabulary);
        }
    }


}

