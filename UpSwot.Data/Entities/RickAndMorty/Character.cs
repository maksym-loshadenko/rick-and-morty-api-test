using Newtonsoft.Json;
using UpSwot.ServiceModels.Types.RickAndMorty.Subtypes;

namespace UpSwot.Data.Entities.RickAndMorty
{
    public class Character
    {
        [JsonConstructor]
        public Character(
            [JsonProperty("id")] int id,
            [JsonProperty("name")] string name,
            [JsonProperty("status")] string status,
            [JsonProperty("species")] string species,
            [JsonProperty("type")] string type,
            [JsonProperty("gender")] string gender,
            [JsonProperty("origin")] Origin origin,
            [JsonProperty("location")] CharacterLocation location,
            [JsonProperty("image")] string image,
            [JsonProperty("episode")] List<string> episode,
            [JsonProperty("url")] string url,
            [JsonProperty("created")] DateTime created
        )
        {
            Id = id;
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            Origin = origin;
            Location = location;
            Image = image;
            Episode = episode;
            Url = url;
            Created = created;
        }

        /// <summary>
        /// The id of the character.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; }

        /// <summary>
        /// The name of the character.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The status of the character ('Alive', 'Dead' or 'unknown').
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The species of the character.
        /// </summary>
        [JsonProperty("species")]
        public string Species { get; }

        /// <summary>
        /// The type or subspecies of the character.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The gender of the character ('Female', 'Male', 'Genderless' or 'unknown').
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; }

        /// <summary>
        /// Name and link to the character's origin location.
        /// </summary>
        [JsonProperty("origin")]
        public Origin Origin { get; }

        /// <summary>
        /// Name and link to the character's last known location endpoint.
        /// </summary>
        [JsonProperty("location")]
        public CharacterLocation Location { get; }

        /// <summary>
        /// Link to the character's image. All images are 300x300px and most are medium shots or portraits since they are intended to be used as avatars.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; }

        /// <summary>
        /// List of episodes in which this character appeared.
        /// </summary>
        [JsonProperty("episode")]
        public IReadOnlyList<string> Episode { get; }

        /// <summary>
        /// Link to the character's own URL endpoint.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; }

        /// <summary>
        /// Time at which the character was created in the database.
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; }
    }
}