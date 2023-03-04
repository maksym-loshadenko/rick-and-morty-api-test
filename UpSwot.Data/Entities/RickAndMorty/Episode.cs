using Newtonsoft.Json;

namespace UpSwot.Data.Entities.RickAndMorty
{
    public class Episode
    {
        [JsonConstructor]
        public Episode(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("air_date")] string airDate,
            [JsonProperty("episode")] string episode,
            [JsonProperty("characters")] List<string> characters,
            [JsonProperty("url")] string url,
            [JsonProperty("created")] DateTime created
        )
        {
            Id = id;
            Name = name;
            AirDate = airDate;
            EpisodeCode = episode;
            Characters = characters;
            Url = url;
            Created = created;
        }

        /// <summary>
        /// The id of the episode.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the episode.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The air date of the episode.
        /// </summary>
        [JsonProperty("air_date")]
        public string AirDate { get; set; }

        /// <summary>
        /// The code of the episode.
        /// </summary>
        [JsonProperty("episode")]
        public string EpisodeCode { get; set; }

        /// <summary>
        /// List of characters who have been seen in the episode.
        /// </summary>
        [JsonProperty("characters")]
        public List<string> Characters { get; set; }

        /// <summary>
        /// Link to the episode's own endpoint.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Time at which the episode was created in the database.
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }
}