using Wordsmith.Models;
using Wordsmith.ViewModels;

namespace Wordsmith.Views
{
    public partial class MainPage : ContentPage
    {
        // Poem page object. Only one instance will be used in the whole app
        public PoemPage poemPage { get; set; }

        public MainPage()
        {
            InitializeComponent();
            poemPage = new PoemPage();
            BindingContext = new MainPageViewModel();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var temp = (PoemModel)e.SelectedItem;
            if (temp.Title != null)
            {
                Navigation.PushAsync(poemPage);
            }
        }
    }
}
