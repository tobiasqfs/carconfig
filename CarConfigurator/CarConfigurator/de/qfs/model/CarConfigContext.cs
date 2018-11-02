using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.settings.options;
using System;
using Xamarin.Forms;

namespace CarConfigurator.de.qfs.model.basic
{
    class CarConfigContext
    {
        /// <summary>
        /// The language to use. The default fallback language is English.
        /// </summary>
        public static SupportedLanguage language = SupportedLanguage.ENGLISH;

        /// <summary>
        /// Seconds to show the splash dialog.
        /// </summary>
        public static int showSplash = 0;

        /// <summary>
        /// Whether to use an animated splash screen.
        /// </summary>
        public static Boolean animatedSplash = false;

        /// <summary>
        /// Whether the user needs to login.
        /// </summary>
        public static Boolean needLogin = false;

        /// <summary>
        /// Whether to shake the status whenever the login fails.
        /// </summary>
        public static Boolean loginShakeStatus = false;

        /// <summary>
        /// Whether this is the new version of the AndroidCarConfigurator Application.
        /// </summary>
        public static Boolean newVersion = false;

        /// <summary>
        /// Whether this is the buggy version of the AndroidCarConfigurator Application.
        /// </summary>
        public static Boolean buggy = false;

        /// <summary>
        /// Whether this is the loadtest version of the AndroidCarConfigurator Application.
        /// </summary>
        public static Boolean loadTest = false;

        /// <summary>
        /// Whether to use the convenience mode.
        /// </summary>
        public static Boolean convenience = false;

        /// <summary>
        /// The user currently logged in.
        /// </summary>
        public static string user = "tester";

        /// <summary>
        /// Whether to use toast objects instead of fragment objects for error messages
        /// when in info/warning/error message box should get shown.
        /// </summary>
        public static Boolean useToasts = false;

        /// <summary>
        /// A refernce to the vehicles page.
        /// </summary>
        public static VehiclesPage vehiclesPage;

        /// <summary>
        /// A refernce to the options>vehicles page.
        /// </summary>
        public static OptionsVehiclesPage optionsVehiclesPage;

        /// <summary>
        /// A reference to the specials page.
        /// </summary>
        public static SpecialsPage specialsPage;

        /// <summary>
        /// A reference to the options>specials page.
        /// </summary>
        public static OptionsSpecialsPage optionsSpecialsPage;

        /// <summary>
        /// A reference to the accessories page.
        /// </summary>
        public static AccessoriesPage accessoriesPage;

        /// <summary>
        /// A refernce to the options>accessories page.
        /// </summary>
        /// <returns></returns>
        public static OptionsAccessoriesPage optionsAccessoriesPage;

        /// <summary>
        /// Parse an incoming bundle (commandline options)
        /// </summary>
        /*
        public static void ParseBundle(Bundle bundle)
        {
            if(bundle == null) { return; }
            if (bundle.ContainsKey("lang"))
            {
                string passedLanguage = bundle.GetString("lang");
                if(passedLanguage != null && passedLanguage.ToUpper().Equals("DE"))
                {
                    language = SupportedLanguage.GERMAN;
                }
            }
            else
            {
                // TODO find java.util.Locale.getDefault().getLanguage()  - if("DE".Equals(Locale.getDefault().getLanguage().toUpper()))
                language = SupportedLanguage.GERMAN;
            }
            if (bundle.ContainsKey("splashTime")) { showSplash = bundle.GetInt("splashTime", 0);
            }else if (bundle.ContainsKey("splash"))
            {
                Boolean splash = bundle.GetBoolean("splash", false);
                if (splash)
                {
                    showSplash = 5000;
                }
            }
            if (bundle.ContainsKey("login")) { needLogin = bundle.GetBoolean("login", false); }
            if (bundle.ContainsKey("loginShakeStatus")) { loginShakeStatus = bundle.GetBoolean("loginShakeStatus", false); }
            if (bundle.ContainsKey("animatedSplash")) { animatedSplash = bundle.GetBoolean("animatedSplash", false); }
            if (bundle.ContainsKey("loadtest")) { loadTest = bundle.GetBoolean("loadtest", false); }
            if (bundle.ContainsKey("buggy")) { buggy = bundle.GetBoolean("buggy", false); }
            if (bundle.ContainsKey("newVersion")) { newVersion = bundle.GetBoolean("newVersion", false); }
            if (bundle.ContainsKey("convenience")) { convenience = bundle.GetBoolean("convenience", false); }
            if (bundle.ContainsKey("useToasts")) { useToasts = bundle.GetBoolean("useToasts", false); }
        }
        */
    }
}
