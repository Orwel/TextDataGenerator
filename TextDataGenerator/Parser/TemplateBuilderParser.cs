// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Collections.Generic;
using TextDataGenerator.Builder;
using TextDataGenerator.Core;
using TextDataGenerator.Factory;

namespace TextDataGenerator.Parser
{
    public class TemplateBuilderParser
    {
        public static IBuilder CreateBuilderText(string fileText)
        {
            var parser = new TemplateBuilderParser(fileText);
            return parser.Parse();
        }

        private readonly TextExtractor parser;
        private readonly Stack<IBuilder> builderStack;

        public TemplateBuilderParser(string fileText)
        {
            parser = new TextExtractor(fileText);
            builderStack = new Stack<IBuilder>();
            builderStack.Push(new TemplateBuilder());
        }

        public IBuilder Parse()
        {
            try
            {
                for (var subText = parser.Next("@{", true); subText != null; subText = parser.Next("@{", true))
                {
                    AddSubPartTextInBuilder(subText);
                    var tag = ExtractTag();
                    if (IsEndBuilderTag(tag.Type))
                    {
                        EndBuilder();
                    }
                    else
                    {
                        var factory = FactoryStatic.CreateFactory(tag.Type, tag.Parameters);
                        var builder = factory as IBuilder;
                        if (builder != null)
                        {
                            StartBuilder(builder);
                        }
                        else
                        {
                            builderStack.Peek().Add(factory.CreateDataGenerator());
                        }
                    }
                }
                AddSubPartTextInBuilder(parser.NextToEnd());
                return builderStack.Pop();
            }
            catch (Exception ex)
            {
                throw new BuilderParserException(parser.Line, "Error line " + parser.Line, ex);
            }
        }

        private void AddSubPartTextInBuilder(string subText)
        {
            var builder = builderStack.Peek();
            if (subText != string.Empty)
                builder.Add(new Data.TextData(subText));
        }

        private Tag ExtractTag()
        {
            var tagText = parser.Next("}", false);
            if (tagText == null)
                throw new BuilderParserException(parser.Line, "'}' missing.");
            return TagParser.Parse(tagText);
        }

        private bool IsEndBuilderTag(string tag)
        {
            return tag == builderStack.Peek().EndTag;
        }

        private void StartBuilder(IBuilder builder)
        {
            builderStack.Push(builder);
            parser.SkeepNewLine();
        }

        private void EndBuilder()
        {
            var builderPop = builderStack.Pop();
            builderStack.Peek().Add(builderPop.CreateDataGenerator());
            parser.SkeepNewLine();
        }
    }
}