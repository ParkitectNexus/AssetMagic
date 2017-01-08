using System;
using NUnit.Framework;
using ParkitectNexus.AssetMagic.Converters;

namespace ParkitectNexus.AssetMagic.Test.Blueprints
{
    public abstract class BlueprintTest
    {
        public IBlueprint Blueprint;

        public abstract string GetBlueprintPath();

        [TestFixtureSetUp]
        public void LoadBlueprint()
        {
            Blueprint = BlueprintConverter.DeserializeFromFile(Environment.CurrentDirectory + GetBlueprintPath());
        }

        [Test]
        public void TryLoad()
        {
            Assert.True(Blueprint != null);
        }
    }
}