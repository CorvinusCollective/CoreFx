// <copyright file="IDeserializeFile.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    /// <summary>Interface for Deserialization from an object.</summary>
    public interface IDeserializeFile
    {
        /// <summary>Deserializes an object from a file.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="path">Source file path.</param>
        /// <returns>Deserialized object.</returns>
        T DeserializeFile<T>(string path);
    }
}
