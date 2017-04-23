// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Linq;
using System.Text;

namespace TextDataGenerator.Tool
{
    internal static class EncodingHelper
    {
        public static Encoding GetEncodingFromCodePageOrName(string encodingStr)
        {
            int codePage;
            return int.TryParse(encodingStr, out codePage) ? GetEncodingFromCodePage(codePage) : GetEncodingFromName(encodingStr);
        }

        private static Encoding GetEncodingFromCodePage(int codePage)
        {
            if (Encoding.GetEncodings().Any(e => e.CodePage == codePage))
                return Encoding.GetEncoding(codePage);
            throw new InvalidOperationException("Bad encoding code page : " + codePage);
        }

        private static Encoding GetEncodingFromName(string name)
        {
            if (Encoding.GetEncodings().Any(e => e.Name == name))
                return Encoding.GetEncoding(name);
            throw new InvalidOperationException("Bad encoding name : " + name);
        }
    }
}