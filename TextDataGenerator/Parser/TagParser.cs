// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

namespace TextDataGenerator.Parser
{
    public static class TagParser
    {
        public static Tag Parse(string tagStr)
        {
            return ParseTag(ExtractInnerTag(tagStr));
        }

        private static string ExtractInnerTag(string tagStr)
        {
            return tagStr.Substring("@{".Length, tagStr.Length - "@{}".Length);
        }

        private static Tag ParseTag(string tag)
        {
            tag = tag.Trim();
            var indexOfTypeEnd = tag.IndexOf(' ');
            string type;
            string parameters;
            if (indexOfTypeEnd > 0)
            {
                type = tag.Substring(0, indexOfTypeEnd);
                parameters = tag.Substring(indexOfTypeEnd + 1);
            }
            else
            {
                type = tag;
                parameters = string.Empty;
            }
            return new Tag
            {
                Type = type,
                Parameters = TagParameterParser.GetInfos(parameters)
            };
        }
    }
}
