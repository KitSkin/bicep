// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
using System;

namespace Bicep.Core.TypeSystem
{
    public class TypeProperty : ITypeProperty
    {
        public TypeProperty(string name, TypeSymbol type, TypePropertyFlags flags = TypePropertyFlags.None)
        {
            this.Name = name;
            this.Type = type;
            this.Flags = flags;
        }

        public string Name { get; }

        public TypeSymbol Type { get; }

        public TypePropertyFlags Flags { get; }
    }

    public class LazyTypeProperty : ITypeProperty
    {
        private readonly Lazy<TypeSymbol> lazyType;

        public LazyTypeProperty(string name, Func<TypeSymbol> typeFunc, TypePropertyFlags flags = TypePropertyFlags.None)
        {
            this.Name = name;
            this.lazyType = new Lazy<TypeSymbol>(typeFunc, isThreadSafe: false);
            this.Flags = flags;
        }

        public string Name { get; }

        public TypeSymbol Type => lazyType.Value;

        public TypePropertyFlags Flags { get; }
    }

    public interface ITypeProperty
    {
        string Name { get; }

        TypeSymbol Type { get; }

        TypePropertyFlags Flags { get; }
    }
}
