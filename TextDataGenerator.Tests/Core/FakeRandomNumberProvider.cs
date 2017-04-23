// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;
using TextDataGenerator.Core;

namespace TextDataGenerator.Tests.Core
{
    internal class FakeRandomNumberProvider : RandomNumberProvider
    {
        public override DateTime NextDateTime(DateTime min, DateTime max)
        {
            return min;
        }

        public override double NextDouble(double min, double max)
        {
            return min;
        }

        public override int NextInt32(int min, int max)
        {
            return min;
        }

        public override long NextInt64()
        {
            return 42;
        }

        public override long NextInt64(long min, long max)
        {
            return min;
        }

        public static void Initialize()
        {
            Current = new FakeRandomNumberProvider();
        }
    }
}
