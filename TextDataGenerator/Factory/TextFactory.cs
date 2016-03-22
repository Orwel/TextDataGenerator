// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.ComponentModel.Composition;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    [Export("Text", typeof(IFactory))]
    public class TextFactory : IFactory
    {
        [ParameterFactory]
        public int MinParagraph { get; set; } = 0;

        [ParameterFactory]
        public int MaxParagraph { get; set; } = 10;

        [ParameterFactory]
        public int MinSentence { get; set; } = 1;

        [ParameterFactory]
        public int MaxSentence { get; set; } = 10;

        [ParameterFactory]
        public int MinWord { get; set; } = 1;

        [ParameterFactory]
        public int MaxWord { get; set; } = 100;

        public IData CreateDataGenerator()
        {
            ValidateMinMax(MinParagraph, MaxParagraph, nameof(MinParagraph), nameof(MaxParagraph));
            ValidateMinMax(MinWord, MaxWord, nameof(MinWord), nameof(MaxWord));
            ValidateMinMax(MinSentence, MaxSentence, nameof(MinSentence), nameof(MaxSentence));
            return new TextGenerator(MinParagraph, MaxParagraph, MinSentence, MaxSentence, MinWord, MaxWord);
        }

        private static void ValidateMinMax(int min, int max, string minName, string maxName)
        {
            if (min < 0)
                throw new InvalidOperationException(minName + "<0");
            if (max < 0)
                throw new InvalidOperationException(maxName + "<0");
            if (min > max)
                throw new InvalidOperationException(minName + ">" + maxName);
        }
    }
}