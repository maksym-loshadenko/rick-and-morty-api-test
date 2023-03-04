namespace UpSwot.Business.Models
{
    public class CharacterEpisodeCache : BaseCache
    {
        public string CharacterName { get; set; }
        public string EpisodeName { get; set; }

        public bool IsCharacterPresentedInTheEpisode { get; set; }
    }
}
