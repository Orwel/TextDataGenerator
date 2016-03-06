// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using TextDataGenerator.Builder;
using TextDataGenerator.Core;

namespace TextDataGenerator.Factory
{
    public class RepeatFactory : IFactory
    {
        public string Type { get { return "Repeat"; } }

        [ParameterFactory(IsRequired = true)]
        public int Min { get; set; }

        [ParameterFactory]
        public int Max { get; set; }

        public void ResetDefaultValue()
        {
            Min = 0;
            Max = 0;
        }

        public IData CreateDataGenerator()
        {
            if (Min <= 0)
                throw new InvalidOperationException("Min < 1");
            if (Max == 0)
                Max = Min;
            if (Min > Max)
                throw new InvalidOperationException("Min>Max");
            return new RepeatBuilder(Max, Min);
        }
    }
}