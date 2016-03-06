// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using CommandLine;
using CommandLine.Text;

namespace TextDataGenerator
{
    internal class CommandLineOptions
    {
        [Option('e', "encoding", HelpText = "Encoding of file parsed and default encoding for sub-file.")]
        public string Encoding { get; set; }

        [ValueOption(0)]
        public string Path { get; set; }

        [HelpVerbOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this);
        }

        public static CommandLineOptions CreateAndParse(string[] args)
        {
            var options = new CommandLineOptions();
            Parser.Default.ParseArguments(args, options);
            return options;
        }
    }
}