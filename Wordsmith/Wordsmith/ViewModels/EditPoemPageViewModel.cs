using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wordsmith.Models;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Wordsmith.ViewModels
{
    public class EditPoemPageViewModel : ObservableObject
    {
        private PoemModel? _currentPoem = new PoemModel();
        public PoemModel? CurrentPoem
        {
            get => _currentPoem;
            set
            {
                SetProperty(ref _currentPoem, value);
                OnPropertyChanged(nameof(CurrentPoem));
            }
        }

        public bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetProperty(ref _isBusy, value);
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public Command SaveCommand { get; }
        public Command<string> AlignCommand { get; }
        public Command<string> SearchCommand { get; }

        public EditPoemPageViewModel()
        {
            SaveCommand = new Command(SaveCommandExecute);
            AlignCommand = new Command<string>(AlignCommandExecute);
            SearchCommand = new Command<string>(SearchCommandExecute);
        }

        public void SaveCommandExecute()
        {
            Task.Run(async () =>
            {
                string message = "";
                if (CurrentPoem != null)
                {
                    if (await App.Database.Exists(CurrentPoem.ID))
                    {
                        // Update poem in database
                        await App.Database.UpdatePoem(CurrentPoem);
                        message = "Poem updated...";
                    }
                    else
                    {
                        // Save poem to database
                        await App.Database.InsertNewPoem(CurrentPoem);
                        message = "New poem saved...";
                    }
                }
                // Add poem to poem list
                if (App.Current != null && App.MPVM != null)
                {
                    App.MPVM.PopulatePoemList();
                    App.Current.Dispatcher.Dispatch(async () =>
                    {
                        await Task.Delay(100);
                        IsBusy = true;
                        // Navigate back to the main page
                        await App.Current.Windows[0].Page!.Navigation.PopToRootAsync();
                        await App.Current.Windows[0].Page!.DisplayAlert("Saved", message, "Ok");
                        IsBusy = false;
                        await Task.Delay(100);
                    });
                }
            });
        }

        public void AlignCommandExecute(string direction)
        {
            if (CurrentPoem != null)
            {
                switch (direction)
                {
                    case "left":
                        if (CurrentPoem.Alignment != "left")
                            CurrentPoem.Alignment = "left";
                        break;
                    case "center":
                        if (CurrentPoem.Alignment != "center")
                            CurrentPoem.Alignment = "center";
                        break;
                    case "right":
                        if (CurrentPoem.Alignment != "right")
                            CurrentPoem.Alignment = "right";
                        break;
                }
            }
        }
        public void SearchCommandExecute(string arg)
        {
            // Use API to get rhyming words
            string rhymebrain_url = $"https://rhymebrain.com/talk?function=getRhymes&word={arg}";
            _ = GetRhymes(rhymebrain_url, arg) ;
        }

        private async Task GetRhymes(string url, string arg)
        {
            Application.Current!.Dispatcher.Dispatch(async () =>
            {
                try
                {
                    await Task.Delay(100);
                    IsBusy = true;
                    HttpClient _client = new HttpClient();
                    HttpResponseMessage response = await _client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string words = "";
                        string content = await response.Content.ReadAsStringAsync();

                        List<RhymeInfo>? rhymes = JsonSerializer.Deserialize<List<RhymeInfo>>(content);

                        if (rhymes != null)
                        {
                            foreach (RhymeInfo info in rhymes)
                            {
                                if (info.score == 300)
                                {
                                    words += info.word += '\n';
                                }
                            }

                            if (Application.Current!.Windows[0].Page != null)
                            {
                                await Application.Current!.Windows[0].Page!.DisplayAlert($"Words that rhyme with {arg.ToUpper()}", words, "Ok");
                            }
                        }
                    }
                    IsBusy = false;
                    await Task.Delay(100);
                }
                catch (Exception ex)
                {
                    IsBusy = false;
                    await Task.Delay(100);
                    await Application.Current!.Windows[0].Page!.DisplayAlert("Error", ex.Message, "Ok");
                }
            });
        }
    }
}
