// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Collections.Generic;

namespace TextDataGenerator.Builder
{
    public class Parsing
    {
        public const char SeparatorInfo = ',';
        public const char SeparatorKeyValue = '=';

        public static IDictionary<string, string> GetInfos(string parse)
        {
            if (String.IsNullOrWhiteSpace(parse))
                return new Dictionary<string, string>();
            var dico = new Dictionary<string, string>();
            foreach (var info in parse.Split(SeparatorInfo))
            {
                var keyValue = GetKeyValue(info);
                dico.Add(keyValue.Key, keyValue.Value);
            }
            return dico;
        }

        public static KeyValuePair<string, string> GetKeyValue(string KeyValue)
        {
            var split = KeyValue.Split(SeparatorKeyValue);
            return new KeyValuePair<string, string>(split[0].Trim(), split[1].Trim());
        }
    }
}