// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class IntegerGenerator : IData
    {
        public int Max { get; }
        public int Min { get; }
        public string Format { get; }

        public IntegerGenerator(int min, int max, string format)
        {
            Min = min;
            Max = max;
            Format = format;
        }

        public string GetData() => IntegerToString(GetNextInteger());

        public int GetNextInteger() => RandomNumber.Random.Next(Min, Max);

        public string IntegerToString(int value) => Format == null ? value.ToString() : value.ToString(Format);
    }
}