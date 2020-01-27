using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Pokedex
    {
        private List<Pokemon> dex;
        /// <summary>
        /// Create a Pokedex using the data from a text file
        /// </summary>
        /// <param name="filename"></param>
        public Pokedex(string filename)
        {
            dex = FileReader.getPokemonFromFile(filename);
        }
        /// <summary>
        /// Weaknesses and resistances are defined by the game, this table makes referencing them much easier
        /// </summary>
        private static protected double[][] weaknessesAndResistances = new double[][]
        {
            new double[]{1,1,1,1,1,.5,1,0,.5,1,1,1,1,1,1,1,1,1}, //Normal
            new double[]{2,1,.5,.5,1,2,.5,0,2,1,1,1,1,.5,2,1,2,.5 }, //Fighting
            new double[]{1,2,1,1,1,.5,2,1,.5,1,1,2,.5,1,1,1,1,1}, //Flying
            new double[]{1,1,1,.5,.5,.5,1,.5,0,1,1,2,1,1,1,1,1,5}, //Poison
            new double[]{1,1,0,2,1,2,.5,1,2,2,1,.5,2,1,1,1,1,1}, //Ground
            new double[]{1,.5,2,1,.5,1,2,1,.5,2,1,1,1,1,2,1,1,1}, //Rock
            new double[]{1,.5,.5,.5,1,1,1,.5,.5,.5,1,2,1,2,1,1,2,.5}, //Bug
            new double[]{0,1,1,1,1,11,1,2,1,1,1,1,1,2,1,1,.5,1}, //Ghost
            new double[]{1,1,1,1,1,2,1,1,.5,.5,.5,1,.5,1,2,1,1,2}, ///Steel
            new double[]{1,1,1,1,1,.5,2,1,2,.5,.5,2,1,1,2,.5,1,1}, //Fire
            new double[]{1,1,1,1,2,2,1,1,1,2,.5,.5,1,1,1,.5,1,1}, //Water
            new double[]{1,1,.5,.5,2,2,.5,1,.5,.5,2,.5,1,1,1,.5,1,1}, //Grass
            new double[]{1,1,2,1,0,1,1,1,1,1,2,.5,.5,1,1,.5,1,1}, //Electric
            new double[]{1,2,1,2,1,1,1,1,.5,1,1,1,1,.5,1,1,0,1}, //Psychic
            new double[]{1,1,2,1,2,1,1,1,.5,.5,.5,2,1,1,.5,2,1,1}, //Ice
            new double[]{1,1,1,1,1,1,1,1,.5,1,1,1,1,1,1,2,1,0}, //Dragon
            new double[]{1,.5,1,1,1,1,1,2,1,1,1,1,1,2,1,1,.5,.5}, //Dark
            new double[]{1,2,1,.5,1,1,1,1,.5,.5,1,1,1,1,1,2,2,1}, //Fairy
        };
        /// <summary>
        /// The weakness of a Pokemon to a damage type.
        /// </summary>
        /// <param name="p">Pokemon to make the comparison to</param>
        /// <param name="damageType">The type of the move used against the selected pokemon</param>
        /// <returns>The damage multiplier of the attack. The value will be 0x, 0.5x, 1x, 2x, or 4x</returns>
        public static double getWeaknessVal(Pokemon p, Pokemon.Type damageType)
        {
            double toReturn = 1;
            toReturn *= weaknessesAndResistances[(int)damageType][(int)p.PrimaryType];

            if(p.SecondaryType != Pokemon.Type.None)
                toReturn *= weaknessesAndResistances[(int)damageType][(int)p.SecondaryType];

            return toReturn;
        }
        /// <summary>
        /// Returns a Pokemon based on its number in the Pokedex
        /// </summary>
        /// <param name="n">Pokedex Number</param>
        /// <returns>Pokemon object matching the provided Pokedex number</returns>
        public Pokemon getPokemonByNumber(int n)
        {
            return dex[n-1];
        }
        /// <summary>
        /// Returns a Pokemon based on its name in the Pokedex
        /// </summary>
        /// <param name="s">Name of the Pokemon</param>
        /// <returns>Pokemon object matching the provided name</returns>
        /// <exception cref="P1.PokedexMissingEntryException"/>
        public Pokemon getPokemonByName(string s)
        {
            for(int i = 0; i < dex.Count; i++)
            {
                if (dex[i].Name.Equals(s))
                {
                    return dex[i];
                }
            }

            throw new PokedexMissingEntryException();
        }
        /// <summary>
        /// Returns the contents of the Pokedex as a List
        /// </summary>
        public List<Pokemon> Dex
        {
            get
            {
                return dex;
            }
        }

    }
}
