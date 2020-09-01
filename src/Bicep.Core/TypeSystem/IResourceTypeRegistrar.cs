// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;
using Bicep.Core.Resources;

namespace Bicep.Core.TypeSystem
{
    public interface IResourceTypeRegistrar
    {
        void RegisterType(ResourceTypeReference resourceType, Func<ResourceType> accessor);

        ResourceType LookupType(ResourceTypeReference reference);
    }
}