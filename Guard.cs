using System;
using System.Collections.Generic;
using JG.Application.Exceptions;

namespace JG.Application
{
    public static class Guard<TE> where TE : InternalException , new()
    {
        public static void AgainstNull<T>(T value) where T : class
        {
            if (value == null)
                ThrowException();
        }

        public static void AgainstNotNull<T>(T value) where T : class
        {
            if (value != null)
                ThrowException();
        }

        public static void AgainstNull(string value)
        {
            if (string.IsNullOrEmpty(value))
                ThrowException();
        }
        
        public static void IsTrue<T>(Func<T, bool> condition, T target)
        {
            if (!condition(target))
                ThrowException();
        }

        public static void SmallerThan<T>(List<T> value, decimal target)
        {
            if (value?.Count < target)
                ThrowException();
        }

        public static void BiggerThan<T>(List<T> value,decimal target)
        {
            if (value?.Count > target)
                ThrowException();
        }

        public static void BiggerThan(decimal value, decimal target)
        {
            if (value > target)
                ThrowException();
        }
        public static void SmallerThan(decimal value, decimal target)
        {
            if (value < target)
                ThrowException();
        }

        private static void ThrowException()
        {
            throw new TE();
        }
    }
}
