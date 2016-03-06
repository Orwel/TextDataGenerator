// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Text;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    public class FileLineFactory : IFactory
    {
        public string Type { get { return "TextLine"; } }

        [ParameterFactory(IsRequired = true)]
        public string Path { get; set; }

        [ParameterFactory]
        public string Encoding
        {
            set { encoding = System.Text.Encoding.GetEncoding(value); }
        }

        public Encoding encoding = null;

        public void ResetDefaultValue()
        {
            Path = null;
            encoding = Setting.Encoding;
        }

        public IData CreateDataGenerator()
        {
            return new FileLineSelector(Path, encoding);
        }
    }
}