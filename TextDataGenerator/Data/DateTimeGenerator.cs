// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class DateTimeGenerator : Core.IData
    {
        public DateTime Min { get; }
        public DateTime Max { get; }
        public string Format { get; }

        public DateTimeGenerator(DateTime min, DateTime max, string format)
        {
            Min = min;
            Max = max;
            Format = format;
        }

        public string GetData()
        {
            DateTime randomDateTime = RandomNumber.NextDateTime(Min, Max);
            return (Format == null) ? randomDateTime.ToString() : randomDateTime.ToString(Format);
        }
    }
}