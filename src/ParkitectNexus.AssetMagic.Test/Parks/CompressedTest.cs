using NUnit.Framework;

namespace ParkitectNexus.AssetMagic.Test.Parks
{
    [TestFixture]
    public class CompressedParkTest : ParkTest
    {
        public override string getParkPath()
        {
            return "/files/parks/compressed.park";
        }
    }
}