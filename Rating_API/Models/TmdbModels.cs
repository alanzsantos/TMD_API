using Newtonsoft.Json;

namespace Rating_API.Models
{
    public class TmdbSearchResult
    {
        public int Page { get; set; }

        public List<TmdbMovie> Results { get; set; }

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }
    }

    public class TmdbMovie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("vote_average")]

        public float VoteAverage { get; set; }
    }
}
