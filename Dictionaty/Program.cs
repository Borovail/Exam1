using Dictionary;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;

int input;

string Path = $"{Environment.CurrentDirectory}\\Vocabulary";
string Word, Translation;
var translations=new List<string>();
Vocabulary vocabulary;
do
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

            CheckNoExistingDirectionary(ref Path, input);
            input = 3;
            break;

        case 1:
            Console.WriteLine("Chose Type Vocabulary");
            Console.WriteLine("Variants: ");
            Console.WriteLine("1 - English-Urkainan\t2 - Ukrainian-English\t3 - English-Russian\t4 - Russian-English");

            input = Convert.ToInt32(Console.ReadLine());

            CheckExistingDirectionary(ref Path, input);
            input = 3;
            break;
    }


} while (input != 3);



vocabulary = new Vocabulary(Path);



do
{


    ///////////////////
    Console.WriteLine("1 - Add new word");
    Console.WriteLine("2 - Edit word");
    Console.WriteLine("3 - Delete word");
    Console.WriteLine("4 - Delete translation");
    Console.WriteLine("5 - Translate the word");
    Console.WriteLine("6 - Exit");
    input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {

        case 1:

            Console.WriteLine("Enter the word");
            Word = Console.ReadLine();

            Console.WriteLine("Enter the translation");
            Translation = Console.ReadLine();
            translations.Add(Translation);
            do
            {
                Console.WriteLine("If you want to add more translation, write new translation. If it is end enter Exit");
                Translation = Console.ReadLine();

                if (Translation.ToLower() == "exit") break;

                translations.Add(Translation);

            } while (true);

            vocabulary.AddNewWord(Word, translations);

            break;

        case 2:

            break;

        case 3:
            Console.WriteLine("Enter the word you want to delete");
            Word = Console.ReadLine();
            vocabulary.DeleteWord(Word);
            break;

        case 4:
            Console.WriteLine("Enter the word which translation you want to delete");
            Word = Console.ReadLine();

            Console.WriteLine("Enter the translation");
            Translation = Console.ReadLine();

            vocabulary.DeleteTranslation(Word, Translation);
            break;

        case 5:
            Console.WriteLine("Enter word you want to translate");
            Word = Console.ReadLine();

            vocabulary.SearchTranslation(Word);

            break;
    }


} while (input != 6);




































void CheckExistingDirectionary(ref string path, int input)
{

    switch (input)
    {
        case 1:
            path += "English-Urkainan";
            break;
        case 2:
            path += "Ukrainian-English";

            break;
        case 3:
            path += "English-Russian";

            break;
        case 4:
            path += "Russian-English";
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

}
void CheckNoExistingDirectionary(ref string path, int input)
{

    switch (input)
    {
        case 1:
            path += "English-Urkainan";
            break;
        case 2:
            path += "Ukrainian-English";

            break;
        case 3:
            path += "English-Russian";

            break;
        case 4:
            path += "Russian-English";
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

}

