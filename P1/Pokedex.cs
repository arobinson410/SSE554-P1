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

        public Pokedex(string filename)
        {
            dex = FileReader.getPokemonFromFile(filename);
        }

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

        public static double getWeaknessVal(Pokemon p, Pokemon.Type damageType)
        {
            double toReturn = 1;
            toReturn *= weaknessesAndResistances[(int)damageType][(int)p.PrimaryType];

            if(p.SecondaryType != Pokemon.Type.None)
                toReturn *= weaknessesAndResistances[(int)damageType][(int)p.SecondaryType];

            return toReturn;
        }

        public Pokemon getPokemonByNumber(int n)
        {
            return dex[n-1];
        }

        public List<Pokemon> Dex
        {
            get
            {
                return dex;
            }
        }

    }
}
