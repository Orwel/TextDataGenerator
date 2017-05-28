// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.IO;
using System.Text;
using TextDataGenerator.Core;

namespace TextDataGenerator.Tool
{
    internal static class TextFileHelper
    {
        public static string ReadAllTextFileWithDefaultEncoding(string path)
        {
            return ReadAllTextFile(path, Setting.Encoding);
        }

        public static string ReadAllTextFile(string path, Encoding encoding)
        {
            return Setting.Encoding == null ? File.ReadAllText(path) : File.ReadAllText(path, Setting.Encoding);
        }
    }
}