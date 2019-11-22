// <copyright file="IDeserializeStream.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System.IO;

    /// <summary>
    /// Interface for Deserialization from a stream.
    /// </summary>
    public interface IDeserializeStream
    {
        /// <summary>Deserializes an object from a stream. Will not close the stream.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input stream.</param>
        /// <returns>Deserialized object.</returns>
        T DeserializeStream<T>(Stream input);
    }
}
