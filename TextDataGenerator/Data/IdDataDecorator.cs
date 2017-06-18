using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class IdDataDecorator : IFactory, IData
    {
        private readonly string id;
        private readonly IData data;

        public IdDataDecorator(string id, IData data)
        {
            this.id = id;
            this.data = data;
        }

        public string GetData()
        {
            var value = data.GetData();
            TagValueContainer.SetValue(id, value);
            return value;
        }

        public IData CreateDataGenerator()
        {
            return this;
        }
    }
}
