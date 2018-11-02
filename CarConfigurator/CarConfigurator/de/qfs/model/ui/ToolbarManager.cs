using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using System.Collections.Generic;
using System;
using Xamarin.Forms;

namespace CarConfigurator.de.qfs.model.ui
{
    class ToolbarManager
    {
        public static void Manage(IList<ToolbarItem> items)
        {
            // adding the needed toolbar items and setting the correct titles
            ToolbarItem fileToolbarItem = new ToolbarItem("toolbarItemFile", "", ToolbarItemFile_Tap, ToolbarItemOrder.Primary, 0);
            fileToolbarItem.Text = Language.GetString("menu.file");

            items.Add(fileToolbarItem);

            ToolbarItem editToolbarItem = new ToolbarItem("toolbarItemOptions", "", ToolbarItemOptions_Tap, ToolbarItemOrder.Secondary, 1);
            editToolbarItem.Text = Language.GetString("menu.edit");
            items.Add(editToolbarItem);

            if (CarConfigContext.user.Equals("tester"))
            {
                ToolbarItem orderToolbarItem = new ToolbarItem("toolbarItemOrder", "", ToolbarItemOrder_Tap, ToolbarItemOrder.Secondary, 1);
                orderToolbarItem.Text = Language.GetString("menu.order");
                items.Add(orderToolbarItem);
            }
            ToolbarItem helpToolbarItem = new ToolbarItem("toolbarItemHelp", "", ToolbarItemHelp_Tap, ToolbarItemOrder.Secondary, 1);
            helpToolbarItem.Text = Language.GetString("menu.help");
            items.Add(helpToolbarItem);
        }

        /// <summary>
        /// Handle a tap on the 'File' toolbar item
        /// </summary>
        public static async void ToolbarItemFile_Tap()
        {
            await App.Current.MainPage.Navigation.PushAsync(new FilePage(), true);
        }

        /// <summary>
        /// Handle a tap on the 'Options' toolbar item.
        /// </summary>
        public static async void ToolbarItemOptions_Tap()
        {
            await App.Current.MainPage.Navigation.PushAsync(new OptionsPage(), true);
        }

        /// <summary>
        /// Handle a tap on the 'Purchase order' toolbar item.
        /// </summary>
        public static async void ToolbarItemOrder_Tap()
        {
            await App.Current.MainPage.Navigation.PushAsync(new OrderPage(), true);
        }

        /// <summary>
        /// Handle a tap on the 'Help' toolbar item.
        /// </summary>
        public static async void ToolbarItemHelp_Tap()
        {
            await App.Current.MainPage.Navigation.PushAsync(new HelpPage(), true);
        }
    }
}
