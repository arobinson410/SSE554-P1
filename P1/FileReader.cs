using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    /// <summary>
    /// The file reader is a class that handles all File IO interactions. By keeping all these methods in a single class, they can be reference anywhere in the document and still use the same set of file readers.
    /// </summary>
    public static class FileReader
    {
        private enum Attributes
        {
            /// <summary>
            /// The first attribute on the line of the text file. All text from the start of the line to the first ':'
            /// </summary>
            name,
            /// <summary>
            /// The second attribute on the line of the text file. All text between the first ':' and the last character of the line
            /// </summary>
            types
        };

        /// <summary>
        /// Prepares a list of Pokemon from the file provided.
        /// Each line of the text file should be formatted: "{NAME}:{TYPE1},{TYPE2};"
        /// </summary>
        /// <param name="filename">File path that contains information to populate the Pokedex with.</param>
        /// <returns> A List of Pokemon where each entry is populated with a line from the text file.</returns>
        /// <exception cref="P1.PokemonTypeNotRecognizedException">Occurs when an unrecognized type is provided</exception>
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
