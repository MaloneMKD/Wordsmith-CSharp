
namespace Wordsmith.Views
{
	public partial class EditPoemPage : ContentPage
	{
		public EditPoemPage()
		{
			InitializeComponent();
			BindingContext = App.EPPVM;
		}
    }
}