// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    [Export("DateTime", typeof(IFactory))]
    public class DateTimeFactory : IFactory
    {
        [ParameterFactory]
        public DateTime Max { get; set; } = DateTime.MaxValue;

        [ParameterFactory]
        public DateTime Min { get; set; } = DateTime.MinValue;

        [ParameterFactory]
        public string Format { get; set; }

        public DateTimeFactory()
        {
            Console.WriteLine("Trololo");
        }

        public IData CreateDataGenerator()
        {
            return new DateTimeGenerator(Min, Max, Format);
        }
    }
}