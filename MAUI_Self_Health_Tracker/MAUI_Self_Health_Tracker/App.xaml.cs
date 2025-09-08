namespace MAUI_Self_Health_Tracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "MAUI_Self_Health_Tracker" };
        }
    }
}
