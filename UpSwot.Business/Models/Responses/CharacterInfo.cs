using Newtonsoft.Json;
using UpSwot.Business.Models.Responses.Subtypes;
using UpSwot.Data.Entities.RickAndMorty;

namespace UpSwot.Business.Models.Responses
{
    public class CharacterInfo
    {
        [JsonConstructor]
        public CharacterInfo
        (
            [JsonProperty("name")] string name,
            [JsonProperty("status")] string status,
            [JsonProperty("species")] string species,
            [JsonProperty("type")] string type,
            [JsonProperty("gender")] string gender,
            [JsonProperty("origin")] CharacterOrigin origin
        )
        {
            Name = name;
            Status = status;
            Species = species;
            Type = type;
            Gender = gender;
            Origin = origin;
        }

        public CharacterInfo(Character data, Location location)
        {
            Name = data.Name;
            Status = data.Status;
            Species = data.Species;
            Type = data.Type;
            Gender = data.Gender;
            Origin = new CharacterOrigin(location.Name, location.Type, location.Dimension);
        }

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
        /// Name, type and dimension of the character's origin location.
        /// </summary>
        [JsonProperty("origine")]
        public CharacterOrigin Origin { get; }
    }
}
