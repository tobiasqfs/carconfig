using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;

namespace CarConfigurator.de.qfs.model.basic
{
    class Specials
    {
        /// <summary>
        /// The list of specials that are currently available.
        /// </summary>
        private List<Special> specialList;

        /// <summary>
        /// The special that is currently selected in edit mode.
        /// </summary>
        private Special editModeSelectedSpecial;

        /// <summary>
        /// The special thast is currently selected in the "main mode".
        /// </summary>
        private Special mainTableSelectedSpecial;

        /// <summary>
        /// Create a new Specials class. The default.
        /// </summary>
        public Specials()
        {
            this.specialList = new List<Special>();
        }

        /// <summary>
        /// Get the list of specials. Mainly implemented for debugging purposes.
        /// </summary>
        /// <returns>The list of specials.</returns>
        public List<Special> GetSpecialList()
        {
            return this.specialList;
        }

        /// <summary>
        /// Add a special to this list of specials.
        /// </summary>
        /// <param name="special">The special to add.</param>
        public void AddSpecial(Special special)
        {
            lock (specialList)
            {
                specialList.Add(special);
            }
        }

        /// <summary>
        /// Remove a special from this list of specials.
        /// </summary>
        /// <param name="special">The special to remove from this list.</param>
        public void RemoveSpecial(Special special)
        {
            specialList.Remove(special);
        }

        /// <summary>
        /// Get the special at position pos in this list.
        /// </summary>
        /// <param name="pos"> The position to get the special for.</param>
        /// <returns>The special at position pos or null if either pos is a negative number or 
        /// if this list of specials is not long enough.</returns>
        private Special GetSpecial(int pos)
        {
            Special s = null;
            try
            {
                lock (specialList)
                {
                    s = specialList[pos];
                }
            } catch (IndexOutOfRangeException ioore)
            {

            }
            return s;
        }

        /// <summary>
        /// Get the list of accessories.
        /// </summary>
        /// <param name="accesIds">The ids of the different accessories.</param>
        /// <param name="acs">The current list of accessories.</param>
        /// <returns></returns>
        private List<Accessory> GetAccessoryList(List<int> accesIds, Accessories acs)
        {
            List<Accessory> ac1 = new List<Accessory>();
            foreach (int i in accesIds)
            {
                ac1.Add(acs.GetAccessories()[i]);
            }
            return ac1;
        }

        /// <summary>
        /// Notify that a certain accessory was removed.
        /// </summary>
        /// <param name="accessory">The accessory to remove.</param>
        public void NotifyAccessoryRemoved(Accessory accessory)
        {
            lock (specialList)
            {
                foreach (Special s in specialList)
                {
                    s.RemoveAccessory(accessory);
                }
            }
        }

        /// <summary>
        /// Select the special that is currently present at position x. (Click on a table row in the UI)
        /// </summary>
        /// <param name="pos">The position of the special to select.</param>
        public void SelectSpecialEditMode(int pos)
        {
            editModeSelectedSpecial = GetSpecial(pos);
        }

        /// <summary>
        /// Select the special that is currently present at position x. (Click on a table row in the UI)
        /// </summary>
        /// <param name="pos">The position of the special to select.</param>
        public void SelectSpecialMainTableMode(int pos)
        {
            mainTableSelectedSpecial = GetSpecial(pos);
        }

        /// <summary>
        /// Get the index of a Special object.
        /// </summary>
        /// <param name="special">The special to get the index of.</param>
        /// <returns>The index of the special (-1 if not found)</returns>
        public int GetIndexOfSpecial(Special special)
        {
            for (int i = 0; i < specialList.Count; i++)
            {
                if (specialList[i].Equals(special))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Create a new special. (Button new in the UI)
        /// </summary>
        /// <param name="name">The name of the new special.</param>
        /// <param name="description">The description of the new special.</param>
        /// <param name="price">The price of the new special.</param>
        public void NewSpecial(string name, string description, string price, List<int> accesIds, Accessories acs)
        {
            Special v = new Special(name, description, price, GetAccessoryList(accesIds, acs));
            AddSpecial(v);
            if (!CarConfigContext.convenience)
            {
                editModeSelectedSpecial = null;
            }
        }

        /// <summary>
        /// Change the currently selected special. (Button change in the UI)
        /// </summary>
        /// <param name="name">The new name of the special.</param>
        /// <param name="description">The new description of the special.</param>
        /// <param name="price">The new price of the special.</param>
        public void ChangeSelectedSpecial(string name, string description, string price, List<int> accesIds, Accessories acs)
        {
            if (editModeSelectedSpecial != null)
            {
                editModeSelectedSpecial.SetName(name);
                editModeSelectedSpecial.SetDescription(description);
                editModeSelectedSpecial.SetPriceByPriceString(price);
                editModeSelectedSpecial.SetAccessories(GetAccessoryList(accesIds, acs));
                if (!CarConfigContext.convenience)
                {
                    editModeSelectedSpecial = null;
                }
            }
        }

        /// <summary>
        /// Delete the selected special. (Button delete in the UI)
        /// </summary>
        public void DeleteSelectedSpecial()
        {
            if (editModeSelectedSpecial != null)
            {
                RemoveSpecial(editModeSelectedSpecial);
                if (!CarConfigContext.convenience)
                {
                    editModeSelectedSpecial = null;
                    mainTableSelectedSpecial = null;
                }
                else
                {
                    try
                    {
                        if (editModeSelectedSpecial == mainTableSelectedSpecial)
                        {
                            mainTableSelectedSpecial = null;
                        }
                        mainTableSelectedSpecial = specialList[0];
                    } catch (IndexOutOfRangeException ioore)
                    {
                        mainTableSelectedSpecial = null;
                    }
                }
            }
        }

        /// <summary>
        /// Get the name of the currently selected special.
        /// </summary>
        /// <returns>The name of the currently selected special.</returns>
        public string GetNameOfSelectedSpecial()
        {
            if (mainTableSelectedSpecial != null)
            {
                return mainTableSelectedSpecial.GetName();
            }
            return "";
        }

        /// <summary>
        /// Get the description of the currently selected special.
        /// </summary>
        /// <returns>The description of the currently selected special.</returns>
        public String GetDescriptionOfSelectedSpecial()
        {
            if (mainTableSelectedSpecial != null)
            {
                return mainTableSelectedSpecial.GetDescription();
            }
            return "";
        }

        /// <summary>
        /// Get the price of the currently selected special.
        /// </summary>
        /// <returns>The price of the currently selected special.</returns>
        public long GetPriceOfSelectedSpecial()
        {
            if (mainTableSelectedSpecial != null)
            {
                return mainTableSelectedSpecial.GetPrice();
            }
            return 0;
        }

        /// <summary>
        /// Get the reference of the currently selected special.
        /// </summary>
        /// <returns>The reference of the currently selected special.   </returns>
        public Special GetSelectedSpecial()
        {
            if(mainTableSelectedSpecial != null)
            {
                return mainTableSelectedSpecial;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the reference of the currently selected vehicle in the edit mode.
        /// </summary>
        /// <returns>The currently selected vehicle in the edit mode.</returns>
        public Special GetEditModeSelectedSpecial()
        {
            if(editModeSelectedSpecial != null)
            {
                return editModeSelectedSpecial;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Clone this collection of specials.
        /// </summary>
        /// <returns>A clone of this collections of specials.</returns>
        public Specials Clone()
        {
            Specials ss = new Specials();
            foreach (Special s in specialList)
            {
                ss.AddSpecial(s.Clone());
            }
            ss.mainTableSelectedSpecial = this.mainTableSelectedSpecial;
            ss.editModeSelectedSpecial = this.editModeSelectedSpecial;
            return ss;
        }

        /// <summary>
        /// A textual representation of this object. Mainly for debug purpose.
        /// </summary>
        /// <returns>A textual representation of this object.</returns>
        public string ToString()
        {
            return "[Specials:\n"
                + this.specialList
                + "]";
        }

        /// <summary>
        /// Get the default specials.
        /// </summary>
        /// <param name="ac">The accessories.</param>
        /// <returns>The default specials.</returns>
        public static Specials GetDefaultSpecials(Accessories ac)
        {
            Specials ss = new Specials();
            string allSpecials = Language.GetString("specials");
            foreach (string s in allSpecials.Split(new string[] { "|" }, StringSplitOptions.None))
            {
                try
                {
                    List<Accessory> acs = new List<Accessory>();
                    string[] myAccessories = Language.GetString("specials." + s + ".accessories").Split(
                        new string[] { "+" }, StringSplitOptions.None);
                    foreach (String acId in myAccessories)
                    {
                        foreach (Accessory a in ac.GetAccessories())
                        {
                            if (a.GetId().Equals(acId))
                            {
                                acs.Add(a);
                            }
                        }
                    }
                    ss.AddSpecial(
                        new Special(
                            Language.GetString("specials." + s + ".name"),
                            Language.GetString("specials." + s + ".description"),
                            Int32.Parse(Language.GetString("specials." + s + ".price")),
                            acs
                        )
                    );
                }
                catch (InvalidPriceException ipe)
                {
                }
            }
            return ss;
        }
    }
}
