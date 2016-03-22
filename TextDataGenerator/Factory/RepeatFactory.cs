// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using TextDataGenerator.Builder;
using TextDataGenerator.Core;

namespace TextDataGenerator.Factory
{
    [Export("Repeat", typeof(IFactory))]
    public class RepeatFactory : IFactory
    {
        [ParameterFactory(IsRequired = true)]
        public int Min { get; set; } = 0;

        [ParameterFactory]
        public int Max { get; set; } = 0;

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