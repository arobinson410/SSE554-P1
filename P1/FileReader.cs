using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public static class FileReader
    {
        public static Pokemon[] getPokemonFromFile(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            return new Pokemon[1];
        }

    }
}
