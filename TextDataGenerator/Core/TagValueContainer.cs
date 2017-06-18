using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataGenerator.Core
{
    public static class TagValueContainer
    {
        private static readonly Dictionary<string, string> values = new Dictionary<string, string>();

        public static void SetValue(string id, string value)
        {
            if (values.ContainsKey(id))
                values[id] = value;
            else
                values.Add(id, value);
        }

        public static string GetValue(string id)
        {
            return values.ContainsKey(id) ? values[id] : null;
        }
    }
}
