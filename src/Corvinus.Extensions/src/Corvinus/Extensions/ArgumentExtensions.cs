// <copyright file="ArgumentExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods for asserting and validating arguments.
    /// </summary>
    public static class ArgumentExtensions
    {
        /// <summary>
        /// Ensures that the specified argument is equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test.</param>
        /// <param name="argumentName">The name of the argument.</param>
        /// <param name="value">The value to compare the argument against.</param>
        /// <exception caption="" cref="ArgumentException">The value of <paramref name="argument"/> is not equal to the value of <paramref name="value"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsEqual<T>(this T argument, string argumentName, T value)
            where T : IEquatable<T>
        {
            return argument.IsEqual(argumentName, value, $"The value of {argument} is not equal to the value of {value}.");
        }

        /// <summary>
        /// Ensures that the specified argument is equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="value">The value to compare the argument against.</param>
        /// <param name="details">Details passed into the thrown exception when the result is false.</param>
        /// <exception cref="ArgumentException"><paramref name="details"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsEqual<T>(this T argument, string argumentName, T value, string details)
            where T : IEquatable<T>
        {
            if (!argument.Equals(value))
            {
                throw new ArgumentException(argumentName, details);
            }

            return argument;
        }

        /// <summary>
        /// Ensures that the specified argument is equal to one of the specified values.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="values">The values to compare the argument against.</param>
        /// <exception cref="ArgumentException">The value of <paramref name="argument"/> is not equal to one of the expected values in <paramref name="values"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsEqual<T>(this T argument, string argumentName, IEnumerable<T> values)
            where T : IEquatable<T>
        {
            IEnumerable<string> valueList = values.Select((v) => v.ToString()).AsEnumerable();
            var details = $"The value of {argument} is not equal to one of the expected values in '{valueList.Aggregate((current, next) => current + ", " + next)}'";
            return argument.IsEqual(argumentName, values, details);
        }

        /// <summary>
        /// Ensures that the specified argument is equal to one of the specified values.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="values">The values to compare the argument against.</param>
        /// <param name="details">Details passed into the thrown exception when the result is false.</param>
        /// <exception cref="ArgumentException"><paramref name="details"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsEqual<T>(this T argument, string argumentName, IEnumerable<T> values, string details)
            where T : IEquatable<T>
        {
            foreach (T value in values)
            {
                if (argument.Equals(value))
                {
                    return argument;
                }
            }

            throw new ArgumentException(argumentName, details);
        }

        /// <summary>
        /// Ensures that the specified argument is not equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="value">The value to compare the argument against.</param>
        /// <exception cref="ArgumentException">The value of <paramref name="argument"/> is equal to the value of <paramref name="value"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsNotEqual<T>(this T argument, string argumentName, T value)
            where T : IEquatable<T>
        {
            return argument.IsNotEqual(argumentName, value, $"The value of {argument} is equal to the value of {value}");
        }

        /// <summary>
        /// Ensures that the specified argument is not equal to the specified value.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="value">The value to compare the argument against.</param>
        /// <param name="details">Details passed into the thrown exception when the result is false.</param>
        /// <exception cref="ArgumentException"><paramref name="details"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsNotEqual<T>(this T argument, string argumentName, T value, string details)
            where T : IEquatable<T>
        {
            if (argument.Equals(value))
            {
                throw new ArgumentException(argumentName, details);
            }

            return argument;
        }

        /// <summary>
        /// Ensures that the specified argument is not equal to one of the specified values.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="values">The values to compare the argument against.</param>
        /// <exception cref="ArgumentException">The value of <paramref name="argument"/> is equal to one of the values in <paramref name="values"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsNotEqual<T>(this T argument, string argumentName, IEnumerable<T> values)
            where T : IEquatable<T>
        {
            IEnumerable<string> valuesList = values.Select((v) => v.ToString()).AsEnumerable();
            string details = $"The value of {argument} is equal to one of the values in '{valuesList.Aggregate((current, next) => current + ", " + next)}'";
            return argument.IsNotEqual(argumentName, values, details);
        }

        /// <summary>
        /// Ensures that the specified argument is not equal to one of the specified values.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test. </param>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="values">The values to compare the argument against.</param>
        /// <param name="details">Details passed into the thrown exception when the result is false.</param>
        /// <exception cref="ArgumentException"><paramref name="details"/>.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsNotEqual<T>(this T argument, string argumentName, IEnumerable<T> values, string details)
            where T : IEquatable<T>
        {
            foreach (T value in values)
            {
                if (argument.Equals(value))
                {
                    throw new ArgumentException(argumentName, details);
                }
            }

            return argument;
        }

        /// <summary>
        /// Ensures that the specified argument is not null.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">The argument to test.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNullException">The argument cannot be null or default.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsNotNull<T>(this T argument, string argumentName)
            where T : class
        {
            return argument.IsNotNull(argumentName, "The argument cannot be null or default.");
        }

        /// <summary>
        /// Ensures that an argument is not null.
        /// </summary>
        /// <param name="argument">The argument to test.</param>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argumentName">The argument name.</param>
        /// <param name="details">Details passed into the thrown exception when the result is false.</param>
        /// <exception cref="ArgumentNullException">The argument cannot be null.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static T IsNotNull<T>(this T argument, string argumentName, string details)
            where T : class
        {
            if (argument == null || EqualityComparer<T>.Default.Equals(argument, default))
            {
                throw new ArgumentNullException(argumentName, details);
            }

            return argument;
        }

        /// <summary>
        /// Ensures that a string argument is not null or empty.
        /// </summary>
        /// <param name="argument">The argument to test.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNullException">The argument cannot be null or empty.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static string IsNotNullOrEmpty(this string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new ArgumentNullException(argumentName, "The string argument cannot be null or empty.");
            }

            return argument;
        }

        /// <summary>
        /// Ensures that a string argument is not null or empty or whitespace.
        /// </summary>
        /// <param name="argument">The argument to test.</param>
        /// <param name="argumentName">The argument name.</param>
        /// <exception cref="ArgumentNullException">The argument cannot be null, empty or consist only of white-space characters.</exception>
        /// <returns>The argument if the result is true.</returns>
        public static string IsNotNullOrWhitespace(this string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentNullException(argumentName, "The string argument cannot be null, empty or consist only of white-space characters.");
            }

            return argument;
        }

        /// <summary>
        /// Ensure the argument is greater than the compareToValue.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="compareToValue">Argument should be greater than this value.</param>
        /// <returns>The argument if the result is true.</returns>
        public static T IsGreaterThan<T>(this T argument, string argumentName, T compareToValue)
            where T : IComparable
        {
            if (argument.CompareTo(compareToValue) <= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, $"must be greater than {compareToValue}");
            }

            return argument;
        }

        /// <summary>
        /// Ensure the argument is less than the compareToValue.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="compareToValue">Argument should be less than this value.</param>
        /// <returns>The argument if the result is true.</returns>
        public static T IsLessThan<T>(this T argument, string argumentName, T compareToValue)
            where T : IComparable
        {
            if (argument.CompareTo(compareToValue) >= 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, $"must be less than {compareToValue}");
            }

            return argument;
        }

        /// <summary>
        /// Ensure the argument is greater than or equal to the compareToValue.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="compareToValue">Argument should be greater than or equal to this value.</param>
        /// <returns>The argument if the result is true.</returns>
        public static T IsGreaterThanOrEqualTo<T>(this T argument, string argumentName, T compareToValue)
            where T : IComparable
        {
            if (argument.CompareTo(compareToValue) < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, $"must be greater than or equal to {compareToValue}");
            }

            return argument;
        }

        /// <summary>
        /// Ensure the argument is less than or equal to the compareToValue.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="compareToValue">Argument should be less than or equal to this value.</param>
        /// <returns>The argument if the result is true.</returns>
        public static T IsLessThanOrEqualTo<T>(this T argument, string argumentName, T compareToValue)
            where T : IComparable
        {
            if (argument.CompareTo(compareToValue) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, $"must be less than or equal to {compareToValue}");
            }

            return argument;
        }

        /// <summary>
        /// Ensure the argument is in the range of lowerLimit to upperLimit.
        /// </summary>
        /// <typeparam name="T">The argument type.</typeparam>
        /// <param name="argument">Argument.</param>
        /// <param name="argumentName">Argument name.</param>
        /// <param name="lowerLimit">Argument should be greater than or equal to the lower limit.</param>
        /// <param name="upperLimit">Argument should be less than or equal to the upper value.</param>
        /// <returns>The argument if the result is true.</returns>
        public static T IsInRange<T>(this T argument, string argumentName, T lowerLimit, T upperLimit)
            where T : IComparable
        {
            if (argument.CompareTo(lowerLimit) < 0 || argument.CompareTo(upperLimit) > 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, argument, $"must be in range {lowerLimit} to {upperLimit}.");
            }

            return argument;
        }
    }
}
