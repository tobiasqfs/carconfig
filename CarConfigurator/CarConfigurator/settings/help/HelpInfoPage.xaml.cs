using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.help
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpInfoPage : ContentPage
	{
		public HelpInfoPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.help.info");

            if (CarConfigContext.newVersion)
            {
                labelCarConfigurator.Text = Language.GetString("menu.help.info.labelCarConfigurator.newVersion");
            }
            else
            {
                labelCarConfigurator.Text = Language.GetString("menu.help.info.labelCarConfigurator.oldVersion");
            }

            CultureInfo ci = new CultureInfo("de-DE");
            Calendar cal = ci.Calendar;

            int year = cal.GetYear(DateTime.Now);
            labelCopyright.Text = Language.GetString("menu.help.info.labelCopyright").Replace("%s", year.ToString());
		}

        private async void OkButton_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}