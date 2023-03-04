using Newtonsoft.Json;

namespace UpSwot.ServiceModels.Types.RickAndMorty.Subtypes
{
    public class Origin
    {
        [JsonConstructor]
        public Origin(
            [JsonProperty("name")] string name,
            [JsonProperty("url")] string url
        )
        {
            Name = name;
            Url = url;
        }

        /// <summary>
        /// Name of the character's origin location.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Link to the character's origin location.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }
    }


}
