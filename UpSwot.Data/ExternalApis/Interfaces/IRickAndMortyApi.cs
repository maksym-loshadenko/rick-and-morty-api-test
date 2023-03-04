using UpSwot.Data.Entities.RickAndMorty;

namespace UpSwot.Data.ExternalApis.Interfaces
{
    public interface IRickAndMortyApi
    {
        public Episode GetEpisodeByName(string episodeName);
        public Character GetCharacterByName(string characterName);
        public Location GetLocationByUrl(string url);
    }
}
