using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cas24
{
    class Program
    {
        static void Main(string[] args)
        {
            string Choice;
            do
            {
                Console.Clear();
                Console.WriteLine("QA Telefonski Imenik\n");
                Console.WriteLine("1. Unos novog imena");
                Console.WriteLine("2. Listanje imenika");
                Console.WriteLine("3. Pretraga");
                Console.WriteLine("Q. Kraj rada");

                Choice = Console.ReadLine();

                switch(Choice.ToUpper())
                {
                    case "1":
                        AddNewName();
                        break;
                    case "2":
                        ListNames();
                        break;
                    case "3":
                        SearchForName();
                        break;
                    case "Q":
                        break;
                    default:
                        break;
                }
            } while (Choice.ToUpper() != "Q");
        }

        static void AddNewName()
        {
            string FirstName, LastName, Address, Phone, Email;
            string Choice;
            do
            {
                FirstName = Utils.GetUserInput("Unesite ime");
                LastName = Utils.GetUserInput("Unesite prezime");
                Address = Utils.GetUserInput("Unesite adresu");
                Phone = Utils.GetUserInput("Unesite broj telefona");
                Email = Utils.GetUserInput("Unesite email");

                FileManagement.Write(FirstName, LastName, Address, Phone, Email);

                Choice = Utils.GetUserInput("\nDa li zelite unos novog imena? Za da, otkucajte 'Y'.");
            } while (Choice.ToUpper() == "Y");
        }

        static void ListNames()
        {
            Console.Clear();
            DisplayNames(FileManagement.Read());
        }

        static void SearchForName()
        {
            string Search = Utils.GetUserInput("Unesite termin za pretragu (najmanje 3 slova)");
            if ((Search == "") || (Search.Length < 3))
            {
                return;
            }

            List<string> SearchResults = new List<string>();
            List<string> ListOfNames = FileManagement.Read();

            foreach(string Entry in ListOfNames)
            {
                if (Entry.ToUpper().Contains(Search.ToUpper()))
                {
                    SearchResults.Add(Entry);
                }
            }

            DisplayNames(SearchResults);

        }

        static void DisplayNames(List<string> ListOfNames)
        {
            string[] Fields;
            Console.WriteLine("Ime\t\tPrezime\t\tTelefon\t\tEmail\t\tAdresa");
            Console.WriteLine("----------------------------------------------------------------------");
            foreach(string Entry in ListOfNames)
            {
                Fields = Entry.Split(';');
                Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", Fields[0], Fields[1], Fields[3], Fields[4], Fields[2]);
            }
            Console.ReadKey();
        }
    }
}
