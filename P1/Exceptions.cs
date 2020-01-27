using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class PokemonTypeNotRecognizedException : Exception
    {
        public PokemonTypeNotRecognizedException()
        {

        }
        public PokemonTypeNotRecognizedException(string type) : base("\"" + type + "\" is not a valid Pokemon Type")
        {

        }
    }

    public class PokedexMissingEntryException : Exception
    {
        public PokedexMissingEntryException()
        {

        }
    }
}
