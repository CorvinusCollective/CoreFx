// <copyright file="ISerializeFile.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    /// <summary>
    /// Interface for Serialization to an File.
    /// </summary>
    public interface ISerializeFile
    {
        /// <summary>Serializes an object to a file.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="path">Destination file path.</param>
        /// <param name="append">If true and the file exists it will be appended to,
        /// otherwise it will be overwritten.</param>
        void SerializeFile(object input, string path, bool append = false);
    }
}
