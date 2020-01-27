using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Pokemon
    {
        public enum Type
        {
            Normal,
            Fighting,
            Flying,
            Poison,
            Ground,
            Rock,
            Bug,
            Ghost,
            Steel,
            Fire,
            Water,
            Grass,
            Electric,
            Psychic,
            Ice,
            Dragon,
            Dark,
            Fairy,
            None
        }

        private string name;
        private Type primaryType;
        private Type secondaryType;

        public Pokemon(string name, Type primaryType, Type secondaryType = Type.None)
        {
            this.name = name;
            this.primaryType = primaryType;
            this.secondaryType = secondaryType;

        }

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


    }
}
