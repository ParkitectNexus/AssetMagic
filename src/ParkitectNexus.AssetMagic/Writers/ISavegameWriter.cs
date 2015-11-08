using System.IO;

namespace ParkitectNexus.AssetMagic.Writers
{
    public interface ISavegameWriter
    {
        string Serialize(ISavegame savegame);
        void Serialize(ISavegame savegame, Stream stream);
    }
}