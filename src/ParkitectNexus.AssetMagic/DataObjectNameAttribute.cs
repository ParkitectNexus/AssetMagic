using System;

namespace ParkitectNexus.AssetMagic
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DataObjectNameAttribute : Attribute
    {
        public DataObjectNameAttribute(string regularExpression)
        {
            if (regularExpression == null) throw new ArgumentNullException(nameof(regularExpression));
            RegularExpression = regularExpression;
        }

        public string RegularExpression { get; set; }
    }
}