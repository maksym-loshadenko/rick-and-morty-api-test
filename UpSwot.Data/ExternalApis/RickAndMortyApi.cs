using Newtonsoft.Json;
using UpSwot.Data.Entities.RickAndMorty;
using UpSwot.Data.Exceptions;
using UpSwot.Data.ExternalApis.Interfaces;

namespace UpSwot.Data.ExternalApis
{
    public class RickAndMortyApi : IRickAndMortyApi
    {
        private const string ApiUrl = "https://rickandmortyapi.com/api";

        public Episode GetEpisodeByName(string episodeName)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "name", episodeName }
            };

            var httpResponse = HttpGet($"{ApiUrl}/episode", parameters).Result;

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ParseResponse<Episode>(httpResponse);
            }
            else
            {
                throw new EpisodeNotFoundException();
            }
        }

        public Character GetCharacterByName(string characterName)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "name", characterName }
            };

            var httpResponse = HttpGet($"{ApiUrl}/character", parameters).Result;

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return ParseResponse<Character>(httpResponse);
            }
            else
            {
                throw new CharacterNotFoundException();
            }
        }

        public Location GetLocationByUrl(string url)
        {
            var httpResponse = HttpGet(url, null).Result;

            if (httpResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = httpResponse.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<Location>(responseBody);
            }
            else
            {
                throw new LocationNotFoundException();
            }
        }

        private static T ParseResponse<T>(HttpResponseMessage httpResponse)
        {
            var responseBody = httpResponse.Content.ReadAsStringAsync().Result;

            var baseResponse = JsonConvert.DeserializeObject<BaseResponse>(responseBody);
            var resultJson = JsonConvert.SerializeObject(baseResponse.Results.FirstOrDefault());

            return JsonConvert.DeserializeObject<T>(resultJson);
        }

        private static async Task<HttpResponseMessage> HttpGet(string url, Dictionary<string, string>? parameters = null)
        {
            string query = "";

            if (parameters != null)
            {
                using var content = new FormUrlEncodedContent(parameters);
                query = content.ReadAsStringAsync().Result;
            }

            using var client = new HttpClient();
            var response = await client.GetAsync(parameters == null ? url : url + $"?{query}");

            return response;
        }
    }
}