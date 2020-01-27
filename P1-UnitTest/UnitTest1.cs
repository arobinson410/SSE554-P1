using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P1_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("FileReader")]
        public void CheckImport()
        {
            List<P1.Pokemon> pokemonList = new List<P1.Pokemon>();
            pokemonList.AddRange(P1.FileReader.getPokemonFromFile(@"D:\Users\arobi\Desktop\pokemondatabase.txt"));
            Assert.AreEqual(pokemonList.Count, 151, "Pokemon list not of expected size");
        }

        [TestMethod, TestCategory("Pokemon")]
        public void CheckPokemonCreation()
        {
            P1.Pokemon pokemon = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            Assert.IsTrue(pokemon.Name.Equals("Rhydon") && pokemon.PrimaryType.Equals(P1.Pokemon.Type.Ground) && pokemon.SecondaryType.Equals(P1.Pokemon.Type.Rock), "Test Pokemon Creation Successful");
        }
        [TestMethod, TestCategory("Pokemon")]
        public void CheckIsEqual()
        {
            P1.Pokemon pokemon1 = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            P1.Pokemon pokemon2 = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            Assert.IsTrue(pokemon1 == pokemon2);
        }
        [TestMethod, TestCategory("Pokemon")]
        public void CheckPokemonToString()
        {
            P1.Pokemon rhydon = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            string testString = "Pokemon: Rhydon\nTypes: Ground-Rock\n";
            Assert.IsTrue(testString.Equals(rhydon.ToString()));
        }

        [TestMethod, TestCategory("Pokedex")]
        public void CheckGetPokemonByNumber()
        {
            P1.Pokedex kanto = new P1.Pokedex(@"D:\Users\arobi\Desktop\pokemondatabase.txt");
            P1.Pokemon rhydon = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            Assert.IsTrue(rhydon == kanto.getPokemonByNumber(112));
        }

        [TestMethod, TestCategory("Pokedex"), TestProperty("Test", "1")]
        public void CheckWeaknessesAndResistances()
        {
            P1.Pokemon rhydon = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            Assert.AreEqual(4.0, P1.Pokedex.getWeaknessVal(rhydon, P1.Pokemon.Type.Grass), "Incorrect Value: Rhydon is 4x times weak to grass");
        }

        [TestMethod, TestCategory("Pokedex")]
        public void CheckGetPokemonByName()
        {
            P1.Pokedex kanto = new P1.Pokedex(@"D:\Users\arobi\Desktop\pokemondatabase.txt");
            P1.Pokemon rhydon = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);

            Assert.IsTrue(kanto.getPokemonByName("Rhydon") == rhydon);
        }


    }
}
