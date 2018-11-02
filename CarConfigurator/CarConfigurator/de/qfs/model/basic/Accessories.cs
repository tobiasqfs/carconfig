using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;

namespace CarConfigurator.de.qfs.model.basic
{
    class Accessories
    {
        /// <summary>
        /// The list of accessories that are currently available
        /// </summary>
        private List<Accessory> accessoryList;

        /// <summary>
        /// The accessory that is currently selected in the edit table
        /// </summary>
        private Accessory editModeSelectedAccessory;

        /// <summary>
        /// The accessory that is currently selected in the main table
        /// </summary>
        private Accessory mainTableSelectedAccessory;
        
        /// <summary>
        /// Create a new Accessories class. The default.
        /// </summary>
        public Accessories()
        {
            accessoryList = new List<Accessory>();
        }

        /// <summary>
        /// Get the list of accessories. Mainly implemented for debugging purposes.
        /// </summary>
        /// <returns>The list of accessories.</returns>
        public List<Accessory> GetAccessoryList()
        {
            return this.accessoryList;
        }

        /// <summary>
        /// Add an accessory to the list of the currently available accessories.
        /// </summary>
        /// <param name="newAccessory">The accessory to add</param>
        public void AddAccessory(Accessory newAccessory)
        {
            lock (accessoryList)
            {
                accessoryList.Add(newAccessory);
            }
        }

        
        /// <summary>
        /// Remove an accessory from the list of currently available accessories.
        /// </summary>
        /// <param name="accessory">The accessory to remove</param>
        /// <param name="specials"></param>
        public void RemoveAccessory(Accessory accessory, Specials specials)
        {
            lock (accessoryList)
            {
                accessoryList.Remove(accessory);
                specials.NotifyAccessoryRemoved(accessory);
            }
        }


        /// <summary>
        /// Add an Accessory to the selected ones via its index in the accessoryList
        /// </summary>
        /// <param name="index"></param>
        public void AddAccessorySelected(int index)
        {
            if(index < 0)
            {
                return;
            }
            else
            {
                accessoryList[index].SetSelected(true);
            }
        }


        /// <summary>
        /// Removes an Accessory from the selected ones via its index in the accessoryList
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAccessorySelected(int index)
        {
            accessoryList[index].SetSelected(false);
        }


        /// <summary>
        /// Get an accessory by a position
        /// </summary>
        /// <param name="place">The place of the accessory to get.</param>
        /// <returns>The accessory at that position (or null if there is no acccessory).</returns>
        public Accessory GetAccessory(int place)
        {
            try
            {
                lock (accessoryList)
                {
                    Accessory cur = accessoryList[0];
                    for(int i = 0; i >= 0 && cur != null; i++)
                    {
                        if(i == place)
                        {
                            return cur;
                        }
                        else
                        {
                            cur = accessoryList[i+1];
                            continue;
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException ioore)
            {

            }
            return null;
        }

        /// <summary>
        /// Select the accessory that is currently at position x.
        /// </summary>
        /// <param name="pos">The position of the accessory to select.</param>
        public void SelectAccessoryEditMode(int pos)
        {
            editModeSelectedAccessory = GetAccessory(pos);
        }

        /// <summary>
        /// Select the accessory that is currently present at position x.
        /// </summary>
        /// <param name="pos">The position of the accessory to select</param>
        public void SelectAccessorySelectionMode(int pos)
        {
            mainTableSelectedAccessory = GetAccessory(pos);
        }

        /// <summary>
        /// Get the index of an Accessory object by the id.
        /// </summary>
        /// <param name="id">The id of the Accessory object.</param>
        /// <returns>The index of the Accessory object with the given id (-1 if not found)</returns>
        public int GetIndexOfAccessory(string id)
        {
            for(int i = 0; i < accessoryList.Count; i++)
            {
                if (accessoryList[i].GetId().Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetIndexOfAccessory(Accessory accessory)
        {
            for(int i = 0; i < accessoryList.Count; i++)
            {
                if (accessoryList[i].Equals(accessory))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Create a new accessory. (Button new in the UI)
        /// </summary>
        /// <param name="name">The name of the new accessory.</param>
        /// <param name="id">The id of the new accessory.</param>
        /// <param name="price">The price of the new accessory.</param>
        public void NewAccessory(string name, string id, long price)
        {
            Accessory v = new Accessory(name, id, price);
            AddAccessory(v);
            if (!CarConfigContext.convenience)
            {
                editModeSelectedAccessory = null;
            }
        }

        /// <summary>
        /// Change the currently selected accessory. (Button change in the UI)
        /// </summary>
        /// <param name="name">The new name of the accessory.</param>
        /// <param name="id">The new id of the accessory.</param>
        /// <param name="price">The new price of the accessory.</param>
        public void ChangeSelectedAccessory(string name, string id, string price)
        {
            if(editModeSelectedAccessory != null)
            {
                editModeSelectedAccessory.SetName(name);
                editModeSelectedAccessory.SetId(id);
                editModeSelectedAccessory.SetPriceByPriceString(price);
                if (!CarConfigContext.convenience)
                {
                    editModeSelectedAccessory = null;
                }
            }
        }

        /// <summary>
        /// Delete the selected accessory. (Button delete in the UI)
        /// </summary>
        /// <param name="specials">The list of specials where it may be that this accessory may get deleted from.</param>
        public void DeleteSelectedAccessory(Specials specials)
        {
            if(editModeSelectedAccessory != null)
            {
                RemoveAccessory(editModeSelectedAccessory, specials);
                if (!CarConfigContext.convenience)
                {
                    editModeSelectedAccessory = null;
                }
                else
                {
                    try
                    {
                        if(editModeSelectedAccessory == mainTableSelectedAccessory)
                        {
                            editModeSelectedAccessory = null;
                        }
                        editModeSelectedAccessory = accessoryList[0];
                    }catch(IndexOutOfRangeException ioore)
                    {
                        editModeSelectedAccessory = null;
                    }
                }
            }
        }

        /// <summary>
        /// Get the name of the currently selected accessory.
        /// </summary>
        /// <returns>The name of the currently selected accessory.</returns>
        public string GetNameOfSelectedAccessory()
        {
            if(mainTableSelectedAccessory != null)
            {
                return mainTableSelectedAccessory.GetName();
            }
            return "";
        }

        /// <summary>
        /// Get the id of the currently selected accessory.
        /// </summary>
        /// <returns>The id of the currently selected accessory or null if no accessory is selected</returns>
        public string getIdOfSelectedAccessory()
        {
            if(mainTableSelectedAccessory != null)
            {
                return mainTableSelectedAccessory.GetId();
            }
            return "";
        }

        /// <summary>
        /// Get the price of the currently selected accessory. This is used in order to calculate
        /// and/or show the final price.
        /// </summary>
        /// <returns>The price of the currently selected accessory.</returns>
        public long GetPriceOfSelectedAccessory()
        {
            if(mainTableSelectedAccessory != null)
            {
                return mainTableSelectedAccessory.GetPrice();
            }
            return 0;
        }

        /// <summary>
        /// Get the reference of the currently selected accessory in the edit mode.
        /// </summary>
        /// <returns>The currently selected accessory in the edit mode.</returns>
        public Accessory GetEditModeSelectedAccessory()
        {
            if(editModeSelectedAccessory != null)
            {
                return editModeSelectedAccessory;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the list of accessories.
        /// </summary>
        /// <returns>The list of accessories.</returns>
        public List<Accessory> GetAccessories()
        {
            return this.accessoryList;
        }

        /// <summary>
        /// Clone this selection of accessories.
        /// </summary>
        /// <returns>A clone of this collections of accessories.</returns>
        public Accessories Clone()
        {
            Accessories vs = new Accessories();
            foreach(Accessory a in accessoryList)
            {
                vs.AddAccessory(a.Clone());
            }
            vs.mainTableSelectedAccessory = this.mainTableSelectedAccessory;
            vs.editModeSelectedAccessory = this.editModeSelectedAccessory;
            return vs;
        }
        
        public string ToString()
        {
            return "[Accessories:\n"
                + this.accessoryList
                + "]";
        }

        /// <summary>
        /// Get the default accessories.
        /// </summary>
        /// <returns>The default accessories.</returns>
        public static Accessories GetDefaultAccessories()
        {
            Accessories acs = new Accessories();
            string allAccessories = Language.GetString("accessories");
            foreach(string s in allAccessories.Split(new string[] { "|" }, StringSplitOptions.None))
            {
                try
                {
                    acs.AddAccessory(
                        new Accessory(
                            Language.GetString("accessories." + s + ".description"),
                            Language.GetString("accessories." + s + ".id"),
                            Int32.Parse(Language.GetString("accessories." + s + ".price"))
                            )
                        );
                }catch(InvalidPriceException ipe)
                {

                }
            }
            return acs;
        }
    }
}
