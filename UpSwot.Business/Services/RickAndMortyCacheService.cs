using Microsoft.Extensions.Caching.Memory;
using UpSwot.Business.Models;
using UpSwot.Business.Models.Responses;
using UpSwot.Business.Services.Interfaces;

namespace UpSwot.Business.Services
{
    /// <summary>
    /// Cache service, that uses Decorator pattern to implement
    /// Rick and Morty service extension, that saves frequently asked
    /// to the In Memory Cache.
    /// </summary>
    public class RickAndMortyCacheService: IRickAndMortyCacheService
    {
        private readonly IRickAndMortyService _rickAndMortyService;
        private readonly IMemoryCache _cache;

        private const string CharacterEpisodeCachePrefix = "CharacterEpisodeCache";
        private const string CharacterInfoCachePrefix = "CharacterInfoCache";

        private MemoryCacheEntryOptions _cacheOptions
        {
            get
            {
                return new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);
            }
        }

        public RickAndMortyCacheService
        (
            IRickAndMortyService rickAndMortyService,
            IMemoryCache memoryCache
        )
        {
            _rickAndMortyService = rickAndMortyService;
            _cache = memoryCache;
        }

        public bool IsCharacterPresentedInEpisode(string episodeName, string characterName)
        {
            var cacheKey = $"{CharacterEpisodeCachePrefix}_{episodeName}_{characterName}";

            if (_cache.TryGetValue(cacheKey, out CharacterEpisodeCache? characterEpisode))
            {
                return characterEpisode!.IsCharacterPresentedInTheEpisode;
            }
            else
            {
                characterEpisode = new CharacterEpisodeCache()
                {
                    EpisodeName = episodeName,
                    CharacterName = characterName
                };

                try
                {
                    characterEpisode.IsCharacterPresentedInTheEpisode = _rickAndMortyService.IsCharacterPresentedInEpisode(episodeName, characterName);
                }
                catch (Exception ex)
                {
                    characterEpisode.ThrownException = ex;
                }

                _cache.Set(cacheKey, characterEpisode, _cacheOptions);
            }

            return characterEpisode.ThrownException == null ?
                    characterEpisode.IsCharacterPresentedInTheEpisode :
                    throw characterEpisode.ThrownException;
        }

        public CharacterInfo GetCharacterInfoByName(string characterName)
        {
            var cacheKey = $"{CharacterInfoCachePrefix}_{characterName}";

            if (_cache.TryGetValue(cacheKey, out CharacterInfoCache? characterInfo))
            {
                return characterInfo!.CharacterInfo!;
            }
            else
            {
                characterInfo = new CharacterInfoCache()
                {
                    CharacterName = characterName
                };

                try
                {
                    characterInfo.CharacterInfo = _rickAndMortyService.GetCharacterInfoByName(characterName);
                }
                catch (Exception ex)
                {
                    characterInfo.ThrownException = ex;
                }

                _cache.Set(cacheKey, characterInfo, _cacheOptions);
            }

            return characterInfo!.ThrownException == null ?
                    characterInfo.CharacterInfo! :
                    throw characterInfo.ThrownException;
        }
    }
}
