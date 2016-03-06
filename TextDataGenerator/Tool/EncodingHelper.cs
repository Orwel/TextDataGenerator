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
            if (int.TryParse(encodingStr, out codePage))
                return GetEncodingFromCodePage(codePage);
            else
                return GetEncodingFromName(encodingStr);
        }

        private static Encoding GetEncodingFromCodePage(int codePage)
        {
            if (Encoding.GetEncodings().Where(e => e.CodePage == codePage).Count() > 0)
                return Encoding.GetEncoding(codePage);
            else
                throw new InvalidOperationException("Bad encoding code page : " + codePage);
        }

        private static Encoding GetEncodingFromName(string name)
        {
            if (Encoding.GetEncodings().Where(e => e.Name == name).Count() > 0)
                return Encoding.GetEncoding(name);
            else
                throw new InvalidOperationException("Bad encoding name : " + name);
        }
    }
}