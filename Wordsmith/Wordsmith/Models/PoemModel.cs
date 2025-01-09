using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Wordsmith.Models
{
    public class PoemModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int? ID {  get; set; }

        private string? _author;
        public string? Author 
        { 
            get => _author;
            set
            {
                if (_author != value)
                {
                    SetProperty(ref _author, value);
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    SetProperty(ref _title, value);
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string? Date { get; set; }

        private string? _poem;
        public string? Poem
        {
            get => _poem;
            set
            {
                if (_poem != value)
                {
                    SetProperty(ref _poem, value);
                    OnPropertyChanged(nameof(Poem));
                }
            }
        }

        private string? _alignment;
        public string? Alignment
        {
            get => _alignment;
            set
            {
                if (_alignment != value)
                {
                    SetProperty(ref _alignment, value);
                    OnPropertyChanged(nameof(Alignment));
                }
            }
        }
    }
}
