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

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ParkitectNexus.AssetMagic.JsonConverters
{
    public class MiniJsonContractResolver : DefaultContractResolver
    {
        #region Overrides of DefaultContractResolver

        /// <summary>
        ///     Resolves the default <see cref="T:Newtonsoft.Json.JsonConverter" /> for the contract.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///     The contract's default <see cref="T:Newtonsoft.Json.JsonConverter" />.
        /// </returns>
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (objectType == typeof (float))
                return null;
            if (objectType == typeof (double))
                return null;
            return base.ResolveContractConverter(objectType);
        }

        #endregion
    }
}