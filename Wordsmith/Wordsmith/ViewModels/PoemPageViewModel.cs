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
    public class PoemPageViewModel : ObservableObject
    {
        private PoemModel _displayPoem = new PoemModel();
        public PoemModel DisplayPoem
        {
            get => _displayPoem;
            set
            {
                SetProperty(ref _displayPoem, value);
                OnPropertyChanged();
            }
        }

        public bool _editing = false;
        public bool Editing
        {
            get => _editing;
            set
            {
                SetProperty(ref _editing, value);
                OnPropertyChanged();
            }
        }

        public Command EditCommand  { get; set; }
        public Command SaveCommand { get; set; }   

        public PoemPageViewModel()
        {
            EditCommand = new Command(EditCommandExecute, EditCommandCanExecute);
            SaveCommand = new Command(SaveCommandExecute, SaveCommandCanExecute);
        }

        public void EditCommandExecute()
        {
            Editing = true;
        }

        public bool EditCommandCanExecute()
        {
            return true;
        }

        public void SaveCommandExecute()
        {
            Editing = false;
        }

        public bool SaveCommandCanExecute()
        {
            return true;
        }
    }
}
