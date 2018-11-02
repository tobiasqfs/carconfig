using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using CarConfigurator.settings.help;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpPage : ContentPage
	{
		public HelpPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.help");

            miInfoLabel.Text = Language.GetString("menu.help.info");
            miBuggy.Text = Language.GetString("menu.help.buggy");
            miBuggy.On = CarConfigContext.buggy;
            miNewVersion.Text = Language.GetString("menu.help.newVersion");
            miNewVersion.On = CarConfigContext.newVersion;
            miLoadTest.Text = Language.GetString("menu.help.lasttest");
            miLoadTest.On = CarConfigContext.loadTest;
            
		}

        private async void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new HelpInfoPage(), true);
        }

        private void miBuggy_OnChanged(object sender, ToggledEventArgs e)
        {
            CarConfigContext.buggy = e.Value;
        }

        private void miNewVersion_OnChanged(object sender, ToggledEventArgs e)
        {
            CarConfigContext.newVersion = e.Value;
        }

        private void miLoadTest_OnChanged(object sender, ToggledEventArgs e)
        {
            CarConfigContext.loadTest = e.Value;
        }
    }
}