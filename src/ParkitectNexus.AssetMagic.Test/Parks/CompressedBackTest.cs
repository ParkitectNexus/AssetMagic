using NUnit.Framework;

namespace ParkitectNexus.AssetMagic.Test.Parks
{
    [TestFixture]
    public class CompressedBackTest : ParkTest
    {
        public override string getParkPath()
        {
            return "/files/parks/compressedback.park";
        }
    }
}