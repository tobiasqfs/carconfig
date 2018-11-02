using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using CarConfigurator.settings.options;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsPage : ContentPage
	{
		public OptionsPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.edit");

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem(Language.GetString("menu.edit.vehicles"), 0));
            items.Add(new ListItem(Language.GetString("menu.edit.specials"), 1));
            items.Add(new ListItem(Language.GetString("menu.edit.accessories"), 2));

            optionsList.ItemsSource = items;
		}

        private async void optionsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // disable selection
            ((ListView)sender).SelectedItem = null;

            if(e.SelectedItem != null && e.SelectedItem is ListItem)
            {
                ListItem li = (ListItem)e.SelectedItem;
                switch (li.position)
                {
                    // Handle a tap on menu.edit.vehicles
                    case 0:
                        await App.Current.MainPage.Navigation.PushAsync(new OptionsVehiclesPage(), true);
                        break;
                    // Handle a tap on menu.edit.specials
                    case 1:
                        await App.Current.MainPage.Navigation.PushAsync(new OptionsSpecialsPage(), true);
                        break;
                    // Handle a tap on menu.edit.accessories
                    case 2:
                        await App.Current.MainPage.Navigation.PushAsync(new OptionsAccessoriesPage(), true);
                        break;
                }
            }
        }
    }
}