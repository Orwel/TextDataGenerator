// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;

namespace TextDataGenerator.Parser
{
    public class Tag
    {
        public string Type { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }
}
