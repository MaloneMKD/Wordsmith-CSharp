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
            if (App.EPPVM.CurrentPoem != null && App.PPVM.DisplayPoem != null)
            {
                App.EPPVM.CurrentPoem.Alignment = App.PPVM.DisplayPoem.Alignment;
                App.EPPVM.CurrentPoem.Title = App.PPVM.DisplayPoem.Title;
                App.EPPVM.CurrentPoem.ID = App.PPVM.DisplayPoem.ID;
                App.EPPVM.CurrentPoem.Date = App.PPVM.DisplayPoem.Date;
                App.EPPVM.CurrentPoem.Author = App.PPVM.DisplayPoem.Author;
                App.EPPVM.CurrentPoem.Poem = App.PPVM.DisplayPoem.Poem;
                Navigation.PushAsync(App.EPP);
            }
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