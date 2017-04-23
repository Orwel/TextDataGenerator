// Copyright 2016-2016 Cédric VERNOU. All rights reserved. See LICENCE.md in the project root for license information.

using System;

namespace TextDataGenerator.Core
{
    public abstract class RandomNumberProvider
    {
        private static RandomNumberProvider current = DefaultRandomNumberProvider.Instance;

        public static RandomNumberProvider Current
        {
            get => current;
            set => current = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract int NextInt32(int min, int max);
        public abstract long NextInt64();
        public abstract long NextInt64(long min, long max);
        public abstract double NextDouble(double min, double max);
        public abstract DateTime NextDateTime(DateTime min, DateTime max);

        private class DefaultRandomNumberProvider : RandomNumberProvider
        {
            public static readonly DefaultRandomNumberProvider Instance = new DefaultRandomNumberProvider();

            private readonly Random random = new Random();

            public override long NextInt64()
            {
                var buffer = new byte[sizeof(long)];
                random.NextBytes(buffer);
                return BitConverter.ToInt64(buffer, 0);
            }

            public override int NextInt32(int min, int max)
            {
                return random.Next(min, max);
            }

            public override long NextInt64(long min, long max)
            {
                return (NextInt64() % (max - min)) + min;
            }

            public override double NextDouble(double min, double max)
            {
                return random.NextDouble() * (max - min) + min;
            }

            public override DateTime NextDateTime(DateTime min, DateTime max)
            {
                var timeSpan = max - min;
                var newSpan = new TimeSpan(NextInt64(0, timeSpan.Ticks));
                return min + newSpan;
            }
        }
    }
}
