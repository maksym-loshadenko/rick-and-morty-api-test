using UpSwot.Business.Models.Responses;

namespace UpSwot.Business.Models
{
    public class CharacterInfoCache : BaseCache
    {
        public string CharacterName { get; set; }

        public CharacterInfo? CharacterInfo { get; set; }
    }
}
