using System;
using System.Text.Json;

namespace Polly.Caching.Serialization.System.Text.Json
{
    /// <summary>
    /// A serializer for serializing items of type <typeparamref name="TResult"/> to JSON, for the Polly <see cref="CachePolicy"/>
    /// </summary>
    /// <typeparam name="TResult"/>
    public class JsonSerializer<TResult> : ICacheItemSerializer<TResult, string>
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Constructs a new <see cref="JsonSerializer{TResult}"/> using the given <see cref="JsonSerializerOptions"/>.
        /// </summary>
        /// <param name="jsonSerializerOptions">The <see cref="JsonSerializerOptions"/> to use for serialization and deserialization.</param>
        public JsonSerializer(JsonSerializerOptions jsonSerializerOptions)
        {
            _jsonSerializerOptions = jsonSerializerOptions ?? throw new ArgumentNullException(nameof(jsonSerializerOptions));
        }

        /// <summary>
        /// Deserializes the passed json-serialization of an object, to type <typeparamref name="TResult"/>, using the <see cref="JsonSerializerOptions"/> passed when the <see cref="JsonSerializer{TResult}"/> was constructed.
        /// </summary>
        /// <param name="objectToDeserialize">The object to deserialize</param>
        /// <returns>The deserialized object</returns>
        public TResult Deserialize(string objectToDeserialize)
        {
            return JsonSerializer.Deserialize<TResult>(objectToDeserialize);
        }

        /// <summary>
        /// Serializes the specified object to JSON, using the <see cref="JsonSerializerOptions"/> passed when the <see cref="JsonSerializer{TResult}"/> was constructed.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize</param>
        /// <returns>The serialized object</returns>
        public string Serialize(TResult objectToSerialize)
        {
            return JsonSerializer.Serialize<TResult>(objectToSerialize, _jsonSerializerOptions);
        }
    }
}
