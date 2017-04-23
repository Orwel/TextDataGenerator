// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using NLipsum.Core;
using System;
using System.Text;

namespace TextDataGenerator.Data
{
    public class TextGenerator : Core.IData
    {
        private readonly Paragraph paragraphOption;
        private readonly LipsumGenerator lipsum;

        public int MinParagraph { get; }
        public int MaxParagraph { get; }
        public int MinSentence => (int)paragraphOption.MinimumSentences;
        public int MaxSentence => (int)paragraphOption.MaximumSentences;
        public int MinWord => (int)paragraphOption.SentenceOptions.MinimumWords;
        public int MaxWord => (int)paragraphOption.SentenceOptions.MaximumWords;

        public TextGenerator(int minParagraph, int maxParagraph, int minSentence, int maxSentence, int minWord, int maxWord)
        {
            MinParagraph = minParagraph;
            MaxParagraph = maxParagraph;

            paragraphOption = new Paragraph((uint) minSentence, (uint) maxSentence)
            {
                SentenceOptions =
                {
                    MinimumWords = (uint) minWord,
                    MaximumWords = (uint) maxWord
                }
            };
            lipsum = new LipsumGenerator();
        }

        public string GetData()
        {
            var sentences = lipsum.GenerateParagraphs(Core.RandomNumberProvider.Current.NextInt32(MinParagraph, MaxParagraph), paragraphOption);
            var builder = new StringBuilder();
            foreach (var s in sentences)
                builder.AppendLine(s + Environment.NewLine);
            return builder.ToString();
        }
    }
}