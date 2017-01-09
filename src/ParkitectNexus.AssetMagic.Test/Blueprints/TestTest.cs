using NUnit.Framework;

namespace ParkitectNexus.AssetMagic.Test.Blueprints
{
    [TestFixture]
    public class TestTest : BlueprintTest
    {
        public override string GetBlueprintPath()
        {
            return "/files/blueprints/test.png";
        }
    }
}