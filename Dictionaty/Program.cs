using Dictionary;
using System.ComponentModel;

int input;

string Path =$"{Environment.CurrentDirectory}\\Vocabulary";
string Word, Translation;
Vocabulary vocabulary;
do
{
    Console.WriteLine("0 - Select exicting vocabulary");
    Console.WriteLine("1 - Create Vocabulary");
    Console.WriteLine("2 - Add new word");
    Console.WriteLine("3 - Edit word");
    Console.WriteLine("4 - Delete word");
    Console.WriteLine("5 - Delete translation");
    Console.WriteLine("6 - Translate the word");

    input = Convert.ToInt32(Console.ReadLine());

    switch (input)
    {
        case 0:
            Console.WriteLine("Chose Type Vocabulary");
            Console.WriteLine("Variants: ");
            Console.WriteLine("1 - English-Urkainan\t2 - Ukrainian-English\t3 - English-Russian\t4 - Russian-English");
            break;
        case 1:
            Console.WriteLine("Chose Type Vocabulary");
            Console.WriteLine("Variants: ");
            Console.WriteLine("1 - English-Urkainan\t2 - Ukrainian-English\t3 - English-Russian\t4 - Russian-English");

            input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    vocabulary.CheckExistingDirectionary(ref Path, "English-Urkainan");
                    break;
                case 2:
                    CheckExistFile(ref Path, "Ukrainian-English");

                    break;
                case 3:
                    CheckExistFile(ref Path, "English-Russian");

                    break;
                case 4:
                    CheckExistFile(ref Path, "Russian-English");

                    break;
            }

            vocabulary = new Vocabulary(Path);

            break;
        case 2:

            Console.WriteLine("Enter the word");
            Word = Console.ReadLine();

            Console.WriteLine("Enter the translation");
            Translation = Console.ReadLine();



            vocabulary.AddNewWord(Word, Translation);
            
            break;
            case 3:

            break;
            case 6:
            Console.WriteLine("Enter word you want to translate");
            break;
    }
}while(true);



