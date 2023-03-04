using Newtonsoft.Json;

namespace UpSwot.Data.Entities.RickAndMorty
{
    public class Location
    {
        [JsonConstructor]
        public Location(
            [JsonProperty("id")] int? id,
            [JsonProperty("name")] string name,
            [JsonProperty("type")] string type,
            [JsonProperty("dimension")] string dimension,
            [JsonProperty("residents")] List<string> residents,
            [JsonProperty("url")] string url,
            [JsonProperty("created")] DateTime? created
        )
        {
            Id = id;
            Name = name;
            Type = type;
            Dimension = dimension;
            Residents = residents;
            Url = url;
            Created = created;
        }

        /// <summary>
        /// The id of the location.
        /// </summary>
        [JsonProperty("id")]
        public int? Id { get; }

        /// <summary>
        /// The name of the location.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The type of the location.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The dimension in which the location is located.
        /// </summary>
        [JsonProperty("dimension")]
        public string Dimension { get; }

        /// <summary>
        /// List of character who have been last seen in the location.
        /// </summary>
        [JsonProperty("residents")]
        public IReadOnlyList<string> Residents { get; }

        /// <summary>
        /// Link to the location's own endpoint.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        /// <summary>
        /// Time at which the location was created in the database.
        /// </summary>
        [JsonProperty("created")]
        public DateTime? Created { get; }
    }
}
