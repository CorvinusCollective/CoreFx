// <copyright file="IDeserializeString.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    /// <summary>
    /// Interface for Deserialization from a string.
    /// </summary>
    public interface IDeserializeString
    {
        /// <summary>Deserializes an object from a string.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input string.</param>
        /// <returns>Deserialized object.</returns>
        T DeserializeString<T>(string input);
    }
}
