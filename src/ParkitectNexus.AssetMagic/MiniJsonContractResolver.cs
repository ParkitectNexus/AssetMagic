using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ParkitectNexus.AssetMagic
{
    public class MiniJsonContractResolver : DefaultContractResolver
    {
        #region Overrides of DefaultContractResolver

        /// <summary>
        /// Resolves the default <see cref="T:Newtonsoft.Json.JsonConverter"/> for the contract.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// The contract's default <see cref="T:Newtonsoft.Json.JsonConverter"/>.
        /// </returns>
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if(objectType == typeof(float))
                return null;
            if (objectType == typeof(double))
                return null;
            return base.ResolveContractConverter(objectType);
        }

        #endregion
    }
}