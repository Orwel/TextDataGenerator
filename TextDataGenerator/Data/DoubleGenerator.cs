// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class DoubleGenerator : IData
    {
        public double Max { get; }
        public double Min { get; }
        public string Format { get; }

        public DoubleGenerator(double min, double max, string format)
        {
            Min = min;
            Max = max;
            Format = format;
        }

        public string GetData() => DoubleToString(GetNextDouble());

        public double GetNextDouble() => RandomNumberProvider.Current.NextDouble(Min, Max);

        public string DoubleToString(double value) => Format == null ? value.ToString() : value.ToString(Format);
    }
}