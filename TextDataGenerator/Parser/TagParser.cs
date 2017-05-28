using System.Collections.Generic;

namespace TextDataGenerator.Parser
{
    public class TagParser
    {
        private readonly BrowseText text;

        public TagParser(BrowseText text)
        {
            this.text = text;
        }

        public Tag ParseTag()
        {
            MoveToStartOfType();
            var type = ParseType();
            var parameters = ParseParameters();
            text.Move(); //Jump '}' tag end
            text.JumpReaderCursorToCursor();
            return new Tag {Type = type, Parameters = parameters};
        }

        private void MoveToStartOfType()
        {
            text.Move("@{".Length);
            text.SkipWhiteChar();
            text.JumpReaderCursorToCursor();
        }

        private string ParseType()
        {
            var type = string.Empty;
            while (text.Cursor < text.Length)
            {
                if (text.CurrentIsWhite || text.Current == '}')
                {
                    type = text.Read();
                    text.SkipWhiteChar();
                    text.JumpReaderCursorToCursor();
                    break;
                }
                text.Move();
            }
            return type;
        }

        private Dictionary<string, string> ParseParameters()
        {
            var parameters = new Dictionary<string, string>();
            if (text.Current == '}')
                return parameters;

            while (text.Current != '}' || text.Cursor < text.Length)
            {
                var parameterName = ParseParameterName();
                var parameterValue = string.Empty;
                if (text.Current == '=')
                {
                    text.Move();
                    text.SkipWhiteChar();
                    text.JumpReaderCursorToCursor();
                    parameterValue = ParseParameterValue();
                }
                parameters.Add(parameterName, parameterValue);
                if (text.Current == '}')
                    break;
                text.Move();
            }
            return parameters;
        }

        private string ParseParameterName()
        {
            while (text.Current != '}' || text.Cursor < text.Length)
            {
                if (text.CurrentIsWhite || text.Current == '}' || text.Current == '=')
                {
                    var parameterName = text.Read();
                    text.SkipWhiteChar();
                    text.JumpReaderCursorToCursor();
                    return parameterName;
                }
                text.Move();
            }
            return string.Empty;
        }

        private string ParseParameterValue()
        {
            var value = text.Current == '"' ? ParseParameterValueBetweenDoubleQuote() : ParseParameterValueWithoutDoubleQuote();
            text.SkipWhiteChar();
            text.JumpReaderCursorToCursor();
            return value;
        }

        private string ParseParameterValueWithoutDoubleQuote()
        {
            while (text.Current != '}' || text.Cursor < text.Length)
            {
                if (text.CurrentIsWhite || text.Current == '}')
                    return text.Read();
                text.Move();
            }
            return string.Empty;
        }

        private string ParseParameterValueBetweenDoubleQuote()
        {
            text.Move();
            text.JumpReaderCursorToCursor();
            while (text.Cursor < text.Length)
            {
                if (text.Current == '"')
                {
                    var parameterValue = text.Read();
                    text.Move();
                    return parameterValue;
                }
                text.Move();
            }
            return string.Empty;
        }
    }
}
