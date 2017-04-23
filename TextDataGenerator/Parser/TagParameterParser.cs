// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;

namespace TextDataGenerator.Parser
{
    public class TagParameterParser
    {
        public const char SEPARATOR_INFO = ',';
        public const char SEPARATOR_KEY_VALUE = '=';

        public static IDictionary<string, string> GetInfos(string parse)
        {
            if (string.IsNullOrWhiteSpace(parse))
                return new Dictionary<string, string>();
            var dico = new Dictionary<string, string>();
            foreach (var info in parse.Split(SEPARATOR_INFO))
            {
                var keyValue = GetKeyValue(info);
                dico.Add(keyValue.Key, keyValue.Value);
            }
            return dico;
        }

        public static KeyValuePair<string, string> GetKeyValue(string keyValue)
        {
            var split = keyValue.Split(SEPARATOR_KEY_VALUE);
            return new KeyValuePair<string, string>(split[0].Trim(), split[1].Trim());
        }
    }
}