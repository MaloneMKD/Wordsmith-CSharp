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
	}
}