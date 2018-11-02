using CarConfigurator.de.qfs.model.exceptions;
using System;
using System.Collections.Generic;

namespace CarConfigurator.de.qfs.model.lang
{
    class Language
    {
        /// <summary>
        /// The private dictionary containing all german language strings.
        /// </summary>
        private static readonly Dictionary<String, String> _mappings_de =
            new Dictionary<string, string>()
            {
                // application
                { "application.oldVersion.title", "CarConfigurator - Version 1" },
                { "application.oldVersion.shortTitle", "CarConfigurator" },
                { "application.newVersion.title", "CarConfigurator - Neue Version" },
                
                // splash form
                { "splashForm.anon", "Android Carconfigurator" },
                { "splashForm.connect", "Verbinde zu Server ..." },
                { "splashForm.loadConfig", "Lade Konfiguration ..." },
                { "splashForm.loadVehicles", "Lade Fahrzeuge ..." },
                { "splashForm.loadAccessories", "Lade Zubehör ..." },
                { "splashForm.loadSpecials", "Lade Sondermodelle ..." },
                { "splashForm.loadUsers", "Lade Benutzer ..." },
                
                // login form
                { "loginForm.title", "Anmeldung" },
                { "loginForm.user", "Benutzer" },
                { "loginForm.pwd", "Passwort" },
                { "loginForm.status", "Benutzer und Passwort eingeben!" },
                { "loginForm.status.failed", "Login fehlgeschlagen!" },
                { "loginForm.status.success", "Login erfolgreich!" },
                { "loginForm.buttons.login", "Anmelden" },
                { "loginForm.buttons.cancel", "Abbrechen" },
                
                // data
                { "concurrency.concurrencySymbol", "€" },
                { "concurrency.concurrencyBefore", "false" },
                { "concurrency.centsDividor", "," },
                { "concurrency.3dividor", "." },

                { "vehicles", "rolo|minigolf|rassant|rassantFamily|i5" },
                { "vehicles.rolo.name", "Rolo" },
                { "vehicles.rolo.id", "M1" },
                { "vehicles.rolo.price", "1230000" },
                { "vehicles.minigolf.name", "Minigolf" },
                { "vehicles.minigolf.id", "M2" },
                { "vehicles.minigolf.price", "1500000" },
                { "vehicles.rassant.name", "Rassant" },
                { "vehicles.rassant.id", "M3" },
                { "vehicles.rassant.price", "1700000" },
                { "vehicles.rassantFamily.name", "Rassant Family" },
                { "vehicles.rassantFamily.id", "M4" },
                { "vehicles.rassantFamily.price", "1850000" },
                { "vehicles.i5.name", "I5" },
                { "vehicles.i5.id", "M5" },
                { "vehicles.i5.price", "2900000" },

                { "specials", "none|gomera|jazz|luxus" },
                { "specials.none.name", "- kein Sondermodell -" },
                { "specials.none.price", "0" },
                { "specials.none.description", "-" },
                { "specials.none.accessories", "" },
                { "specials.gomera.name", "Gomera" },
                { "specials.gomera.price", "141300" },
                { "specials.gomera.description", "Lackierung in zwei Brauntönen\n" +
                        "Felgen und Stossstangen in Wagenfarbe\n" +
                        "Zentralverriegelung\n" +
                        "Sportfelgen\n" +
                        "Fensterheber hinten\n" +
                        "\n" +
                        "Preis: 1413,00 EUR" },
                { "specials.gomera.accessories", "S3+S4+S6" },
                { "specials.jazz.name", "Jazz" },
                { "specials.jazz.price", "104900" },
                { "specials.jazz.description", "Lackierung in Himmelblau und Dunkelblau\n" +
                        "Felgen und Stossstangen in Wagenfarbe\n" +
                        "Radio mit CD\n" +
                        "Sportfelgen\n" +
                        "Fussmatten\n" +
                        "\n" +
                        "Preis: 1049,00 EUR" },
                { "specials.jazz.accessories", "S4+S7+S8" },
                { "specials.luxus.name", "Luxus" },
                { "specials.luxus.price", "249999" },
                { "specials.luxus.description", "Lackierung in zwei gedeckten Pastellfarben\n" +
                        "Felgen und Stossstangen in Wagenfarbe\n" +
                        "ABS\n" +
                        "Radio mit CD\n" +
                        "Zentralverriegelung\n" +
                        "Fensterheber hinten\n" +
                        "\n" +
                        "Preis: 2499,99 EUR" },
                { "specials.luxus.accessories", "S3+S5+S6+S7" },

                { "accessories", "wheel|mirror|door|rims|antiSkidSystem|windows|radio|mats" },
                { "accessories.wheel.description", "Lederlenkrad" },
                { "accessories.wheel.id", "S1" },
                { "accessories.wheel.price", "36000" },
                { "accessories.mirror.description", "Beheizbare Aussenspiegel" },
                { "accessories.mirror.id", "S2" },
                { "accessories.mirror.price", "21000" },
                { "accessories.door.description", "Zentralverriegelung" },
                { "accessories.door.id", "S3" },
                { "accessories.door.price", "120000" },
                { "accessories.rims.description", "Sportfelgen" },
                { "accessories.rims.id", "S4" },
                { "accessories.rims.price", "90000" },
                { "accessories.antiSkidSystem.description", "ABS" },
                { "accessories.antiSkidSystem.id", "S5" },
                { "accessories.antiSkidSystem.price", "99000" },
                { "accessories.windows.description", "Fensterheber hinten" },
                { "accessories.windows.id", "S6" },
                { "accessories.windows.price", "49000" },
                { "accessories.radio.description", "Radio mit CD-Wechsler" },
                { "accessories.radio.id", "S7" },
                { "accessories.radio.price", "47000" },
                { "accessories.mats.description", "Fussmatten" },
                { "accessories.mats.id", "S8" },
                { "accessories.mats.price", "2600" },
                
                // menu
                { "menu.file", "Datei" },
                { "menu.file.reset", "Zurücksetzen" },
                { "menu.file.logout", "Logout" },
                { "menu.file.exit", "Beenden" },
                { "menu.edit", "Einstellungen" },
                { "menu.edit.newButton", "Neu" },
                { "menu.edit.contextActions.change", "Ändern" },
                { "menu.edit.contextActions.delete", "Löschen" },
                { "menu.edit.contextActions.details", "Details" },
                { "menu.edit.vehicles", "Fahrzeuge" },
                { "menu.edit.vehicles.title", "Fahrzeuge bearbeiten" },
                { "menu.edit.vehicles.newButton", "Neu" },
                { "menu.edit.vehicles.add.vehicleName", "Fahrzeugname" },
                { "menu.edit.vehicles.add.vehiclePrice", "Preis" },
                { "menu.edit.vehicles.add.finishButton", "Fertig" },
                { "menu.edit.vehicles.add.cancelButton", "Abbrechen" },

                { "menu.edit.specials", "Sondermodelle" },
                { "menu.edit.specials.title", "Sondermodelle bearbeiten" },
                { "menu.edit.specials.newButton", "Neu" },
                { "menu.edit.specials.add.specialName", "Modellname" },
                { "menu.edit.specials.add.specialPrice", "Preis" },
                { "menu.edit.specials.add.seperatePrices", "Einzelpreise" },
                { "menu.edit.specials.add.specialDescription", "Beschreibung" },
                { "menu.edit.specials.add.containedAccessories", "Enthaltenes Zubehör" },
                { "menu.edit.specials.add.finishButton", "Fertig" },
                { "menu.edit.specials.add.cancelButton", "Abbrechen" },

                { "menu.edit.accessories", "Zubehör" },
                { "menu.edit.accessories.title", "Zubehör bearbeiten" },
                { "menu.edit.accessories.add.accessoryName", "Beschreibung" },
                { "menu.edit.accessories.add.accessoryId", "ID" },
                { "menu.edit.accessories.add.accessoryPrice", "Preis" },
                { "menu.edit.accessories.add.finishButton", "Fertig" },
                { "menu.edit.accessories.add.cancelButton", "Abbrechen" },

                { "menu.order", "Bestellung" },

                { "menu.order.view", "Auswahldetails ansehen" },
                { "menu.order.view.selectedVehicle", "Ausgewähltes Fahrzeug" },
                { "menu.order.view.noSelectedVehicle", "Kein Fahrzeug ausgewählt" },
                { "menu.order.view.selectedSpecial", "Ausgewähltes Sondermodell" },
                { "menu.order.view.selectedAccessory", "Ausgewähltes Zubehör" },
                { "menu.order.view.noSelectedAccessory", "Kein Zubehöhr ausgewählt!" },
                { "menu.order.view.endPrice", "Endpreis" },
                { "menu.order.view.ok", "OK" },

                { "menu.order.order", "Bestellen" },
                { "menu.order.order.vehicleDetails", "Fahrzeuginformationen" },
                { "menu.order.order.specialDetails", "Sondermodellinformationen" },
                { "menu.order.order.accessoryDetails", "Zubehörinformationen" },
                { "menu.order.order.priceDetails", "Preisinformationen" },
                { "menu.order.order.contactDetails", "Kontaktinformationen" },
                { "menu.order.order.surname", "Nachname" },
                { "menu.order.order.firstName", "Vorname" },
                { "menu.order.order.streetAddress", "Adresse" },
                { "menu.order.order.zipCode", "PLZ" },
                { "menu.order.order.city", "Ort" },
                { "menu.order.order.country", "Land" },
                { "menu.order.order.phoneNumber", "Telefonnummer" },
                { "menu.order.order.emailAddress", "E-Mail Adresse" },
                { "menu.order.order.sendPurchaseOrder", "Bestellung absenden" },
                { "menu.order.order.cancel", "Abbrechen" },

                { "menu.order.statistics", "Statistiken" },
                { "menu.order.statistics.week", "Woche" },
                { "menu.order.statistics.orderedAmount", "Bestellmenge" },

                { "menu.help", "Hilfe" },
                { "menu.help.info", "Info" },
                { "menu.help.info.labelCarConfigurator.oldVersion", "Car Configurator Version 2.0" },
                { "menu.help.info.labelCarConfigurator.newVersion", "CarConfigurator Version 3.0" },
                { "menu.help.info.labelCopyright", "Copyright (C) 2004 - %s\nQuality First Software GmbH\nbased on C++ implementation of Imbus AG" },

                { "menu.help.buggy", "Fehlerhaft" },
                { "menu.help.newVersion", "Neue Version" },
                { "menu.help.lasttest", "Lasttest Modus" },
                
                // tabs
                { "tabs.vehicles", "Fahrzeuge" },
                { "tabs.vehicles.label", "Fahrzeuge" },
                { "tabs.vehicles.table.model", "Modell" },
                { "tabs.vehicles.table.id", "ID" },
                { "tabs.vehicles.table.price", "Preis" },
                { "tabs.specials", "Sondermodelle" },
                { "tabs.specials.label", "Sondermodelle" },
                { "tabs.accessories", "Zubehör" },
                { "tabs.accessories.label", "Zubehör" },
                { "tabs.accessories.table.checkbox", "" },
                { "tabs.accessories.table.description", "Beschreibung" },
                { "tabs.accessories.table.id", "ID" },
                { "tabs.accessories.table.price", "Preis" },
                { "tabs.accessories.addAccessoriesToFinalPrice", "Zubehörpreis zum Endpreis addieren" },
                { "tabs.advanced", "Erweitert" },
                { "tabs.advanced.label", "Erweitert" },
                
                // calculation pane
                { "calcpane.priceModel", "Preis Basismodell" },
                { "calcpane.priceSpecial", "Preis Sonderausstattung" },
                { "calcpane.discount", "Rabatt" },
                { "calcpane.endprice", "Endpreis" },
                { "calcpane.discountButton", "-5%" },
                { "calcpane.toggleButton.expand", "Vergrößern" },
                { "calcpane.toggleButton.hide", "Verkleinern" },

                // display alerts
                { "alerts.specials", "Sondermodell Auswahl" },
                { "alerts.invalidPrice.title", "Fehler" },
                { "alerts.invalidPrice.text", "Kein gültiger Preis gesetzt!" },
                { "alerts.invalidDiscount.title", "Fehler" },
                { "alerts.invalidDiscount.text", "Kein gültiger Rabatt gesetzt!" },
                { "alerts.contactDetails.title", "Fehler" },
                { "alerts.contactDetails.text", "Es wurden nicht alle Kontaktdaten gefüllt!\nBitte füllen Sie alle Felder aus!" },
                { "alerts.orderPlaced.title" , "Erfolg" },
                { "alerts.orderPlaced.text", "Ihre Bestellung wurde aufgegeben!" },
                { "alerts.ok", "Ok" }
            };

        /// <summary>
        /// An unmodifiable map containing all german language strings.
        /// </summary>
        public static readonly Dictionary<string, string> mappings_de = _mappings_de;

        /// <summary>
        /// The private dictionary containing all english language strings.
        /// </summary>
        private static readonly Dictionary<string, string> _mappings_en =
            new Dictionary<string, string>()
            {
                // application
                { "application.oldVersion.title", "CarConfigurator - Version 1" },
                { "application.oldVersion.shortTitle", "CarConfigurator" },
                { "application.newVersion.title", "CarConfigurator - New Version" },

                // splash form
                { "splashForm.anon", "Android Carconfigurator" },
                { "splashForm.connect", "Connect to server ..." },
                { "splashForm.loadConfig", "Load configuration ..." },
                { "splashForm.loadVehicles", "Load vehicles ..." },
                { "splashForm.loadAccessories", "Load accessories ..." },
                { "splashForm.loadSpecials", "Load specials ..." },
                { "splashForm.loadUsers", "Load users ..." },

                // login form
                { "loginForm.title", "Login" },
                { "loginForm.user", "User" },
                { "loginForm.pwd", "Password" },
                { "loginForm.status", "Insert username and password!" },
                { "loginForm.status.success", "Login successful!" },
                { "loginForm.status.failed", "Login failed!" },
                { "loginForm.buttons.login", "Login" },
                { "loginForm.buttons.cancel", "Cancel" },

                // data
                { "concurrency.concurrencySymbol", "$" },
                { "concurrency.concurrencyBefore", "true" },
                { "concurrency.centsDividor", "." },
                { "concurrency.3dividor", "," },

                { "vehicles", "rolo|minigolf|rassant|rassantFamily|i5" },
                { "vehicles.rolo.name", "Rolo" },
                { "vehicles.rolo.id", "M1" },
                { "vehicles.rolo.price", "1230000" },
                { "vehicles.minigolf.name", "Minigolf" },
                { "vehicles.minigolf.id", "M2" },
                { "vehicles.minigolf.price", "1500000" },
                { "vehicles.rassant.name", "Rassant" },
                { "vehicles.rassant.id", "M3" },
                { "vehicles.rassant.price", "1700000" },
                { "vehicles.rassantFamily.name", "Rassant Family" },
                { "vehicles.rassantFamily.id", "M4" },
                { "vehicles.rassantFamily.price", "1850000" },
                { "vehicles.i5.name", "I5" },
                { "vehicles.i5.id", "M5" },
                { "vehicles.i5.price", "2900000" },

                { "specials", "none|gomera|jazz|luxus" },
                { "specials.none.name", "- no special model -" },
                { "specials.none.price", "0" },
                { "specials.none.description", "-" },
                { "specials.none.accessories", "" },
                { "specials.gomera.name", "Gomera" },
                { "specials.gomera.price", "141300" },
                { "specials.gomera.description", "Varnishing in two shades of brown\n" +
                        "Rims and bumpers in same color as car\n" +
                        "Centralized door locking\n" +
                        "Alloy rims\n" +
                        "Power windows in back\n" +
                        "\n" +
                        "Price: 1413.00 EUR" },
                { "specials.gomera.accessories", "S3+S4+S6" },
                { "specials.jazz.name", "Jazz" },
                { "specials.jazz.price", "104900" },
                { "specials.jazz.description", "Varnishing bright and dark blue\n" +
                        "Rims and bumpers in same color as car\n" +
                        "Radio with CD\n" +
                        "Alloy rims\n" +
                        "Mats\n" +
                        "\n" +
                        "Price: 1049.00 EUR" },
                { "specials.jazz.accessories", "S4+S7+S8" },
                { "specials.luxus.name", "Luxus" },
                { "specials.luxus.price", "249999" },
                { "specials.luxus.description", "Varnishing in two muted pastel colors\n" +
                        "Rims and bumpers in same color as car\n" +
                        "Anti-skid system\n" +
                        "Radio with CD\n" +
                        "Centralized door locking\n" +
                        "Power windows in back\n" +
                        "\n" +
                        "Price: 2499.99 EUR" },
                { "specials.luxus.accessories", "S3+S5+S6+S7" },

                { "accessories", "wheel|mirror|door|rims|antiSkidSystem|windows|radio|mats" },
                { "accessories.wheel.description", "Steering wheel in leather" },
                { "accessories.wheel.id", "S1" },
                { "accessories.wheel.price", "36000" },
                { "accessories.mirror.description", "Heatable outside mirror" },
                { "accessories.mirror.id", "S2" },
                { "accessories.mirror.price", "21000" },
                { "accessories.door.description", "Centralized door locking" },
                { "accessories.door.id", "S3" },
                { "accessories.door.price", "120000" },
                { "accessories.rims.description", "Alloy rims" },
                { "accessories.rims.id", "S4" },
                { "accessories.rims.price", "90000" },
                { "accessories.antiSkidSystem.description", "Anti-skid system" },
                { "accessories.antiSkidSystem.id", "S5" },
                { "accessories.antiSkidSystem.price", "99000" },
                { "accessories.windows.description", "Power windows in back" },
                { "accessories.windows.id", "S6" },
                { "accessories.windows.price", "49000" },
                { "accessories.radio.description", "Radio with CD" },
                { "accessories.radio.id", "S7" },
                { "accessories.radio.price", "47000" },
                { "accessories.mats.description", "Mats" },
                { "accessories.mats.id", "S8" },
                { "accessories.mats.price", "2600" },

                // menu
                { "menu.file", "File" },
                { "menu.file.reset", "Reset" },
                { "menu.file.logout", "Logout" },
                { "menu.file.exit", "Exit" },
                { "menu.edit", "Options" },
                { "menu.edit.newButton", "New" },
                { "menu.edit.contextActions.change", "Change" },
                { "menu.edit.contextActions.delete", "Delete" },
                { "menu.edit.contextActions.details", "Details" },
                { "menu.edit.vehicles", "Vehicles" },
                { "menu.edit.vehicles.title", "Edit vehicles" },
                { "menu.edit.vehicles.add.vehicleName", "Vehicle name" },
                { "menu.edit.vehicles.add.vehiclePrice", "Price" },
                { "menu.edit.vehicles.add.finishButton", "Finish" },
                { "menu.edit.vehicles.add.cancelButton", "Cancel" },

                { "menu.edit.specials", "Specials" },
                { "menu.edit.specials.title", "Edit specials" },
                { "menu.edit.specials.newButton", "New" },
                { "menu.edit.specials.add.specialName", "Model name" },
                { "menu.edit.specials.add.specialPrice", "Price" },
                { "menu.edit.specials.add.seperatePrices", "Seperate prices" },
                { "menu.edit.specials.add.specialDescription", "Description" },
                { "menu.edit.specials.add.containedAccessories", "Contained accessories" },
                { "menu.edit.specials.add.finishButton", "Finish" },
                { "menu.edit.specials.add.cancelButton", "Cancel" },

                { "menu.edit.accessories", "Accessories" },
                { "menu.edit.accessories.title", "Edit accessories" },
                { "menu.edit.accessories.add.accessoryName", "Description" },
                { "menu.edit.accessories.add.accessoryId", "ID" },
                { "menu.edit.accessories.add.accessoryPrice", "Price" },
                { "menu.edit.accessories.add.finishButton", "Finish" },
                { "menu.edit.accessories.add.cancelButton", "Cancel" },

                { "menu.order", "Purchase order" },

                { "menu.order.view", "View selected details" },
                { "menu.order.view.selectedVehicle", "Selected Vehicle" },
                { "menu.order.view.noSelectedVehicle", "No vehicle selected" },
                { "menu.order.view.selectedSpecial", "Selected Special" },
                { "menu.order.view.selectedAccessory", "Selected accessory" },
                { "menu.order.view.noSelectedAccessory", "No accessory selected!" },
                { "menu.order.view.endPrice", "Final price" },
                { "menu.order.view.ok", "OK" },

                { "menu.order.order", "Send order" },
                { "menu.order.order.vehicleDetails", "Vehicle details" },
                { "menu.order.order.specialDetails", "Special details" },
                { "menu.order.order.accessoryDetails", "Accessory details" },
                { "menu.order.order.priceDetails", "Price details" },
                { "menu.order.order.contactDetails", "Contact details" },
                { "menu.order.order.surname", "Surname" },
                { "menu.order.order.firstName", "First name" },
                { "menu.order.order.streetAddress", "Street address" },
                { "menu.order.order.zipCode", "Zip Code" },
                { "menu.order.order.city", "City" },
                { "menu.order.order.country", "Country" },
                { "menu.order.order.phoneNumber", "Phone number" },
                { "menu.order.order.emailAddress", "E-Mail address" },
                { "menu.order.order.sendPurchaseOrder", "Send purchase order" },
                { "menu.order.order.cancel", "Cancel" },

                { "menu.order.statistics", "Statistics" },
                { "menu.order.statistics.week", "Week" },
                { "menu.order.statistics.orderedAmount", "Ordered Amount" },

                { "menu.help", "Help" },
                { "menu.help.info", "Info" },
                { "menu.help.info.labelCarConfigurator.oldVersion", "Car Configurator Version 2.0" },
                { "menu.help.info.labelCarConfigurator.newVersion", "CarConfigurator Version 3.0" },
                { "menu.help.info.labelCopyright", "Copyright (C) 2004 - %s\nQuality First Software GmbH\nbased on C++ implementation of Imbus AG" },

                { "menu.help.buggy", "Buggy" },
                { "menu.help.newVersion", "New version" },
                { "menu.help.lasttest", "Load testing mode" },

                // tabs
                { "tabs.vehicles", "Vehicles" },
                { "tabs.vehicles.label", "Vehicles" },
                { "tabs.vehicles.table.model", "Model" },
                { "tabs.vehicles.table.id", "ID" },
                { "tabs.vehicles.table.price", "Price" },
                { "tabs.specials", "Specials" },
                { "tabs.specials.label", "Specials" },
                { "tabs.accessories", "Accessories" },
                { "tabs.accessories.label", "Accessories" },
                { "tabs.accessories.table.checkbox", "" },
                { "tabs.accessories.table.description", "Description" },
                { "tabs.accessories.table.id", "ID" },
                { "tabs.accessories.table.price", "Price" },
                { "tabs.accessories.addAccessoriesToFinalPrice", "Add accessories price to final price" },
                { "tabs.advanced", "Advanced" },
                { "tabs.advanced.label", "Advanced" },

                // calculation pane
                { "calcpane.priceModel", "Base price" },
                { "calcpane.priceSpecial", "Specials price" },
                { "calcpane.discount", "Discount" },
                { "calcpane.endprice", "Final price" },
                { "calcpane.discountButton", "-5%" },
                { "calcpane.toggleButton.expand", "Expand" },
                { "calcpane.toggleButton.hide", "Hide" },

                // display alerts
                { "alerts.specials", "Specials Selection" },
                { "alerts.invalidPrice.title", "Error" },
                { "alerts.invalidPrice.text", "Invalid price value!" },
                { "alerts.invalidDiscount.title", "Error" },
                { "alerts.invalidDiscount.text", "Invalid discount value!" },
                { "alerts.contactDetails.title", "Error" },
                { "alerts.contactDetails.text", "Mandatory contact details missing!\nPlease specify all contact details!" },
                { "alerts.orderPlaced.title" , "Success" },
                { "alerts.orderPlaced.text", "Your order has been placed!" },
                { "alerts.ok", "Ok" }
            };

        /// <summary>
        /// An unmodifiable map containing all german language strings.
        /// </summary>
        public static readonly Dictionary<string, string> mappings_en = _mappings_en;

        /// <summary>
        /// The language that is currently selected.
        /// </summary>
        private static SupportedLanguage currentlySelectedLanguage = SupportedLanguage.ENGLISH;

        /// <summary>
        /// Get a string in the currently selected user language.
        /// </summary>
        /// <param name="v">The string identifier for the string to get.</param>
        /// <returns>The translated string.</returns>
        internal static string GetString(string v)
        {
            String retVal = null;
            if(currentlySelectedLanguage == SupportedLanguage.ENGLISH)
            {
                retVal = mappings_en[v];
            }else if(currentlySelectedLanguage == SupportedLanguage.GERMAN)
            {
                retVal = mappings_de[v];
            }
            //TODO if retVal == null do error handling
            return retVal;
        }

        /// <summary>
        /// Set the currently supported language.
        /// </summary>
        /// <param name="sl">The currently supported language</param>
        public static void SetLanguage(SupportedLanguage sl)
        {
            currentlySelectedLanguage = sl;
        }

        /// <summary>
        /// Return a string representation of the price.
        /// </summary>
        /// <param name="price">The price to turn into a string representation.</param>
        /// <returns>A string representation of the given price.</returns>
        public static string FormatPrice(long price)
        {
            // negative or positive?
            Boolean negativeFlag = price < 0;
            if (negativeFlag) { price = -price; }

            // divide in €/$ and cents
            long value = price / 100;
            long cents = price % 100;

            // format centStr
            string centStr = cents.ToString();
            if (cents < 10)
            {
                centStr = "0" + centStr;
            }
            while (centStr.Length < 2)
            {
                centStr = centStr + "0";
            }

            // add commas
            string every3 = GetString("concurrency.3dividor");
            string valueStr = "";
            do
            {
                string f = "" + (value % 1000);
                while (f.Length < 3)
                {
                    f = "0" + f;
                }
                value = value / 1000;
                if ("".Equals(valueStr))
                {
                    valueStr = f;
                }
                else
                {
                    valueStr = f + every3 + valueStr;
                }
            } while (value != 0);
            while (valueStr.StartsWith("0") || valueStr.StartsWith(every3))
            {
                valueStr = valueStr.Substring(1);
            }
            if ("".Equals(valueStr))
            {
                valueStr = "0";
            }

            //add dot
            string beforeCents = GetString("concurrency.centsDividor");
            string pp = "" + valueStr + beforeCents + centStr;
            // add concurrency
            Boolean before = Boolean.Parse(GetString("concurrency.concurrencyBefore"));
            string concurrency = GetString("concurrency.concurrencySymbol");
            if (before)
            {
                return ((negativeFlag) ? "-" : "") + concurrency + " " + pp;
            }
            else
            {
                return ((negativeFlag) ? "-" : "") + pp + " " + concurrency;
            }
        }

        /// <summary>
        /// Parse the price.
        /// </summary>
        /// <param name="price">The string to parse.</param>
        /// <returns>The price as long.</returns>
        public static long ParsePrice(string price)
        {
            string concurrency = GetString("concurrency.concurrencySymbol");
            string every3 = GetString("concurrency.3dividor");
            string beforeCents = GetString("concurrency.centsDividor");
            //remove spaces and concurrency symbol
            price = price.Replace(" ", "");
            if (price.StartsWith(concurrency))
            {
                price = price.Substring(concurrency.Length);
            }
            if (price.EndsWith(concurrency))
            {
                price = price.Substring(0, price.Length - concurrency.Length);
            }
            // remove the separator character
            price = price.Replace(every3, "");
            // handle the comma/dot separating the cents from the value
            Boolean mult100 = true;
            if (price.Contains(beforeCents))
            {
                int index = price.IndexOf(beforeCents);
                if (index == price.LastIndexOf(beforeCents))
                {
                    mult100 = false;
                    if (index == price.Length)
                    {
                        price = price + "00";
                    }
                    else if (index == price.Length - 1)
                    {
                        price = price + "0";
                    }
                    else
                    {
                        int endIndex = (index + 2 > price.Length) ? price.Length : index + 2;
                        price = price.Substring(0, endIndex+1);
                    }
                }
                price = price.Replace(beforeCents, "");
            }
            try
            {
                long val = long.Parse(price);
                return val * ((mult100) ? 100 : 1);
            }
            catch (Exception e)
            {
                throw new InvalidPriceException("", e);
            }
        }
    }
}
