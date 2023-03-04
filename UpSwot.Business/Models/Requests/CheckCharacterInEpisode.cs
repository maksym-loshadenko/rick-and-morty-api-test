using Newtonsoft.Json;

namespace UpSwot.Business.Models.Requests
{
    public class CheckCharacterInEpisode
    {
        [JsonConstructor]
        public CheckCharacterInEpisode
        (
            [JsonProperty("personName")] string personName,
            [JsonProperty("episodeName")] string episodeName
        )
        {
            PersonName = personName;
            EpisodeName = episodeName;
        }

        /// <summary>
        /// Name of the character to check if it was in the episode.
        /// </summary>
        [JsonProperty("personName")]
        public string PersonName { get; }

        /// <summary>
        /// Name of the episode to check if character was in it.
        /// </summary>
        [JsonProperty("episodeName")]
        public string EpisodeName { get; }
    }
}
