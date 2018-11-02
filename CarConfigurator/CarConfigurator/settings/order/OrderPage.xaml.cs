using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using CarConfigurator.settings.order;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{
		public OrderPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.order");

            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem(Language.GetString("menu.order.view"), 0));
            items.Add(new ListItem(Language.GetString("menu.order.order"), 1));
            items.Add(new ListItem(Language.GetString("menu.order.statistics"), 2));

            orderList.ItemsSource = items;
		}

        private async void orderList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // disable selection
            ((ListView)sender).SelectedItem = null;
            if(e.SelectedItem is ListItem)
            {
                ListItem li = (ListItem)e.SelectedItem;
                switch (li.position)
                {
                    // Handle a tap on menu.order.view
                    case 0:
                        await App.Current.MainPage.Navigation.PushAsync(new OrderViewPage(), true);
                        break;
                    // Handle a tap on menu.order.order
                    case 1:
                        await App.Current.MainPage.Navigation.PushAsync(new OrderDetailsPage(), true);
                        break;
                    // Handle a tap on menu.order.statistics
                    case 2:
                        await App.Current.MainPage.Navigation.PushAsync(new OrderStatisticsPage(), true);
                        break;
                }
            }
        }
    }
}