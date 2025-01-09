using Wordsmith.Models;
using Wordsmith.ViewModels;
using Wordsmith.Views;
using Wordsmith.Database;

namespace Wordsmith
{
    public partial class App : Application
    {
        // Database object
        public static PoemDatabase Database = new PoemDatabase();

        // Page to edit a poem
        public static EditPoemPageViewModel EPPVM = new EditPoemPageViewModel();
        public static EditPoemPage EPP  = new EditPoemPage();

        // Global Varialbe for the currently selected Item
        public static PoemPageViewModel PPVM = new PoemPageViewModel();

        // Main page view model
        public static MainPageViewModel? MPVM ;

        public App()
        {
            InitializeComponent();

            // Make sure the application always run in light theme
            Application.Current!.UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}