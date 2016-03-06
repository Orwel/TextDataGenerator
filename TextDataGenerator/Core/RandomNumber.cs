// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;

namespace TextDataGenerator.Core
{
    public static class RandomNumber
    {
        public static Random Random { get; } = new Random();

        public static double NextDouble(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }

        public static DateTime NextDateTime(DateTime min, DateTime max)
        {
            TimeSpan timeSpan = max - min;
            TimeSpan newSpan = new TimeSpan(NextInt64(0, timeSpan.Ticks));
            return min + newSpan;
        }

        public static long NextInt64()
        {
            var buffer = new byte[sizeof(long)];
            Random.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        public static long NextInt64(long min, long max)
        {
            return (NextInt64() % (max - min)) + min;
        }
    }
}