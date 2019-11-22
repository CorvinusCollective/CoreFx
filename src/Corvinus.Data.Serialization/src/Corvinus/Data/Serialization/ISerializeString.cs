// <copyright file="ISerializeString.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    /// <summary>
    /// Interface for Serialization to a string.
    /// </summary>
    public interface ISerializeString
    {
        /// <summary>Serializes an object to a string.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <returns>String the object was serialized to.</returns>
        string SerializeString(object input);
    }
}
