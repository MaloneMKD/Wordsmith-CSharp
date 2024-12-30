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
        public ObservableCollection<PoemModel> Poems { get; set; }

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

        public MainPageViewModel()
        {
            Poems = [
                new PoemModel()
                {
                    Author = "W.H. Auden",
                    Title = "Funeral Blues",
                    Date = "2024-12-28",
                    Poem = 
@"Stop all the clocks, cut off the telephone
Prevent the dog from barking with a juicy bone,
Silence the pianos and with muffled drum
Bring out the coffin, let the mourners come.

Let aeroplanes circle moaning overhead
Scribbling on the sky the message 'He is Dead'.
Put crepe bows round the white necks of the public doves,
Let the traffic policemen wear black cotton gloves.

He was my North, my South, my East and West,
My working week and my Sunday rest,
My noon, my midnight, my talk, my song;
I thought that love would last forever: I was wrong.

The stars are not wanted now; put out every one,
Pack up the moon and dismantle the sun,
Pour away the ocean and sweep up the wood;
For nothing now can ever come to any good."
                },

                new PoemModel()
                {
                    Author = "William Shakespeare",
                    Title = "Sonnet 116",
                    Date = "2024-12-28",
                    Poem =
@"Let me not to the marriage of true minds
Admit impediments. Love is not love
Which alters when it alteration finds,
Or bends with the remover to remove:
O no! it is an ever-fixed mark
That looks on tempests and is never shaken;
It is the star to every wandering bark,
Whose worth's unknown, although his height be taken.
Love's not Time's fool, though rosy lips and cheeks
Within his bending sickle's compass come:
Love alters not with his brief hours and weeks,
But bears it out even to the edge of doom.
If this be error and upon me proved,
I never writ, nor no man ever loved."
                }
            ];
        }
    }
}
