using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccessoriesPage : ContentPage
	{
        private Boolean updating = false;

		public AccessoriesPage ()
		{
			InitializeComponent ();

            // setting the items source for the listview
            CarConfig cc = CarConfig.GetInstance();
            List<Accessory> accessories = cc.GetAccessories()[0].GetAccessoryList();
            accessoriesList.ItemsSource = accessories;

            // setting the correct title for this page
            this.Title = Language.GetString("tabs.accessories.label");

            ToolbarManager.Manage(ToolbarItems);

            CarConfigContext.accessoriesPage = this;
            
        }

        private void listSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (!updating)
            {
                Switch s = (Switch)sender;
                Grid parent = (Grid)s.Parent;
                Label id = (Label)parent.Children[2];
                int index = CarConfig.GetInstance().GetAccessories()[0].GetIndexOfAccessory(id.Text);
                Accessories a = CarConfig.GetInstance().GetAccessories()[0];
                if (e.Value)
                {
                    a.AddAccessorySelected(index);
                }
                else
                {
                    a.RemoveAccessorySelected(index);
                }

                CarConfigContext.vehiclesPage.UpdateCalcPane();
            }
        }

        public void UpdateAccessoriesListItemsSource()
        {
            updating = true;

            accessoriesList.ItemsSource = null;

            CarConfig cc = CarConfig.GetInstance();
            List<Accessory> accessories = cc.GetAccessories()[0].GetAccessoryList();
            accessoriesList.ItemsSource = accessories;

            updating = false;
        }
    }
}