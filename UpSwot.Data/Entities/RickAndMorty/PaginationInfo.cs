using Newtonsoft.Json;

namespace UpSwot.Data.Entities.RickAndMorty
{
    public class PaginationInfo
    {
        [JsonConstructor]
        public PaginationInfo
        (
            [JsonProperty("count")] int count,
            [JsonProperty("pages")] int pages,
            [JsonProperty("next")] string? next,
            [JsonProperty("prev")] string? prev
        )
        {
            Count = count;
            Pages = pages;
            Next = next;
            Prev = prev;
        }

        [JsonProperty("count")]
        public int Count { get; }

        [JsonProperty("pages")]
        public int Pages { get; }

        [JsonProperty("next")]
        public string? Next { get; }

        [JsonProperty("prev")]
        public string? Prev { get; }
    }
}
