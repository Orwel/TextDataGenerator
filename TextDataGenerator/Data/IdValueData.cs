using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class IdValueData : IFactory, IData
    {
        private readonly string id;

        public IdValueData(string id)
        {
            this.id = id;
        }

        public IData CreateDataGenerator()
        {
            return this;
        }

        public string GetData()
        {
            return TagValueContainer.GetValue(id);
        }
    }
}
