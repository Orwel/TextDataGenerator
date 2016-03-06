// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;

namespace TextDataGenerator.Factory
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterFactoryAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
    }
}