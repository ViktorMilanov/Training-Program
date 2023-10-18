using Avalonia.Controls;
using Avalonia.Interactivity;
using Filmify.Errors;
using Filmify.Models;
using Filmify.ViewModels;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Filmify.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel mainWindowViewModel;
        
        public MainWindow()
        {
            InitializeComponent();
            mainWindowViewModel = new();
            Loaded += MainWindow_Loaded;
        }
            private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            movieGenre.Items.Clear();
            seriesGenre.Items.Clear();
           
            //ideq
            //mainVM.Initialize()
            // -> get movies
            // -> series 
            // ...
            //movieGenre.Items.Add(mainVm.Movies)
            //
            var movieGenres = await mainWindowViewModel.GetGenresAsync(TypeOfSearchedGenre.movie);
            var seriesGenres = await mainWindowViewModel.GetGenresAsync(TypeOfSearchedGenre.tv);

            foreach (var genre in movieGenres)
            {
                movieGenre.Items.Add(genre);
            }
            foreach (var genre in seriesGenres)
            {
                seriesGenre.Items.Add(genre);
            }
        }

        public async void OnClickSearchMovieAsync(object sender, RoutedEventArgs args)
        {
            try
            {
                List<string> wantedGenres = movieGenreList.Items.Cast<string>().ToList();
                if (!wantedGenres.Any())
                {
                    throw new ArgumentException("Please enter a wanted genre!");
                }
                MovieInfo suggestedMovie = await mainWindowViewModel.GetSuggestionAsync(wantedGenres, TypeOfSearchedGenre.movie) as MovieInfo;
                suggestPoster.Source = await mainWindowViewModel.GetPosterAsync(suggestedMovie.poster_path) ?? await mainWindowViewModel.LoadDefaultImg();
                beforeSuggestText.IsVisible = false;
                title.Text = suggestedMovie.title;
                description.Text = suggestedMovie.overview;
                genres.Text = string.Join(", ", suggestedMovie.genre_names);
                releaseDate.Text = "Release Date: " + suggestedMovie.release_date;
                if (suggestedMovie.vote_average > 0)
                {
                    rating.Text = "Rating: " + suggestedMovie.vote_average.ToString();
                }
            }
            catch (FailedToGetSuggestionException ex)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error", ex.Message, ButtonEnum.Ok);
                var result = await box.ShowAsync();
            }
            catch (ArgumentException ex)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error", ex.Message, ButtonEnum.Ok);
                var result = await box.ShowAsync();
            }
            finally
            {
                movieGenreList.Items.Clear();
            }
        }
        public async void OnClickSearchSeriesAsync(object sender, RoutedEventArgs args)
        {
            try
            {
                List<string> wantedGenres = seriesGenreList.Items.Cast<string>().ToList();
                if (!wantedGenres.Any())
                {
                    throw new ArgumentException("Please enter a wanted genre!");
                }
                SeriesInfo suggestedSeries = await mainWindowViewModel.GetSuggestionAsync(wantedGenres, TypeOfSearchedGenre.tv) as SeriesInfo;
                suggestPoster.Source = await mainWindowViewModel.GetPosterAsync(suggestedSeries.poster_path) ?? await mainWindowViewModel.LoadDefaultImg();
                beforeSuggestText.IsVisible = false;
                title.Text = suggestedSeries.name;
                description.Text = suggestedSeries.overview;
                genres.Text = string.Join(", ", suggestedSeries.genre_names);
                releaseDate.Text = "Release Date: " + suggestedSeries.first_air_date;
                if (suggestedSeries.vote_average > 0)
                {
                    rating.Text = "Rating: " + suggestedSeries.vote_average.ToString();
                }
            }
            catch (FailedToGetSuggestionException ex)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error", ex.Message, ButtonEnum.Ok);
                var result = await box.ShowAsync();
            }
            catch (ArgumentException ex)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("Error", ex.Message, ButtonEnum.Ok);
                var result = await box.ShowAsync();
            }
            finally
            {
                seriesGenreList.Items.Clear();
            }
        }

        private void MovieGenreSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movieGenre.SelectedIndex = -1;

            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0] as string;

                if (selectedItem != null && !movieGenreList.Items.Contains(selectedItem))
                {
                    movieGenreList.Items.Add(selectedItem);
                }
            }
        }
        private void SeriesGenreSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            seriesGenre.SelectedIndex = -1;

            if (e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0] as string;

                if (selectedItem != null && !seriesGenreList.Items.Contains(selectedItem))
                {
                    seriesGenreList.Items.Add(selectedItem);
                }
            }
        }
    }

}