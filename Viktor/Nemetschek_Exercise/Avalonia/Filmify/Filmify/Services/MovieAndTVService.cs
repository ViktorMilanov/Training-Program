using Filmify.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Filmify.ViewModels;
using Filmify.Errors;
using System.IO;
using Avalonia.Media.Imaging;

namespace Filmify.Services
{
    public class MovieAndTVService
    {
        private string bearerToken;
        private HttpClient client;

        public MovieAndTVService()
        {
            bearerToken = ConfigurationManager.AppSettings["BearerToken"] ?? "";
            client = new HttpClient();
        }
        public async Task<Dictionary<string, int>> GetGenresAsync(string genresQuery)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(genresQuery),
                    Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", bearerToken },
                },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    var genreResponse = JsonConvert.DeserializeObject<GenreResponse>(body);

                    return genreResponse.Genres.ToDictionary(genre => genre.Name, genre => genre.Id);
                }
            }
            catch (Exception)
            {
                return new Dictionary<string, int>();
            }
        }


        public async Task<ISuggest> GetSuggestionAsync(string genresQuery, TypeOfSearchedGenre typeOfGenre)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(genresQuery),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "Authorization", bearerToken },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    if (typeOfGenre == TypeOfSearchedGenre.movie)
                    {
                        var responseObject = JsonConvert.DeserializeObject<MovieQueryResponse>(body);
                        int numberOfTheSuggestion = responseObject.results.Count;
                        return responseObject.results[RandomResultNumber(numberOfTheSuggestion)];
                    }
                    else
                    {
                        var responseObject = JsonConvert.DeserializeObject<SeriesQueryResponse>(body);
                        int numberOfTheSuggestion = responseObject.results.Count;
                        return responseObject.results[RandomResultNumber(numberOfTheSuggestion)];
                    }
                }
            }
            catch (Exception)
            {
                throw new FailedToGetSuggestionException("There was a problem while trying to get a suggestion to watch");
            }
        }

        public async Task<int> GetPagesAsync(string numberOfPagesQuery)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(numberOfPagesQuery),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "Authorization", bearerToken },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var responseObject = JsonConvert.DeserializeObject<WantedGenrePages>(body);

                    return responseObject.total_pages;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private int RandomResultNumber(int maxResultNumber)
        {
            Random randomPageNumber = new Random();
            return randomPageNumber.Next(1, maxResultNumber);
        }
    }
}
