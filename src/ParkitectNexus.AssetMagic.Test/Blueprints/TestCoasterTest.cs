using NUnit.Framework;

namespace ParkitectNexus.AssetMagic.Test.Blueprints
{
    [TestFixture]
    public class TestCoasterTest : BlueprintTest
    {
        public override string GetBlueprintPath()
        {
            return "/files/blueprints/test-coaster.png";
        }
    }
}