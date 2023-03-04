using Newtonsoft.Json;

namespace UpSwot.Business.Models.Responses.Subtypes
{
    public class CharacterOrigin
    {
        [JsonConstructor]
        public CharacterOrigin
        (
            [JsonProperty("name")] string name,
            [JsonProperty("type")] string type,
            [JsonProperty("dimension")] string dimension
        )
        {
            Name = name;
            Type = type;
            Dimension = dimension;
        }

        /// <summary>
        /// The name of the origin location.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The type of the origin location.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The dimensionin which the origin location is located.
        /// </summary>
        [JsonProperty("dimension")]
        public string Dimension { get; }
    }
}
