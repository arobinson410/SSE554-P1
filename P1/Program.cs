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
        /// <summary>
        /// Gets the input for the main menu
        /// </summary>
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
        /// <summary>
        /// Handles the user wanting to search by the Pokedex number
        /// </summary>
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

                pokemonMenu(kanto.getPokemonByNumber(toSearch));
            }
            catch (FormatException)
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
        /// <summary>
        /// Handles the user wanting to serach by the Pokemon name
        /// </summary>
        private static void searchByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of your desired Pokemon:");
            string toSearch;
            try
            {
                toSearch = Console.ReadLine();
                pokemonMenu(kanto.getPokemonByName(toSearch));
            }
            catch (PokedexMissingEntryException)
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
        /// <summary>
        /// Handles the menu once a Pokemon has been searched for
        /// </summary>
        /// <param name="p">Pokemon returned from search</param>
        private static void pokemonMenu(Pokemon p)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(p);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1.) Damage Type Calculation");
                Console.WriteLine("2.) Main Menu");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        damageMenu(p);
                        break;
                    case "2":
                        return;
                    default:
                        return;
                }
            }
        }
        /// <summary>
        /// Handles the damage menu
        /// </summary>
        /// <param name="p">Pokemon returned from search</param>
        private static void damageMenu(Pokemon p)
        {
            Console.Clear();
            Console.Write(p);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("What kind of damage would you like to do?");
            for (int i = 0; i < (int)Pokemon.Type.None; i++)
            {
                Console.WriteLine((i + 1) + "). " + (Pokemon.Type)i);
            }

            int testType;
            try
            {
                testType = int.Parse(Console.ReadLine());

                if (testType < 0 || testType > 18)
                    throw new IndexOutOfRangeException();

                Console.WriteLine(p.Name + "is affected " + Pokedex.getWeaknessVal(p, (Pokemon.Type)(testType - 1)) + "x by " + ((Pokemon.Type)(testType - 1)).ToString() + " type moves.");
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("That is an invalid input");
            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Please select a value between 1 and 18");
            }
            finally
            {
                Console.WriteLine("Press Enter to Continue");
                Console.Read();
            }
        }
    }
}
