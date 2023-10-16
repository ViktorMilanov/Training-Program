using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Filmify.Errors;
using Filmify.ExtentionMethods;
using Filmify.Models;
using Filmify.Services;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Filmify.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        string getGenresQuery = "https://api.themoviedb.org/3/genre/[TypeOfGenre]/list?language=en";
        string getMovieQuery = "https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=[numberOfThePage]&sort_by=popularity.desc&with_genres=[WantedGenre]&with_original_language=en";
        string getSeriesQuery = "https://api.themoviedb.org/3/discover/tv?include_adult=false&include_null_first_air_dates=false&language=en-US&page=[numberOfThePage]&sort_by=popularity.desc&with_genres=[WantedGenre]&with_original_language=en";
        string getPosterQuery = "https://image.tmdb.org/t/p/original[PosterPath]";
        string defaultImage = "https://static.displate.com/857x1200/displate/2022-04-15/7422bfe15b3ea7b5933dffd896e9c7f9_46003a1b7353dc7b5a02949bd074432a.jpg";
        private MovieAndTVService movieAndTVService;
        public Dictionary<string, int> seriesGenres { get; private set; }
        Dictionary<string, int> movieGenres;

        public MainWindowViewModel()
        {
            movieAndTVService = new MovieAndTVService();
            movieGenres = new Dictionary<string, int>();
            seriesGenres = new Dictionary<string, int>();
        }
        public void RunTheThing(string parameter)
        {
            Console.WriteLine(parameter);
        }
        public async Task<IEnumerable<string>> GetGenresAsync(TypeOfSearchedGenre typeOfGenre)
        {
            string genresQuery = getGenresQuery.Replace("[TypeOfGenre]", typeOfGenre.ToString());
            if (typeOfGenre == TypeOfSearchedGenre.movie)
            {
                movieGenres = await movieAndTVService.GetGenresAsync(genresQuery);
                return movieGenres.Keys.ToList();
            }
            else
            {
                seriesGenres = await movieAndTVService.GetGenresAsync(genresQuery);
                return seriesGenres.Keys.ToList();
            }

        }

        public async Task<ISuggest> GetSuggestionAsync(List<string> wantedGenres, TypeOfSearchedGenre typeOfGenre)
        {
            List<string> wantedGenreIds = GetGenresIds(wantedGenres, typeOfGenre); ;
            string numberOfPagesQuery;
            string genresQuery;
            if (typeOfGenre == TypeOfSearchedGenre.movie)
            {
                numberOfPagesQuery = getMovieQuery.ReplaceInTemplate(wantedGenreIds, 1);
                var maxPages = await movieAndTVService.GetPagesAsync(numberOfPagesQuery);
                if (maxPages == 0)
                {
                    throw new FailedToGetSuggestionException("There is not a movie with that genres together");
                }
                genresQuery = getMovieQuery.ReplaceInTemplate(wantedGenreIds, RandomPageNumber(maxPages));
            }
            else
            {
                numberOfPagesQuery = getSeriesQuery.ReplaceInTemplate(wantedGenreIds, 1);
                var maxPages = await movieAndTVService.GetPagesAsync(numberOfPagesQuery);
                if (maxPages == 0)
                {
                    throw new FailedToGetSuggestionException("There is not a series with that genres together");
                }
                genresQuery = getSeriesQuery.ReplaceInTemplate(wantedGenreIds, RandomPageNumber(maxPages));
            }
            ISuggest suggest = await movieAndTVService.GetSuggestionAsync(genresQuery, typeOfGenre);
            FillTheGenres(suggest, typeOfGenre);
            return suggest;
        }

        private void FillTheGenres(ISuggest suggest, TypeOfSearchedGenre typeOfGenre)
        {
            suggest.genre_names = new List<string>();

            if (typeOfGenre == TypeOfSearchedGenre.movie)
            {
                foreach (var genreId in suggest.genre_ids)
                {
                    suggest.genre_names.Add(movieGenres.FirstOrDefault(x => x.Value == genreId).Key);
                }
            }
            else
            {
                foreach (var genreId in suggest.genre_ids)
                {
                    suggest.genre_names.Add(seriesGenres.FirstOrDefault(x => x.Value == genreId).Key);
                }
            }
        }

        private List<string> GetGenresIds(List<string> wantedGenres, TypeOfSearchedGenre typeOfGenre)
        {
            List<string> wantedGenreIds = new();
            foreach (var genreName in wantedGenres)
            {
                if (typeOfGenre == TypeOfSearchedGenre.movie)
                {
                    wantedGenreIds.Add(movieGenres.GetValueOrDefault(genreName).ToString());
                }
                else
                {
                    wantedGenreIds.Add(seriesGenres.GetValueOrDefault(genreName).ToString());
                }
            }
            return wantedGenreIds;
        }

        public static int RandomPageNumber(int maxPages)
        {
            Random randomPageNumber = new Random();
            return randomPageNumber.Next(1, maxPages > 500 ? 500 : maxPages);
        }

        public async Task<Bitmap?> GetPosterAsync(string poster_path)
        {
            return await PosterService.LoadFromWebAsync(new Uri(getPosterQuery.Replace("[PosterPath]", poster_path)));
        }

        public async Task<Bitmap?> LoadDefaultImg()
        {
            return await PosterService.LoadFromWebAsync(new Uri(defaultImage));
        }
    }
}