﻿// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Builder
{
    [Export("Repeat", typeof(IFactory))]
    public class RepeatBuilder : BuilderBase
    {
        [ParameterFactory(IsRequired = true)]
        public int Min { get; set; }

        [ParameterFactory]
        public int Max { get; set; }

        public override string EndTag => "EndRepeat";

        public override IData CreateDataGenerator()
        {
            if (Min <= 0)
                throw new InvalidOperationException("Min < 1");
            if (Max == 0)
                Max = Min;
            if (Min > Max)
                throw new InvalidOperationException("Min>Max");
            return new RepeatData(Max, Min, Datas);
        }
    }
}