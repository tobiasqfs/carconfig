using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.options
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsSpecialsPage : ContentPage
	{
		public OptionsSpecialsPage ()
		{
			InitializeComponent ();

            // setting the items source for the list view
            CarConfig cc = CarConfig.GetInstance();
            List<Special> specials = cc.GetSpecials()[0].GetSpecialList();
            specialsList.ItemsSource = specials;

            // setting the correct text for the menu items
            this.Resources.Add("DetailsButtonText", Language.GetString("menu.edit.contextActions.details"));
            this.Resources.Add("ChangeButtonText", Language.GetString("menu.edit.contextActions.change"));
            this.Resources.Add("DeleteButtonText", Language.GetString("menu.edit.contextActions.delete"));

            // setting the correct text for the toolbar item
            ToolbarItems[0].Text = Language.GetString("menu.edit.newButton");

            // setting the correct title for this page
            this.Title = Language.GetString("menu.edit.specials.title");

            CarConfigContext.optionsSpecialsPage = this;
		}

        private async void NewButton_Clicked(object sender, System.EventArgs e)
        {
            if (CarConfigContext.buggy)
            {
                System.Threading.Thread.Sleep(122000);
            }
            CarConfig.GetInstance().SleepForLoadtesting();
            await App.Current.MainPage.Navigation.PushModalAsync(new OptionsSpecialModal(false));
        }

        private async void MenuItem_Details(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            if(mi is Special)
            {
                var item = (Special)mi;
                Specials specials = CarConfig.GetInstance().GetSpecials()[0];

                var index = specials.GetIndexOfSpecial(item);
                specials.SelectSpecialEditMode(index);
                await App.Current.MainPage.Navigation.PushModalAsync(new OptionsSpecialDetail());
            }
        }

        private async void MenuItem_Change(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            if(mi is Special)
            {
                var item = (Special)mi;
                Specials specials = CarConfig.GetInstance().GetSpecials()[0];

                var index = specials.GetIndexOfSpecial(item);
                specials.SelectSpecialEditMode(index);
                await App.Current.MainPage.Navigation.PushModalAsync(new OptionsSpecialModal(true));
            }
        }

        private void MenuItem_Delete(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            specialsList.ItemsSource = null;

            if(mi is Special)
            {
                var item = (Special)mi;
                Specials specials = CarConfig.GetInstance().GetSpecials()[0];

                var index = specials.GetIndexOfSpecial(item);
                specials.SelectSpecialEditMode(index);
                specials.DeleteSelectedSpecial();

                UpdateSpecialsListItemsSource();
            }
        }

        private void specialsList_ItemSelected(object sender, System.EventArgs e)
        {

        }

        public void UpdateSpecialsListItemsSource()
        {
            CarConfig cc = CarConfig.GetInstance();
            List<Special> specials = cc.GetSpecials()[0].GetSpecialList();
            specialsList.ItemsSource = null;
            specialsList.ItemsSource = specials;

            CarConfigContext.specialsPage.UpdateSpecialsListItemsSource();
        }

        private void ContentPage_Disappearing(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
        }
    }
}