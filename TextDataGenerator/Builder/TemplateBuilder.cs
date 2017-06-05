// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Builder
{
    [Export("Template", typeof(IFactory))]
    public class TemplateBuilder : BuilderBase
    {
        public override string EndTag => null;

        public override IData CreateDataGenerator()
        {
            return new TemplateData(Datas);
        }
    }
}