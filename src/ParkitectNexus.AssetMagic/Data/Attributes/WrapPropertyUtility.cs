// ParkitectNexus.AssetMagic
// Copyright 2016 Tim Potze
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
using System.Reflection;

namespace ParkitectNexus.AssetMagic.Data.Attributes
{
    public static class WrapPropertyUtility
    {
        public static string GetWrappedPropertyName(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));
            var attribute = propertyInfo.GetCustomAttribute<WrapPropertyAttribute>();
            var name = char.ToLowerInvariant(propertyInfo.Name[0]) + propertyInfo.Name.Substring(1);

            if (attribute?.Name != null)
                name = attribute.Name;

            return name;
        }
    }
}