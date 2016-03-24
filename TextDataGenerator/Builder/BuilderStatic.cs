// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Collections.Generic;
using TextDataGenerator.Core;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Builder
{
    public static class BuilderStatic
    {
        public static IBuilder CreateBuilderText(string fileText)
        {
            var parser = new TextExtractor(fileText);
            var builderStack = new Stack<IBuilder>();
            builderStack.Push(new TemplateBuilder());

            try
            {
                for (var subText = parser.Next("@{", true); subText != null; subText = parser.Next("@{", true))
                {
                    AddSubPartTextInBuilder(builderStack.Peek(), subText);
                    var tagText = parser.Next("}", false);
                    if (tagText == null)
                        throw new InvalidOperationException("'}' missing.");
                    var parseStr = tagText.Substring("@{".Length, tagText.Length - "@{}".Length);
                    if (parseStr == builderStack.Peek().EndTag)
                    {
                        var builderPop = builderStack.Pop();
                        builderStack.Peek().Add(builderPop.CreateDataGenerator());
                        parser.SkeepNewLine();
                        continue;
                    }

                    var indexOfTypeEnd = parseStr.IndexOf(' ');
                    string type;
                    string parameters;
                    if (indexOfTypeEnd > 0)
                    {
                        type = parseStr.Substring(0, indexOfTypeEnd);
                        parameters = parseStr.Substring(indexOfTypeEnd + 1);
                    }
                    else
                    {
                        type = parseStr;
                        parameters = string.Empty;
                    }

                    var factory = FactoryStatic.CreateFactory(type, Parsing.GetInfos(parameters));
                    if (factory is IBuilder)
                    {
                        builderStack.Push((IBuilder)factory);
                        parser.SkeepNewLine();
                    }
                    else
                        builderStack.Peek().Add(factory.CreateDataGenerator());
                }
                AddSubPartTextInBuilder(builderStack.Peek(), parser.NextToEnd());
                return builderStack.Pop();
            }
            catch (Exception ex)
            {
                throw new BuilderException(parser.Line, "Error line " + parser.Line, ex);
            }
        }

        private static void AddSubPartTextInBuilder(IBuilder builder, string subText)
        {
            if (subText != string.Empty)
                builder.Add(new Data.TextData(subText));
        }

        private static bool OccurrenceAtIndexOf(string str, string occurrence, int position) => str.IndexOf(occurrence, position) == position;

        private static int CountOccurrence(string str, string occurrence)
        {
            int count = 0;
            int position = 0;
            while ((position = str.IndexOf(occurrence, position)) != -1)
            {
                count++;
                position += occurrence.Length;
            }
            return count;
        }
    }
}