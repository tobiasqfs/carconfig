using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace CarConfigurator
{
	public partial class App : Application
	{
		public App ()
		{
            // Set the language for the app
            // TODO: detect system language and set it automatically on startup or via parameters
            Language.SetLanguage(SupportedLanguage.GERMAN);

			InitializeComponent();

            // only for dev
            CarConfigContext.needLogin = false;

            // showing login page on startup when needed
            if (CarConfigContext.needLogin)
            {
                MainPage = new NavigationPage(new LoginPage());
                //MainPage = new NavigationPage(new MasterPage());
            }
            else
            {
                MainPage = new NavigationPage(new ConfiguratorPage());
            }
		}

		protected override void OnStart ()
		{
            // Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
