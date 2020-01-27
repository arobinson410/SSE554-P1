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
