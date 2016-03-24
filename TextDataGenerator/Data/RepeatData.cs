// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;
using System.Text;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class RepeatData : IData
    {
        private List<IData> datas = new List<IData>();

        public IReadOnlyList<IData> Datas { get { return datas; } }

        public string EndTag { get { return "EndRepeat"; } }

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
            var nbRepeat = RandomNumber.Random.Next(Min, Max);
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