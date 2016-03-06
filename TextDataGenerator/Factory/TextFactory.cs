// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using TextDataGenerator.Core;
using TextDataGenerator.Data;

namespace TextDataGenerator.Factory
{
    public class TextFactory : IFactory
    {
        public string Type { get { return "Text"; } }

        [ParameterFactory]
        public int MinParagraph { get; set; }

        [ParameterFactory]
        public int MaxParagraph { get; set; }

        [ParameterFactory]
        public int MinSentence { get; set; }

        [ParameterFactory]
        public int MaxSentence { get; set; }

        [ParameterFactory]
        public int MinWord { get; set; }

        [ParameterFactory]
        public int MaxWord { get; set; }

        public void ResetDefaultValue()
        {
            MinParagraph = 0;
            MaxParagraph = 10;
            MinSentence = 1;
            MaxSentence = 10;
            MinWord = 1;
            MaxWord = 100;
        }

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