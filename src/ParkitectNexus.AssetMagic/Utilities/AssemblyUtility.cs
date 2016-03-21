﻿// ParkitectNexus.AssetMagic
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
using System.Linq;
using System.Reflection;

namespace ParkitectNexus.AssetMagic.Utilities
{
    internal static class AssemblyUtility
    {
        public static Type[] GetTypesInNameSpaces(this Assembly assembly, bool includeSubNamespaces,
            params string[] namespaces)
        {
            return
                assembly.GetTypes()
                    .Where(
                        t => namespaces.Any(n => t.Namespace.StartsWith(n)) && namespaces.Any(
                            n => n == t.Namespace || (includeSubNamespaces && t.Namespace.StartsWith(n + "."))) &&
                             t.IsClass && !t.IsInterface && !t.IsEnum && t.IsPublic)
                    .ToArray();
        }
    }
}