using Microsoft.VisualBasic.FileIO;
using Wordsmith.Models;
using Wordsmith.ViewModels;

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

        // Function called when page is closing
        protected override bool OnBackButtonPressed()
        {
            // Dispose of the temp poem
            TempPoem = null;
            App.EPPVM.CurrentPoem = null;
            return base.OnBackButtonPressed();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var temp = (PoemModel)e.SelectedItem;
            if (temp.Title != null)
            {
                Navigation.PushAsync(poemPage);
            }
        }

        private void NewPoemButton_Clicked(object sender, EventArgs e)
        {
            PoemModel TempPoem = new PoemModel()
            {
                Title = "Title",
                Author = "Author",
                Date = DateTime.UtcNow.ToString("dddd dd MMM yyyy - hh:mm"),
                Poem = "Enter Poem Here",
                Alignment = "left"

            };
            App.EPPVM.CurrentPoem = TempPoem;
            Navigation.PushAsync(App.EPP);
        }
    }
}
