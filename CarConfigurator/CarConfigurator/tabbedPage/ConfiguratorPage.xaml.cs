using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfiguratorPage : TabbedPage
	{
		public ConfiguratorPage ()
		{
			InitializeComponent ();

            // setting the correct titles for the tabs
            vehiclesTab.Title = Language.GetString("tabs.vehicles.label");
            specialsTab.Title = Language.GetString("tabs.specials.label");
            accessoriesTab.Title = Language.GetString("tabs.accessories.label");

            if (CarConfigContext.newVersion)
            {
                this.Title = Language.GetString("application.newVersion.title");
            }
            else
            {
                this.Title = Language.GetString("application.oldVersion.title");
            }
		}

        private void TabbedPage_Appearing(object sender, System.EventArgs e)
        {
            if (CarConfigContext.newVersion)
            {
                this.Title = Language.GetString("application.newVersion.title");
            }
            else
            {
                this.Title = Language.GetString("application.oldVersion.title");
            }
        }
    }
}