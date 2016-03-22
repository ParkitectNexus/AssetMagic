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
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using ParkitectNexus.AssetMagic.Data.Attributes;

namespace ParkitectNexus.AssetMagic.Data
{
    public class DataElementProxy<T> : RealProxy where T : DataElement
    {
        private readonly T _instance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataElementProxy{T}" /> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <exception cref="ArgumentNullException">Thrown if instance is null.</exception>
        public DataElementProxy(T instance) : base(typeof (T))
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            _instance = instance;
        }
        
        #region Overrides of RealProxy

        /// <summary>
        ///     When overridden in a derived class, invokes the method that is specified in the provided
        ///     <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> on the remote object that is represented by the current
        ///     instance.
        /// </summary>
        /// <returns>
        ///     The message returned by the invoked method, containing the return value and any out or ref parameters.
        /// </returns>
        /// <param name="msg">
        ///     A <see cref="T:System.Runtime.Remoting.Messaging.IMessage" /> that contains a
        ///     <see cref="T:System.Collections.IDictionary" /> of information about the method call.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="Infrastructure" />
        /// </PermissionSet>
        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = (IMethodCallMessage) msg;
            var method = (MethodInfo) methodCall.MethodBase;
            try
            {
                // Invoke method
                var result = method.Invoke(_instance, methodCall.InArgs);

                // Check to see if the method was a property setter
                if (method.Name.StartsWith("set_"))
                {
                    PropertyInfo propertyInfo = null;

                    if (method.Name.Length > 4)
                        propertyInfo = typeof (T).GetProperty(method.Name.Substring(4));

                    if (propertyInfo != null)
                    {
                        // Property exists... Check to see if the property shouldn't be ignored.
                        var ignoreDataAttribute = propertyInfo.GetCustomAttribute<IgnoreDataAttribute>();

                        if (ignoreDataAttribute == null && propertyInfo.CanRead && propertyInfo.CanWrite)
                            _instance.PropertyWasSet(propertyInfo);
                    }
                }
                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException && e.InnerException != null)
                {
                    return new ReturnMessage(e.InnerException, msg as IMethodCallMessage);
                }

                return new ReturnMessage(e, msg as IMethodCallMessage);
            }
        }

        #endregion
    }
}