using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.options
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsAccessoriesPage : ContentPage
	{
		public OptionsAccessoriesPage ()
		{
			InitializeComponent ();

            // setting the items source for the listview
            CarConfig cc = CarConfig.GetInstance();
            List<Accessory> accessories = cc.GetAccessories()[0].GetAccessoryList();
            accessoriesList.ItemsSource = accessories;

            // setting the correct text for the menu items
            this.Resources.Add("ChangeButtonText", Language.GetString("menu.edit.contextActions.change"));
            this.Resources.Add("DeleteButtonText", Language.GetString("menu.edit.contextActions.delete"));

            // setting the correct text for the toolbar item
            ToolbarItems[0].Text = Language.GetString("menu.edit.newButton");

            // setting the correct title for this page
            this.Title = Language.GetString("menu.edit.accessories.title");

            CarConfigContext.optionsAccessoriesPage = this;
		}

        private async void MenuItem_Change(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            if(mi is Accessory)
            {
                var item = (Accessory)mi;
                Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];

                var index = accessories.GetIndexOfAccessory(item);
                accessories.SelectAccessoryEditMode(index);
                await App.Current.MainPage.Navigation.PushModalAsync(new OptionsAccessoryModal(true));
            }
        }

        private void MenuItem_Delete(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            accessoriesList.ItemsSource = null;

            if(mi is Accessory)
            {
                var item = (Accessory)mi;
                Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];

                Specials sp = new Specials();

                foreach(Special s in CarConfig.GetInstance().GetSpecials()[0].GetSpecialList())
                {
                    if (s.GetAccessories().Contains(item))
                    {
                        sp.AddSpecial(s);
                    }
                }

                var index = accessories.GetIndexOfAccessory(item);
                accessories.SelectAccessoryEditMode(index);
                accessories.DeleteSelectedAccessory(sp);

                UpdateAccessoriesListItemsSource();
            }
        }

        private async void NewButton_Clicked(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            await App.Current.MainPage.Navigation.PushModalAsync(new OptionsAccessoryModal(false));
        }

        public void UpdateAccessoriesListItemsSource()
        {
            accessoriesList.ItemsSource = null;

            CarConfig cc = CarConfig.GetInstance();
            List<Accessory> accessories = cc.GetAccessories()[0].GetAccessoryList();
            accessoriesList.ItemsSource = accessories;

            CarConfigContext.accessoriesPage.UpdateAccessoriesListItemsSource();
        }
    }
}