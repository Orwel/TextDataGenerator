// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TextDataGenerator.Core;

namespace TextDataGenerator.Data
{
    public class FileLineSelector : IData
    {
        public int NbLines { get; }
        public string Path { get; }
        public Encoding Encoding { get; }

        public FileLineSelector(string path, Encoding encoding)
        {
            Path = path;
            Encoding = encoding;
            NbLines = ReadLines().Count();
        }

        public string GetData()
        {
            var selectLine = RandomNumberProvider.Current.NextInt32(0, NbLines - 1);
            return ReadLines().Skip(selectLine).First();
        }

        private IEnumerable<string> ReadLines()
        {
            return (Encoding == null) ? File.ReadLines(Path) : File.ReadLines(Path, Encoding);
        }
    }
}