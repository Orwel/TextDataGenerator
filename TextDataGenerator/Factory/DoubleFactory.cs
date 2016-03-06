// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    public class DoubleFactory : IFactory
    {
        public string Type { get { return "Double"; } }

        [ParameterFactory]
        public double Max { get; set; }

        [ParameterFactory]
        public double Min { get; set; }

        [ParameterFactory]
        public string Format { get; set; }

        public void ResetDefaultValue()
        {
            Format = null;
            Max = Double.MaxValue;
            Min = 0d;
        }

        public IData CreateDataGenerator()
        {
            if (Min > Max)
                throw new InvalidOperationException("Min>Max");
            return new DoubleGenerator(Min, Max, Format);
        }
    }
}