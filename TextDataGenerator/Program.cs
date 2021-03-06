﻿// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Globalization;
using TextDataGenerator.Core;
using TextDataGenerator.Parser;
using TextDataGenerator.Tool;

namespace TextDataGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                InitializeInvariantCuluture();
                var options = CommandLineOptions.CreateAndParse(args);
                if (LoadSettingFromArguments(options))
                {
                    var textFile = TextFileHelper.ReadAllTextFileWithDefaultEncoding(options.Path);
                    var builder = TemplateBuilderParser.CreateBuilderText(textFile);
                    Console.WriteLine(builder.CreateDataGenerator().GetData());
                }
                else
                {
                    // Display the default usage information
                    Console.WriteLine(options.GetUsage());
                }
            }
            catch (BuilderParserException bex)
            {
                Console.Error.WriteLine(ExceptionHelper.ToStringFull(bex));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error has occurred!");
                Console.Error.WriteLine(ExceptionHelper.ToStringFull(ex));
            }
        }

        private static bool LoadSettingFromArguments(CommandLineOptions options)
        {
            if (options.Path == null)
                return false;
            if (options.Encoding != null)
                Setting.Encoding = EncodingHelper.GetEncodingFromCodePageOrName(options.Encoding);
            return true;
        }

        public static void InitializeInvariantCuluture() =>
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
    }
}