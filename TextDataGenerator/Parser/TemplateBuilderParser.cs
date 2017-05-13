using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private readonly BrowseText text;
        private readonly Stack<IBuilder> builderStack;

        public TemplateBuilderParser(string fileText)
        {
            text = new BrowseText(fileText);
            builderStack = new Stack<IBuilder>();
            builderStack.Push(new TemplateBuilder());
        }

        public IBuilder Parse()
        {
            try
            {
                return ParseBody();
            }
            catch (Exception ex)
            {
                throw new BuilderParserException(text.CurrentLine(), "", ex);
            }
        }
        
        private IBuilder ParseBody()
        {
            while (text.Cursor<text.Length)
            {
                if (text.StartWith("@{"))
                {
                    ParseText();
                    ParseTag();
                    if (text.StartWith("@{"))
                        ParseTag();
                }
                text.Move();
            }
            ParseText();
            return builderStack.Pop();
        }

        private void ParseText()
        {
            var subText = text.Read();
            var builder = builderStack.Peek();
            if (subText != string.Empty)
                builder.Add(new Data.TextData(subText));
        }

        private void ParseTag()
        {
            var tag = new TagParser(text).ParseTag();
            if (IsEndBuilderTag(tag.Type))
            {
                EndBuilder();
                return;
            }
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

        private bool IsEndBuilderTag(string tag)
        {
            return tag == builderStack.Peek().EndTag;
        }

        private void StartBuilder(IBuilder builder)
        {
            builderStack.Push(builder);
            text.SkeepNewLine();
            text.JumpReaderCursorToCursor();
        }

        private void EndBuilder()
        {
            var builderPop = builderStack.Pop();
            builderStack.Peek().Add(builderPop.CreateDataGenerator());
            text.SkeepNewLine();
            text.JumpReaderCursorToCursor();
        }
    }
}
