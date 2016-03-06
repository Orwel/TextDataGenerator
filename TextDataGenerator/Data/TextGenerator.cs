// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using NLipsum.Core;
using System;
using System.Text;

namespace TextDataGenerator.Data
{
    public class TextGenerator : Core.IData
    {
        private Paragraph paragraphOption;
        private LipsumGenerator lipsum;

        public int MinParagraph { get; }
        public int MaxParagraph { get; }
        public int MinSentence { get { return (int)paragraphOption.MinimumSentences; } }
        public int MaxSentence { get { return (int)paragraphOption.MaximumSentences; } }
        public int MinWord { get { return (int)paragraphOption.SentenceOptions.MinimumWords; } }
        public int MaxWord { get { return (int)paragraphOption.SentenceOptions.MaximumWords; } }

        public TextGenerator(int minParagraph, int maxParagraph, int minSentence, int maxSentence, int minWord, int maxWord)
        {
            MinParagraph = minParagraph;
            MaxParagraph = maxParagraph;

            paragraphOption = new Paragraph((uint)minSentence, (uint)maxSentence);
            paragraphOption.SentenceOptions.MinimumWords = (uint)minWord;
            paragraphOption.SentenceOptions.MaximumWords = (uint)maxWord;
            lipsum = new LipsumGenerator();
        }

        public string GetData()
        {
            var sentences = lipsum.GenerateParagraphs(Core.RandomNumber.Random.Next(MinParagraph, MaxParagraph), paragraphOption);
            var builder = new StringBuilder();
            foreach (var s in sentences)
                builder.AppendLine(s + Environment.NewLine);
            return builder.ToString();
        }
    }
}