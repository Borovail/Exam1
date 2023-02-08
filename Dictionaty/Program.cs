using Dictionary;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;

int input=0;

string Path="";
string Word, Translation;
var translations=new  List<string>();
Vocabulary vocabulary;
do
{
    try
    {


        ///////////////////////
        Console.WriteLine("0 - Select exicting vocabulary");
        Console.WriteLine("1 - Create Vocabulary");

        input = Convert.ToInt32(Console.ReadLine());

        switch (input)
        {
            case 0:
                Console.WriteLine("Chose Type Vocabulary");
                Console.WriteLine("Variants: ");
                Console.WriteLine("1 - English-Urkainan\t2 - Ukrainian-English\t3 - English-Russian\t4 - Russian-English");

                input = Convert.ToInt32(Console.ReadLine());

                CheckNoExistingDirectionary(ref Path, ref input);            
                break;

            case 1:
                Console.WriteLine("Chose Type Vocabulary");
                Console.WriteLine("Variants: ");
                Console.WriteLine("1 - English-Urkainan\t2 - Ukrainian-English\t3 - English-Russian\t4 - Russian-English");

                input = Convert.ToInt32(Console.ReadLine());

                CheckExistingDirectionary(ref Path, ref input);

                break;
            default:
                Console.WriteLine("Enter 0 or 1");
                break;
        }
    }
    catch
    {
        Console.WriteLine("Something went wrong. Try again");

    }

} while (input != 999);



vocabulary = new Vocabulary(Path);



do
{

    try
    {


        ///////////////////
        Console.WriteLine();
        Console.WriteLine("1 - Add new word");
        Console.WriteLine("2 - Edit word");
        Console.WriteLine("3 - Edit translation");
        Console.WriteLine("4 - Delete word");
        Console.WriteLine("5 - Delete translation");
        Console.WriteLine("6 - Translate the word");
        Console.WriteLine("7 - Exit");
        input = Convert.ToInt32(Console.ReadLine());

        switch (input)
        {

            case 1:
                Console.WriteLine("Enter the word\t\t\t\tReturn back - Enter Exit");
                Word = Console.ReadLine();

                if (Word.ToLower() == "exit") break;

                Console.WriteLine("Enter the translation");
                Translation = Console.ReadLine();

                translations.Add(Translation);

                do
                {
                    Console.WriteLine("Translation seccsfully added");
                    Console.WriteLine("If you want to add more translation, write new translation. If it is end enter Exit");
                    Translation = Console.ReadLine();

                    if (Translation.ToLower() == "exit")
                    {
                        Console.WriteLine("Translations seccsfully added"); 
                        break;
                    }
                    translations.Add(Translation);

                } while (true);

                vocabulary.AddNewWord(Word, translations);
                translations.Clear();
                break;

            case 2:
                Console.WriteLine("Enter word you want to edit\t\t\t\tReturn back - Enter Exit");
                Word= Console.ReadLine();

                if (Word.ToLower() == "exit") break;

                Console.WriteLine("Enter new word");
                vocabulary.EditWord(Word,Console.ReadLine());


                break;

            case 3:
                Console.WriteLine("Enter word you want which translation you want to edit\t\t\t\tReturn back - Enter Exit");
                Word = Console.ReadLine();

                if (Word.ToLower() == "exit") break;

                Console.WriteLine("Enter old translation");
                Translation= Console.ReadLine();

                Console.WriteLine("Enter new translation");
                vocabulary.EditTranslation(Word, Translation,Console.ReadLine());

                break;

            case 4:
                Console.WriteLine("Enter the word you want to delete\t\t\t\tReturn back - Enter Exit");
                Word = Console.ReadLine();

                if (Word.ToLower() == "exit") break;

                vocabulary.DeleteWord(Word);
                break;

            case 5:
                Console.WriteLine("Enter the word which translation you want to delete\t\t\t\tReturn back - Enter Exit");
                Word = Console.ReadLine();

                if (Word.ToLower() == "exit") break;

                Console.WriteLine("Enter the translation");
                Translation = Console.ReadLine();

                vocabulary.DeleteTranslation(Word, Translation);
                break;

            case 6:
                Console.WriteLine("Enter word you want to translate\t\t\t\tReturn back - Enter Exit");
                Word = Console.ReadLine();

                if (Word.ToLower() == "exit") break;

                vocabulary.SearchTranslation(Word);

                break;

            default:
                if (input != 7)
                {
                Console.WriteLine("Wrong number");
                }
                break;
        }
    }
    catch
    {
        Console.WriteLine("Something went wrong. Try again");
    }
} while (input != 7);
































void CheckExit(string exit)
{
    if (exit.ToLower() == "exit")
        return;
}


void CheckExistingDirectionary(ref string path,ref int input)
{

    switch (input)
    {
        case 1:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "English-Urkainan.json";
            break;
        case 2:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "Ukrainian-English.json";

            break;
        case 3:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "English-Russian.json";

            break;
        case 4:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "Russian-English.json";
            break;

        default:
            Console.WriteLine("Unknown type");
            return;
    }

    if (File.Exists(path))
    {
        Console.WriteLine("This type of vocabulary already exist");
        return;
    }

    Console.WriteLine("Vocabulary seccesfully created");
    input = 999;
}
void CheckNoExistingDirectionary(ref string path,ref int input)
{

    switch (input)
    {
        case 1:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "English-Urkainan.json";
            break;
        case 2:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "Ukrainian-English.json";

            break;
        case 3:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "English-Russian.json";

            break;
        case 4:
            path = $"{Environment.CurrentDirectory}\\Vocabulary" + "Russian-English.json";
            break;

        default:
            Console.WriteLine("Unknown Type");
            return;
    }

    if (!File.Exists(path))
    {
        Console.WriteLine("This type of vocabulary does not exist");
        return;
    }

    Console.WriteLine("Vocabulary Seccesfully chosen");
    input = 999;

}

