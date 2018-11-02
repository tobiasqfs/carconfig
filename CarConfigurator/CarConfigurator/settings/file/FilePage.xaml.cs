using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilePage : ContentPage
	{
        private int itemsCount = 0;

		public FilePage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.file");

            List<ListItem> items = new List<ListItem>();

            int pos = 0;

            items.Add(new ListItem(Language.GetString("menu.file.reset"), pos++));
            if (CarConfigContext.needLogin)
            {
                items.Add(new ListItem(Language.GetString("menu.file.logout"), pos++));
            }
            items.Add(new ListItem(Language.GetString("menu.file.exit"), pos++));

            fileList.ItemsSource = items;

            itemsCount = pos;
		}

        private void fileList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // disable selection
            ((ListView)sender).SelectedItem = null;

            if(e.SelectedItem is ListItem)
            {
                ListItem li = (ListItem)e.SelectedItem;
                switch (li.position)
                {
                    // Handle a tap on menu.file.reset
                    case 0:
                        CarConfig.GetInstance().ActionFileReset();
                        App.Current.MainPage = new NavigationPage(new ConfiguratorPage());
                        break;
                    // Handle a tap on menu.file.logout
                    case 1:
                        if(itemsCount == 3)
                        {
                            App.Current.MainPage = new LoginPage();
                        }
                        else
                        {
                            System.Environment.Exit(0);
                        }
                        break;
                    // Handle a tap on menu.file.exit
                    case 2:
                        // TODO maybe replace Exit(0) because currently app closes with a black screen,
                        // would be nice to fix
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
    }
}