using System;

namespace ParkitectNexus.AssetMagic
{
    public class FileHeader : DataObject
    {
        public DateTime Date
        {
            get { return new DateTime((long) this["date"]); }
            set { this["date"] = value.Ticks; }
        }
    }
}