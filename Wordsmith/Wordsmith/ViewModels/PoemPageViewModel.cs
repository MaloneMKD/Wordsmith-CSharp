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
                OnPropertyChanged(nameof(DisplayPoem));
            }
        }

        private int _fontSize = 14;
        public int FontSize
        {
            get => _fontSize;
            set
            {
                SetProperty(ref _fontSize, value);
                OnPropertyChanged(nameof(FontSize));
            }
        }
    }
}
