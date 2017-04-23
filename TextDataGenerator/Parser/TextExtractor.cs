// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;

namespace TextDataGenerator.Parser
{
    public class TextExtractor
    {
        public string Text { get; }
        public int Line { get; private set; } = 1;
        public int NextLine { get; private set; } = 1;
        public int Cursor { get; private set; }
        public string NewLine { get; set; } = Environment.NewLine;

        public TextExtractor(string text)
        {
            Text = text;
        }

        public string Next(string endText, bool cutEndText)
        {
            Line = NextLine;
            var indexOfEnd = Text.IndexOf(endText, Cursor, StringComparison.InvariantCulture);
            if (indexOfEnd < 0)
                return null;
            if (indexOfEnd == 0)
                return string.Empty;
            if (!cutEndText)
                indexOfEnd += endText.Length;

            var subText = SubText(Cursor, indexOfEnd);
            Cursor += subText.Length;
            NextLine += CountOccurrence(subText, NewLine);

            return subText;
        }

        public string NextToEnd()
        {
            return Text.Substring(Cursor);
        }

        public bool SkeepNewLine()
        {
            if (OccurrenceAtIndexOf(Text, NewLine, Cursor))
            {
                NextLine++;
                Cursor += NewLine.Length;
                return true;
            }
            return false;
        }

        private string SubText(int startIndex, int endIndex) =>
            Text.Substring(startIndex, endIndex - startIndex);

        private static bool OccurrenceAtIndexOf(string str, string occurrence, int position) =>
            str.IndexOf(occurrence, position) == position;

        private static int CountOccurrence(string str, string occurrence)
        {
            int count = 0;
            int position = 0;
            while ((position = str.IndexOf(occurrence, position)) != -1)
            {
                count++;
                position += occurrence.Length;
            }
            return count;
        }
    }
}