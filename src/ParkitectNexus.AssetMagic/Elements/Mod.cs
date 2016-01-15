using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkitectNexus.AssetMagic.Elements
{
    public class Mod : DataObject, IMod
    {

        public Mod()
        {

        }

        public Mod(IDictionary<string, object> data) : base(data)
        {

        }

        #region Implementation of IMod
        public string Identifier
        {
            get{ return Get<string>("identifier"); }
            set{ Set("identifier", value); }
        }

        public string Name
        {
            get { return Get<string>("name"); }
            set { Set("name", value); }
        }
        #endregion
    }
}
