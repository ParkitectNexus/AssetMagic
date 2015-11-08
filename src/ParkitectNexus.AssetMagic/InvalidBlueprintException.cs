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
using System.Runtime.Serialization;

namespace ParkitectNexus.AssetMagic
{
    /// <summary>
    ///     Represents errors occuring during reading of blueprints.
    /// </summary>
    [Serializable]
    public class InvalidBlueprintException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidBlueprintException" /> class.
        /// </summary>
        public InvalidBlueprintException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidBlueprintException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidBlueprintException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidBlueprintException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public InvalidBlueprintException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidBlueprintException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        protected InvalidBlueprintException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}