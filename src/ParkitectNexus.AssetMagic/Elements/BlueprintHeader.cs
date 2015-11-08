// ParkitectNexus.AssetMagic
// Copyright 2015 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Linq;

namespace ParkitectNexus.AssetMagic.Elements
{
    public class BlueprintHeader : FileHeader, IBlueprintHeader
    {
        #region Implementation of IBlueprintHeader

        public virtual string Name
        {
            get { return Get<string>("name"); }
            set { Set("name", value); }
        }

        public virtual string[] ContentTypes
        {
            get { return Get<string[]>("types"); }
            set { Set("types", value); }
        }

        public virtual string ContentType
        {
            get { return ContentTypes.FirstOrDefault(); }
            set { ContentTypes = new[] {value}; }
        }

        #endregion
    }
}