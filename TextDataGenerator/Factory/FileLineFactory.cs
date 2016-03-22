// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.ComponentModel.Composition;
using System.Text;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    [Export("TextLine", typeof(IFactory))]
    public class FileLineFactory : IFactory
    {
        [ParameterFactory(IsRequired = true)]
        public string Path { get; set; }

        [ParameterFactory]
        public string Encoding
        {
            set { encoding = System.Text.Encoding.GetEncoding(value); }
        }

        private Encoding encoding = Setting.Encoding;

        public IData CreateDataGenerator()
        {
            return new FileLineSelector(Path, encoding);
        }
    }
}