using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Wordsmith.Models;

namespace Wordsmith.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<PoemModel> Poems { get; set; } = [];

        private PoemModel _selectedPoem = new PoemModel();
        public PoemModel SelectedPoem
        { 
            get => _selectedPoem; 
            set
            {
                SetProperty(ref _selectedPoem, value);
                OnPropertyChanged(nameof(SelectedPoem));
                if (App.PPVM != null)
                {
                    App.PPVM.DisplayPoem = _selectedPoem;
                }
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

        public MainPageViewModel()
        {
            PopulatePoemList();
        }

        public void PopulatePoemList()
        {
            Poems.Clear();
            var res = App.Database.GetPoemsAsync();
            App.Current!.Dispatcher.Dispatch(async () =>
            {
                await Task.Delay(100);
                IsBusy = true;
                foreach (var poem in res.Result)
                {
                    Poems.Add(poem);
                }
                IsBusy = false;
                await Task.Delay(100);
            });
        }
    }
}
