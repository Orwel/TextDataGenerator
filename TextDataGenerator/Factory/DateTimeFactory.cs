// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    public class DateTimeFactory : IFactory
    {
        public string Type { get { return "DateTime"; } }

        [ParameterFactory]
        public DateTime Max { get; set; }

        [ParameterFactory]
        public DateTime Min { get; set; }

        [ParameterFactory]
        public string Format { get; set; }

        public void ResetDefaultValue()
        {
            Format = null;
            Max = DateTime.MaxValue;
            Min = DateTime.MinValue;
        }

        public IData CreateDataGenerator()
        {
            return new DateTimeGenerator(Min, Max, Format);
        }
    }
}