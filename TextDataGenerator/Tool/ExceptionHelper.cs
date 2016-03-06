// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Text;

namespace TextDataGenerator.Tool
{
    internal static class ExceptionHelper
    {
        public static string ToStringFull(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.ToString();
            var builder = new StringBuilder();
            builder.AppendLine(ex.ToString());
            builder.AppendLine("-----------------------");
            builder.AppendLine(ToStringFull(ex.InnerException));
            return builder.ToString();
        }
    }
}