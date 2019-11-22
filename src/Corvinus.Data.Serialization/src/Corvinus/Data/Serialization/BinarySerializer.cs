// <copyright file="BinarySerializer.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    /// <summary>
    /// Provides Methods for easily deserializing objects to binary.
    /// </summary>
    public class BinarySerializer : IDeserializeFile, IDeserializeStream, ISerializeFile, ISerializeStream
    {
        /// <summary>Deserializes an object from a binary file.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="path">Source file path.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeFile<T>(string path)
        {
            Stream stream = File.OpenRead(path);
            BinaryFormatter bf = new BinaryFormatter();
            var result = (T)bf.Deserialize(stream);
            stream.Close();

            return result;
        }

        /// <summary>Deserializes an object from a binary stream. Will not close the stream.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input stream.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeStream<T>(Stream input)
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (T)bf.Deserialize(input);
        }

        /// <summary>Serializes an object as binary to a file.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="path">Destination file path.</param>
        /// <param name="append">If true and the file exists it will be appended to,
        /// otherwise it will be overwritten.</param>
        public void SerializeFile(object input, string path, bool append = false)
        {
            Stream stream = File.Open(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, input);
            stream.Close();
        }

        /// <summary>Serializes an object as binary to a stream. Will not close the stream.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="stream">Output stream.</param>
        public void SerializeStream(object input, Stream stream)
        {
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, input);
        }
    }
}
