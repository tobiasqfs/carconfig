using CarConfigurator.de.qfs.model.ui;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			InitializeComponent ();

            //masterPage.listView.ItemSelected += OnItemSelected;
        }

        
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                //masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}