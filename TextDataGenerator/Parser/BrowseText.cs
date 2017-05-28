using System;

namespace TextDataGenerator.Parser
{
    public class BrowseText
    {
        public string Text { get; }
        public int Cursor { get; private set; }
        public int ReaderCursor { get; private set; }
        public string NewLine { get; set; } = Environment.NewLine;

        public char Current => Text[Cursor];
        public bool CurrentIsWhite => char.IsWhiteSpace(Current);
        public int Length => Text.Length;

        public BrowseText(string text)
        {
            Text = text;
        }

        public void SkipWhiteChar()
        {
            while (Cursor < Length && CurrentIsWhite)
                Cursor++;
        }

        public bool SkeepNewLine()
        {
            if (OccurrenceAtIndexOf(NewLine, Cursor))
            {
                Move(NewLine.Length);
                return true;
            }
            return false;
        }

        public void Move(int moveOf = 1)
        {
            Cursor += moveOf;
        }

        public char Get(int index)
        {
            return Text[index];
        }

        public char GetOffset(int offset)
        {
            return Get(Cursor + offset);
        }

        public string Read()
        {
            if (ReaderCursor == Cursor || ReaderCursor >= Length)
                return string.Empty;
            var endReaderCursor = Cursor > Length ? Length : Cursor;
            return Text.Substring(ReaderCursor, endReaderCursor - ReaderCursor);
        }

        public void JumpReaderCursorToCursor()
        {
            ReaderCursor = Cursor;
        }

        public bool StartWith(string str) =>
            OccurrenceAtIndexOf(str, Cursor);

        private bool OccurrenceAtIndexOf(string occurrence, int position) =>
            Text.IndexOf(occurrence, position) == position;

        public int CurrentLine()
        {
            var count = 1;
            var position = 0;
            while ((position = Text.IndexOf(NewLine, position)) != -1)
            {
                if (position >= Cursor)
                    break;
                count++;
                position += NewLine.Length;
            }
            return count;
        }
    }
}
