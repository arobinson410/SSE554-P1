using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P1_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void checkPokemonCreation()
        {
            P1.Pokemon pokemon = new P1.Pokemon("Rhydon", P1.Pokemon.Type.Ground, P1.Pokemon.Type.Rock);
            Assert.IsTrue(pokemon.Name.Equals("Rhydon") && pokemon.PrimaryType.Equals(P1.Pokemon.Type.Ground) && pokemon.SecondaryType.Equals(P1.Pokemon.Type.Rock));
        }
    }
}
