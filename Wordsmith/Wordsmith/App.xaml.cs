using Wordsmith.Models;
using Wordsmith.ViewModels;

namespace Wordsmith
{
    public partial class App : Application
    {
        // Global Varialbe for the currently selected Item
        public static PoemPageViewModel? PPVM {  get; set; }

        public App()
        {
            InitializeComponent();
            PPVM = new PoemPageViewModel();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}