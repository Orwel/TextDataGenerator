// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

namespace TextDataGenerator.Core
{
    public interface IBuilder : IFactory
    {
        string EndTag { get; }
        void Add(IData dataGenerator);
    }
}