// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    [Export("Double", typeof(IFactory))]
    public class DoubleFactory : IFactory
    {
        [ParameterFactory]
        public double Max { get; set; } = double.MaxValue;

        [ParameterFactory]
        public double Min { get; set; } = 0d;

        [ParameterFactory]
        public string Format { get; set; }

        public IData CreateDataGenerator()
        {
            if (Min > Max)
                throw new InvalidOperationException("Min>Max");
            return new DoubleGenerator(Min, Max, Format);
        }
    }
}