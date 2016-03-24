// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;
using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Builder
{
    [Export("Template", typeof(IFactory))]
    public class TemplateBuilder : IBuilder
    {
        private List<IData> datas = new List<IData>();

        public string EndTag { get { return null; } }

        public void Add(IData dataGenerator) => datas.Add(dataGenerator);

        public IData CreateDataGenerator()
        {
            return new TemplateData(datas);
        }
    }
}