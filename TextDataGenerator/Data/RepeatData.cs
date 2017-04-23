// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;
using System.Text;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class RepeatData : IData
    {
        private readonly List<IData> datas;

        public IReadOnlyList<IData> Datas => datas;

        public string EndTag => "EndRepeat";

        public int Max { get; }
        public int Min { get; }

        public RepeatData(int max, int min, List<IData> datas)
        {
            this.datas = datas;
            Max = max;
            Min = min;
        }

        public string GetData()
        {
            var builder = new StringBuilder();
            var nbRepeat = RandomNumberProvider.Current.NextInt32(Min, Max);
            for (int nRepeat = 0; nRepeat < nbRepeat; nRepeat++)
            {
                foreach (var data in Datas)
                {
                    builder.Append(data.GetData());
                }
            }
            return builder.ToString();
        }
    }
}