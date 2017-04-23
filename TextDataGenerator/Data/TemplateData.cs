// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;
using System.Text;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class TemplateData : IData
    {
        private readonly List<IData> datas;

        public IReadOnlyList<IData> Datas => datas;

        public TemplateData(List<IData> datas)
        {
            this.datas = datas;
        }

        public string GetData()
        {
            var builder = new StringBuilder();
            foreach (var data in Datas)
            {
                builder.Append(data.GetData());
            }

            return builder.ToString();
        }
    }
}