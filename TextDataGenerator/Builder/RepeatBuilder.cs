// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Text;
using TextDataGenerator.Core;

namespace TextDataGenerator.Builder
{
    public class RepeatBuilder : TextBuilder, IBuilder, IData
    {
        public new string EndTag { get { return "EndRepeat"; } }

        public int Max { get; }
        public int Min { get; }

        public RepeatBuilder(int max, int min)
        {
            Max = max;
            Min = min;
        }

        public new string GetData()
        {
            var builder = new StringBuilder();
            var nbRepeat = RandomNumber.Random.Next(Min, Max);
            for (int nRepeat = 0; nRepeat < nbRepeat; nRepeat++)
            {
                builder.Append(base.GetData());
            }
            return builder.ToString();
        }
    }
}