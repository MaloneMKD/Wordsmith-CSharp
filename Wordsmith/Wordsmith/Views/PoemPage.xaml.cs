using Wordsmith.Models;
using Wordsmith.ViewModels;

namespace Wordsmith.Views
{
	public partial class PoemPage : ContentPage
	{
        public PoemPage()
		{
			InitializeComponent();
			BindingContext = App.PPVM;
		}

        private void EditButton_Clicked(object sender, EventArgs e)
        {
			App.EPPVM.CurrentPoem = App.PPVM!.DisplayPoem;
            Navigation.PushAsync(App.EPP);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (App.PPVM != null && App.Current != null)
            {
                App.Current.Dispatcher.Dispatch(async() =>
                {
                    bool res = await DisplayAlert("Delete Poem", $"Are you sure you want to delete this poem? {App.PPVM.DisplayPoem.Title}", "Yes", "Cancel");
                    if (res && App.Current.Windows[0] != null && App.Current.Windows[0].Page != null && App.MPVM != null)
                    {
                        await Task.Run(async () => await App.Database.DeletePoem(App.PPVM.DisplayPoem));
                        await App.Current.Windows[0].Page.Navigation.PopToRootAsync();
                        App.MPVM.PopulatePoemList();
                    }
                });
            }
        }
    }
}