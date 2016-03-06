// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

namespace TextDataGenerator.Data
{
    public class TextData : Core.IData
    {
        public string Text { get; }

        public TextData(string text)
        {
            Text = text;
        }

        public string GetData()
        {
            return Text;
        }
    }
}