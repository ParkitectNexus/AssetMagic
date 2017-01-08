using System;
using NUnit.Framework;
using ParkitectNexus.AssetMagic.Converters;

namespace ParkitectNexus.AssetMagic.Test.Parks
{
    public abstract class ParkTest
    {
        public ISavegame Savegame;

        public abstract string getParkPath();

        [TestFixtureSetUp]
        public void LoadBlueprint()
        {
            Savegame = SavegameConverter.DeserializeFromFile(Environment.CurrentDirectory + getParkPath());
        }

        [Test]
        public void TryLoad()
        {
            Assert.True(Savegame != null);
        }
    }
}