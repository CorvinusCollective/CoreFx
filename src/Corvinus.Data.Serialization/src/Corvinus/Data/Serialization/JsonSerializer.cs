// <copyright file="JsonSerializer.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Data.Serialization
{
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// Provides Methods for easily deserializing objects to json.
    /// </summary>
    public class JsonSerializer : IDeserializeFile, IDeserializeStream, IDeserializeString, ISerializeFile, ISerializeStream, ISerializeString
    {
        /// <summary>Deserializes an object from a JSON file.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="path">Source file path.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeFile<T>(string path)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            using (JsonReader jsonReader = new JsonTextReader(new StreamReader(path)))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }

        /// <summary>Deserializes an object from a JSON stream. Will not close the stream.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input stream.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeStream<T>(Stream input)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            var streamReader = new StreamReader(
                input,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: true,
                bufferSize: 4096,
                leaveOpen: true);

            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                return serializer.Deserialize<T>(jsonReader);
            }
        }

        /// <summary>Deserializes an object from a JSON string.</summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="input">Input string.</param>
        /// <returns>Deserialized object.</returns>
        public T DeserializeString<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }

        /// <summary>Serializes an object as JSON to a file.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="path">Destination file path.</param>
        /// <param name="append">If true and the file exists it will be appended to,
        /// otherwise it will be overwritten.</param>
        public void SerializeFile(object input, string path, bool append = false)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer { Formatting = Formatting.Indented };
            using (JsonWriter jsonWriter = new JsonTextWriter(new StreamWriter(path, append)))
            {
                serializer.Serialize(jsonWriter, input);
            }
        }

        /// <summary>Serializes an object as JSON to a stream. Will not close the stream.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <param name="outStream">Output stream.</param>
        public void SerializeStream(object input, Stream outStream)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();
            var streamWriter = new StreamWriter(
                outStream,
                Encoding.UTF8,
                bufferSize: 4096,
                leaveOpen: true);

            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(jsonWriter, input);
            }
        }

        /// <summary>Serializes an object to a JSON string.</summary>
        /// <param name="input">Object to serialize.</param>
        /// <returns>String the object was serialized to.</returns>
        public string SerializeString(object input)
        {
            return JsonConvert.SerializeObject(input, Formatting.Indented);
        }
    }
}
