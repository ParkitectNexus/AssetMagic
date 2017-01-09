using NUnit.Framework;

namespace ParkitectNexus.AssetMagic.Test.Parks
{
    [TestFixture]
    public class UnnamedParkTest : ParkTest
    {
        public override string getParkPath()
        {
            return "/files/parks/unnamed-park.txt";
        }
    }
}