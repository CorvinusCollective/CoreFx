// <copyright file="ISerializeStream.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System.IO;

    /// <summary>
    /// Interface for Serialization to an Stream.
    /// </summary>
    public interface ISerializeStream
    {
        /// <summary>Serializes an object to a stream. Will not close the stream.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="outStream">Output stream.</param>
        void SerializeStream(object input, Stream outStream);
    }
}
