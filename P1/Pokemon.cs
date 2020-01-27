using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Pokemon
    {
        /// <summary>
        /// A simple enum to keep track of Pokemon types
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Normal Type
            /// </summary>
            Normal,
            /// <summary>
            /// Fighting Type
            /// </summary>
            Fighting,
            /// <summary>
            /// Flying Typep
            /// </summary>
            Flying,
            /// <summary>
            /// Poison Type
            /// </summary>
            Poison,
            /// <summary>
            /// Ground Type
            /// </summary>
            Ground,
            /// <summary>
            /// Rock Type
            /// </summary>
            Rock,
            /// <summary>
            /// Bug Type
            /// </summary>
            Bug,
            /// <summary>
            /// Ghost Type
            /// </summary>
            Ghost,
            /// <summary>
            /// Steel Type
            /// </summary>
            Steel,
            /// <summary>
            /// Fire Type
            /// </summary>
            Fire,
            /// <summary>
            /// Water Type
            /// </summary>
            Water,
            /// <summary>
            /// Grass Type
            /// </summary>
            Grass,
            /// <summary>
            /// Electric Type
            /// </summary>
            Electric,
            /// <summary>
            /// Psychic Type
            /// </summary>
            Psychic,
            /// <summary>
            /// Ice Type
            /// </summary>
            Ice,
            /// <summary>
            /// Dragon Typpe
            /// </summary>
            Dragon,
            /// <summary>
            /// Dark Type
            /// </summary>
            Dark,
            /// <summary>
            /// Faiy Type
            /// </summary>
            Fairy,
            /// <summary>
            /// No Type
            /// </summary>
            None
        }

        private string name;
        private Type primaryType;
        private Type secondaryType;

        /// <summary>
        /// Creates a Pokemon. Pokemon can have either one or two types, the second type is optional in the constructor
        /// </summary>
        /// <param name="name">Name of the Pokemon</param>
        /// <param name="primaryType">The primary type of the Pokemon</param>
        /// <param name="secondaryType">The secondary type of the Pokemon, if it has one</param>
        public Pokemon(string name, Type primaryType, Type secondaryType = Type.None)
        {
            this.name = name;
            this.primaryType = primaryType;
            this.secondaryType = secondaryType;

        }

        /// <summary>
        /// Name of the Pokemon
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        /// <summary>
        /// Primary type of the Pokemon
        /// </summary>
        public Type PrimaryType
        {
            get
            {
                return primaryType;
            }
            set
            {
                primaryType = value;
            }
        }
        /// <summary>
        /// Secondary type of the Pokemon, if it has one
        /// </summary>
        public Type SecondaryType
        {
            get
            {
                return secondaryType;
            }
            set
            {
                secondaryType = value;
            }
        }
        /// <summary>
        /// See's if a Pokemon's Name and Type(s) match
        /// </summary>
        /// <param name="a">Pokemon To Compare</param>
        /// <param name="b">Pokemon To Compare</param>
        /// <returns>True if the pokemon name and type(s) match. False otherwise</returns>
        public static bool operator ==(Pokemon a, Pokemon b)
        {
            if (a.Name.Equals(b.Name) && ((a.PrimaryType == b.PrimaryType && a.SecondaryType == b.SecondaryType) || (a.PrimaryType == b.SecondaryType && a.SecondaryType == b.PrimaryType)))
                return true;
            else
                return false;
        }
        /// <summary>
        /// See's if a Pokemon's Name and Type(s) match
        /// </summary>
        /// <param name="a">Pokemon To Compare</param>
        /// <param name="b">Pokemon To Compare</param>
        /// <returns>False if the pokemon name and type(s) match. True otherwise</returns>
        public static bool operator !=(Pokemon a, Pokemon b)
        {
            if (a.Name.Equals(b.Name) && ((a.PrimaryType == b.PrimaryType && a.SecondaryType == b.SecondaryType) || (a.PrimaryType == b.SecondaryType && a.SecondaryType == b.PrimaryType)))
                return false;
            else
                return true;
        }
        /// <summary>
        /// Prints the Pokemon's name and Type(s)
        /// </summary>
        /// <returns>Formatted string containing the Pokemon's Name and Type(s)</returns>
        public override string ToString()
        {
            string toReturn = "Pokemon: " + Name + "\n";
            if (primaryType == Type.None || secondaryType == Type.None)
            {
                toReturn += "Type: " + primaryType.ToString() + "\n";
            }
            else
            {
                toReturn += "Types: " + primaryType.ToString() + "-" + secondaryType.ToString() + "\n";
            }

            return toReturn;
        }
    }
}
