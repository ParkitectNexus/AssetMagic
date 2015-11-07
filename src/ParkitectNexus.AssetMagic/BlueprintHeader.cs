using System.Linq;

namespace ParkitectNexus.AssetMagic
{
    public class BlueprintHeader : FileHeader
    {
        public string Name
        {
            get { return Get<string>("name"); }
            set { Set("name", value); }
        }

        public int GameVersion
        {
            get { return Get<int>("gameVersion"); }
            set { Set("gameVersion", value); }
        }

        public int SavegameVersion
        {
            get { return Get<int>("savegameVersion"); }
            set { Set("savegameVersion", value); }
        }

        public string GameVersionName
        {
            get { return Get<string>("gameVersionName"); }
            set { Set("gameVersionName", value); }
        }

        public string[] ContentTypes
        {
            get { return Get<string[]>("types"); }
            set { Set("types", value); }
        }

        public string ContentType
        {
            get { return ContentTypes.FirstOrDefault(); }
            set { ContentTypes = new[] {value}; }
        }
    }
}