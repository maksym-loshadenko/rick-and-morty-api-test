using UpSwot.Business.Models.Responses;

namespace UpSwot.Business.Services.Interfaces
{
    public interface IRickAndMortyService
    {
        public bool IsCharacterPresentedInEpisode(string episodeName, string characterName);
        public CharacterInfo GetCharacterInfoByName(string characterName);
    }
}
