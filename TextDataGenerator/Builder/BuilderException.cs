// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TextDataGenerator.Builder
{
    [Serializable]
    public class BuilderException : Exception
    {
        public int Line { get; }

        public BuilderException(int line)
        : base()
        { Line = line; }

        public BuilderException(int line, string message)
        : base(message)
        { Line = line; }

        public BuilderException(int line, string message, Exception innerException)
        : base(message, innerException)
        { Line = line; }

        protected BuilderException(int line, SerializationInfo info, StreamingContext context)
        : base(info, context)
        { Line = line; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected BuilderException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        { }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue(nameof(Line), Line);
            base.GetObjectData(info, context);
        }
    }
}