using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            InitializeComponent ();

            status.Text = Language.GetString("loginForm.status");
            userLabel.Text = Language.GetString("loginForm.user");
            pwdLabel.Text = Language.GetString("loginForm.pwd");
            loginBtn.Text = Language.GetString("loginForm.buttons.login");
            cancelBtn.Text = Language.GetString("loginForm.buttons.cancel");

            this.Title = Language.GetString("loginForm.title");
        }

        /// <summary>
        /// Handle login action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login(object sender, EventArgs e)
        {
            string currentUser = userField.Text;
            string pwd = pwdField.Text;

            if("tester".Equals(currentUser) && "tester".Equals(pwd))
            {
                System.Diagnostics.Debug.WriteLine("LOGIN_OK");
                CarConfigContext.user = "tester";
                App.Current.MainPage = new NavigationPage(new ConfiguratorPage());
            }else if("user".Equals(currentUser) && "user".Equals(pwd))
            {
                System.Diagnostics.Debug.WriteLine("LOGIN_OK");
                CarConfigContext.user = "user";
                App.Current.MainPage = new NavigationPage(new ConfiguratorPage());
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("LOGIN_KO");
                // TODO: fix: status text update causes new, slightly different allignment
                status.Text = Language.GetString("loginForm.status.failed");
                userField.Text = "";
                pwdField.Text = "";
            }
        }

        /// <summary>
        /// Handle cancel action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CANCEL");
            // TODO maybe replace Exit(0) because currently app closes with a black screen, would be nice to fix
            System.Environment.Exit(0);
            // Kill() has a short black screen too
            //System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}