// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;
using TextDataGenerator.Core;

namespace TextDataGenerator.Builder
{
    public abstract class BuilderBase : IBuilder
    {
        protected readonly List<IData> Datas = new List<IData>();
        public void Add(IData dataGenerator) => Datas.Add(dataGenerator);
        public abstract string EndTag { get; }
        public abstract IData CreateDataGenerator();
    }
}
