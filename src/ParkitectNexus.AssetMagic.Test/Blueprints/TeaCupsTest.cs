using NUnit.Framework;

namespace ParkitectNexus.AssetMagic.Test.Blueprints
{
    [TestFixture]
    public class TeaCupsTest : BlueprintTest
    {
        public override string GetBlueprintPath()
        {
            return "/files/blueprints/tea-cups.png";
        }
    }
}