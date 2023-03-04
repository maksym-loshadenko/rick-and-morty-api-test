using UpSwot.Business.Models.Responses;
using UpSwot.Business.Services.Interfaces;
using UpSwot.Data.ExternalApis.Interfaces;

namespace UpSwot.Business.Services
{
    public class RickAndMortyService : IRickAndMortyService
    {
        private readonly IRickAndMortyApi _rickAndMortyApi;

        public RickAndMortyService
        (
            IRickAndMortyApi rickAndMortyApi
        )
        {
            _rickAndMortyApi = rickAndMortyApi;
        }

        /// <summary>
        /// Method checks if a character with the given name was in the
        /// episode with the given name and return true if the character
        /// was in the episode or false if the character was not in the
        /// episode.
        /// </summary>
        public bool IsCharacterPresentedInEpisode(string episodeName, string characterName)
        {
            var episode = _rickAndMortyApi.GetEpisodeByName(episodeName);
            var character = _rickAndMortyApi.GetCharacterByName(characterName);

            return episode.Characters.Contains(character.Url);
        }

        /// <summary>
        /// Method searches and returns infoi about character with
        /// the given name.
        /// </summary>
        public CharacterInfo GetCharacterInfoByName(string characterName)
        {
            var character = _rickAndMortyApi.GetCharacterByName(characterName);
            var location = _rickAndMortyApi.GetLocationByUrl(character.Location.Url);

            return new CharacterInfo(character, location);
        }
    }
}
