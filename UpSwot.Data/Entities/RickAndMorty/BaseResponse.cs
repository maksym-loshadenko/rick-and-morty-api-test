using Newtonsoft.Json;

namespace UpSwot.Data.Entities.RickAndMorty
{
    public class BaseResponse
    {
        [JsonConstructor]
        public BaseResponse
        (
            [JsonProperty("info")] PaginationInfo info,
            [JsonProperty("results")] List<object> results
        )
        {
            Info = info;
            Results = results;
        }

        [JsonProperty("info")]
        public PaginationInfo Info { get; }

        [JsonProperty("results")]
        public List<object> Results { get; }
    }
}
