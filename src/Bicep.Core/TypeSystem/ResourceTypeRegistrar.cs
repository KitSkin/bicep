// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Bicep.Core.Resources;

namespace Bicep.Core.TypeSystem
{
    public class ResourceTypeRegistrar : IResourceTypeRegistrar
    {
        public static IResourceTypeRegistrar Instance { get; } = new ResourceTypeRegistrar();

        private IDictionary<ResourceTypeReference, Func<ResourceType>> ResourceAccessors { get; }

        private ResourceTypeRegistrar()
        {
            ResourceAccessors = new Dictionary<ResourceTypeReference, Func<ResourceType>>(ResourceTypeReferenceComparer.Instance);
        }

        public void RegisterType(ResourceTypeReference typeReference, Func<ResourceType> accessor)
        {
            ResourceAccessors[typeReference] = accessor;
        }

        public ResourceType LookupType(ResourceTypeReference typeReference)
        {
            if (ResourceAccessors.TryGetValue(typeReference, out var accessor))
            {
                return accessor();
            }

            return new ResourceType(typeReference.FullyQualifiedType, LanguageConstants.TopLevelResourceProperties, additionalPropertiesType: null, typeReference);
        }
    }
}