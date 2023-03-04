using Newtonsoft.Json;

namespace UpSwot.ServiceModels.Types.RickAndMorty.Subtypes
{
    public class CharacterLocation
    {
        [JsonConstructor]
        public CharacterLocation(
            [JsonProperty("name")] string name,
            [JsonProperty("url")] string url
        )
        {
            Name = name;
            Url = url;
        }

        /// <summary>
        /// Name of the character's last known location endpoint.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Link to the character's last known location endpoint.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }
    }


}
