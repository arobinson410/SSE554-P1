using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public static class FileReader
    {
        private enum Attributes
        {
            name,
            types
        };

        /// <summary>
        /// Prepares a list of Pokemon from the file provided.
        /// Each line of the text file should be formatted: "{NAME}:{TYPE1},{TYPE2};"
        /// </summary>
        /// <param name="filename">File path that contains information to populate the Pokedex with.</param>
        /// <returns> A List of Pokemon where each entry is populated with a line from the text file.</returns>
        /// <exception cref="P1.PokemonTypeNotRecognizedException"></exception>
        public static List<Pokemon> getPokemonFromFile(string filename)
        {
            List<Pokemon> toReturn = new List<Pokemon>();

            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string temp = line.Substring(0, line.Length - 1);

                string[] attribs = temp.Split(':');
                string[] types = attribs[(int)Attributes.types].Split(',');

                try
                {
                    toReturn.Add(new Pokemon(attribs[(int)Attributes.name], (Pokemon.Type)Enum.Parse(typeof(Pokemon.Type), types[0]), (Pokemon.Type)Enum.Parse(typeof(Pokemon.Type), types[1])));
                }
                catch (ArgumentException)
                {
                    throw new PokemonTypeNotRecognizedException();
                }
            }

            return toReturn;
        }
    }
}
