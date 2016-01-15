using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkitectNexus.AssetMagic.Elements
{
    public interface IMod : IDataObject
    {
        string Identifier { get; set; }
        string Name { get; set; }

    }
}
