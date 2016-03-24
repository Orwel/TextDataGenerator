// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    [Export("Integer", typeof(IFactory))]
    public class IntegerFactory : IFactory
    {
        [ParameterFactory]
        public int Min { get; set; } = 0;

        [ParameterFactory]
        public string Format { get; set; }

        [ParameterFactory]
        public int Max { get; set; } = int.MaxValue;

        public IData CreateDataGenerator()
        {
            if (Min > Max)
                throw new InvalidOperationException("Min>Max");
            return new IntegerGenerator(Min, Max, Format);
        }
    }
}