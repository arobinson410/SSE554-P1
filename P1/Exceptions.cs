using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    /// <summary>
    /// Exception to handle invalid Pokemon types
    /// </summary>
    public class PokemonTypeNotRecognizedException : Exception
    {
        public PokemonTypeNotRecognizedException()
        {

        }
        public PokemonTypeNotRecognizedException(string type) : base("\"" + type + "\" is not a valid Pokemon Type")
        {

        }
    }
    /// <summary>
    /// Exception to handle missing entries in the Pokedex
    /// </summary>
    public class PokedexMissingEntryException : Exception
    {
        public PokedexMissingEntryException()
        {

        }
    }
}
