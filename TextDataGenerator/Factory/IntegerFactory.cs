// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    public class IntegerFactory : IFactory
    {
        public string Type { get { return "Integer"; } }

        [ParameterFactory]
        public int Max { get; set; }

        [ParameterFactory]
        public int Min { get; set; }

        [ParameterFactory]
        public string Format { get; set; }

        public void ResetDefaultValue()
        {
            Format = null;
            Max = int.MaxValue;
            Min = 0;
        }

        public IData CreateDataGenerator()
        {
            return new IntegerGenerator(Min, Max, Format);
        }
    }
}