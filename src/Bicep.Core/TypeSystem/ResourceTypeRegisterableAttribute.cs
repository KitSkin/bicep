// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Linq;
using System.Reflection;

namespace Bicep.Core.TypeSystem
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class ResourceTypeRegisterableAttribute : Attribute
    {
        public const string RegisterMethodName = "Register";

        public static void RegisterAllTypesInAssembly(IResourceTypeRegistrar registrar, Assembly assembly)
        {
            var supportingTypes = assembly.GetTypes().Where(x => x.IsDefined(typeof(ResourceTypeRegisterableAttribute)));

            var registerMethods = supportingTypes.Select(x => x.GetMethod(
                RegisterMethodName,
                BindingFlags.Public | BindingFlags.Static));

            foreach (var registerMethod in registerMethods)
            {
                registerMethod.Invoke(null, new [] { registrar });
            }
        }
    }
}