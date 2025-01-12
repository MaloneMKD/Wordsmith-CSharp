using Microsoft.VisualBasic.FileIO;
using Wordsmith.Models;
using Wordsmith.ViewModels;
using Wordsmith.CustomControls;

namespace Wordsmith.Views
{
    public partial class MainPage : ContentPage
    {
        // Poem page object. Only one instance will be used in the whole app
        public PoemPage poemPage { get; set; }

        // Holds the poem currently being created
        PoemModel? TempPoem { get; set; } 

        public MainPage()
        {
            InitializeComponent();
            poemPage = new PoemPage();
            App.MPVM = new MainPageViewModel();
            BindingContext = App.MPVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PoemListView.SelectedItem = null;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var temp = (PoemModel)e.SelectedItem;
                if (temp.Title != null)
                {
                    Navigation.PushAsync(poemPage);
                }
            }
        }

        private void NewPoemButton_Clicked(object sender, EventArgs e)
        {
            if (App.EPPVM.CurrentPoem != null)
            {
                App.EPPVM.CurrentPoem.ID = null;
                App.EPPVM.CurrentPoem.Alignment = "left";
                App.EPPVM.CurrentPoem.Title = "Title"; ;
                App.EPPVM.CurrentPoem.Date = DateTime.Now.ToString("dddd dd MMM yyyy - hh:mm");
                App.EPPVM.CurrentPoem.Author = "Author";
                App.EPPVM.CurrentPoem.Poem = "Enter Poem Here";
                Navigation.PushAsync(App.EPP);
            }
        }

        private void InfoButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("About", "Author: Malone K Napier-Jameson.\nVersion: 1.0.0.0", "Close");
        }
    }
}
