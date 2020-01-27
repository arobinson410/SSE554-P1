using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Program
    {
        private static Pokedex kanto;
        private static bool go = true;

        static void Main(string[] args)
        {
            kanto = new Pokedex(@"D:\Users\arobi\Desktop\pokemondatabase.txt");

            while (go)
            {
                printMainMenu();
                getInput();
                Console.Clear();
            }
        }

        private static void printMainMenu()
        {
            Console.WriteLine("Welcome to the Kanto Pokedex!\nPlease choose from the following options:");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1.) Search By Number");
            Console.WriteLine("2.) Search by Name");
            Console.WriteLine("3.) Exit");
        }

        private static void getInput()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    searchByNumber();
                    break;
                case "2":
                    searchByName();
                    break;
                case "3":
                    go = false;
                    break;
                default:
                    break;
            }
        }

        private static void searchByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of your desired Pokemon:");
            int toSearch;
            try
            {
                toSearch = int.Parse(Console.ReadLine());

                if (toSearch < 0 || toSearch > 151)
                    throw new IndexOutOfRangeException();

                Console.Write(kanto.getPokemonByNumber(toSearch));
            }
            catch(FormatException)
            {
                Console.Clear();
                Console.WriteLine("That is an invalid input");
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Please select a value between 1 and 151");
            }
            finally
            {
                Console.WriteLine("Press Enter to Continue");
                Console.Read();
            }
            

        }

        private static void searchByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of your desired Pokemon:");
            string toSearch;
            try
            {
                toSearch = Console.ReadLine();


                Console.Write(kanto.getPokemonByName(toSearch));
            }
            catch(PokedexMissingEntryException)
            {
                Console.Clear();
                Console.WriteLine("That name is not in the Pokedex");
            }
            finally
            {
                Console.WriteLine("Press Enter to Continue");
                Console.Read();
            }
        }
    }
}
