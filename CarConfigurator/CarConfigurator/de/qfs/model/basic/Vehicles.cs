using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;

namespace CarConfigurator.de.qfs.model.basic
{
    class Vehicles
    {

        /// <summary>
        /// The list of vehicles that are currently available.
        /// </summary>
        private List<Vehicle> vehicleList;

        /// <summary>
        /// The vehicle that is currently selected in the edit table.
        /// </summary>
        private Vehicle editModeSelectedVehicle;

        /// <summary>
        /// The vehicle that is currently selected in the main table.
        /// </summary>
        private Vehicle mainTableSelectedVehicle;

        /// <summary>
        /// Create a new vehicles class. The default.
        /// </summary>
        public Vehicles()
        {
            this.vehicleList = new List<Vehicle>();
        }

        /// <summary>
        /// Get the list of vehicles. Mainly implemented for debugging purposes.
        /// </summary>
        /// <returns>The list of vehicles.</returns>
        public List<Vehicle> GetVehicleList()
        {
            return this.vehicleList;
        }

        /// <summary>
        /// Add a vehicle to the list of currently available vehicles.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        public void AddVehicle(Vehicle vehicle)
        {
            vehicleList.Add(vehicle);
        }

        /// <summary>
        /// Remove a vehicle from the list of currently available vehicles.
        /// </summary>
        /// <param name="vehicle">The vehicle to remove.</param>
        private void RemoveVehicle(Vehicle vehicle)
        {
            vehicleList.Remove(vehicle);
        }

        /// <summary>
        /// Get a vehicle by a position.
        /// </summary>
        /// <param name="place">The place of the vehicle to get.</param>
        /// <returns>The vehicle at that position (or null if there is no vehicle).</returns>
        private Vehicle GetVehicle(int place)
        {
            try
            {
                lock (vehicleList)
                {
                    return vehicleList[place];
                }
            }catch(IndexOutOfRangeException ioore)
            {

            }
            return null;
        }

        /// <summary>
        /// Select the vehicle that is currently present at position x. (Click on a table row in the UI)
        /// </summary>
        /// <param name="pos">The position of the vehicle to select.</param>
        public void SelectVehicleEditMode(int pos)
        {
            editModeSelectedVehicle = GetVehicle(pos);
        }

        /// <summary>
        /// Select the vehicle that is currently present at position x. (Click on a table row in the UI)
        /// </summary>
        /// <param name="pos">The position of the vehicle to select.</param>
        public void SelectVehicleMainTableMode(int pos)
        {
            mainTableSelectedVehicle = GetVehicle(pos);
        }

        /// <summary>
        /// Get the index of a Vehicle object.
        /// </summary>
        /// <param name="vehicle">The vehicle to get the index of.</param>
        /// <returns>The index of the vehicle (-1 if not found)</returns>
        public int GetIndexOfVehicle(Vehicle vehicle)
        {
            for(int i = 0; i < vehicleList.Count; i++)
            {
                if (vehicleList[i].Equals(vehicle))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Create a new vehicle. (Button new in the UI)
        /// </summary>
        /// <param name="name">The name of the new vehicle.</param>
        /// <param name="id">The id of the new vehicle.</param>
        /// <param name="price">The price of the new vehicle.</param>
        public void NewVehicle(string name, string id, string price)
        {
            Vehicle v = new Vehicle(name, id, price);
            AddVehicle(v);
            if (!CarConfigContext.convenience)
            {
                editModeSelectedVehicle = null;
            }
        }

        /// <summary>
        /// Change the currently selected vehicle. (Button change in the UI)
        /// </summary>
        /// <param name="name">The new name of the vehicle.</param>
        /// <param name="id">The new id of the vehicle.</param>
        /// <param name="price">The new price of the vehicle.</param>
        public void ChangeSelectedVehicle(string name, string id, string price)
        {
            if(editModeSelectedVehicle != null)
            {
                editModeSelectedVehicle.SetName(name);
                editModeSelectedVehicle.SetId(id);
                editModeSelectedVehicle.SetPriceByPriceString(price);
                if (!CarConfigContext.convenience)
                {
                    editModeSelectedVehicle = null;
                }
            }
        }

        /// <summary>
        /// Delete the selected vehicle. (Button delete in the UI)
        /// </summary>
        public void DeleteSelectedVehicle()
        {
            if(editModeSelectedVehicle != null)
            {
                RemoveVehicle(editModeSelectedVehicle);
                if (!CarConfigContext.convenience)
                {
                    editModeSelectedVehicle = null;
                    mainTableSelectedVehicle = null;
                }
                else
                {
                    try
                    {
                        if(editModeSelectedVehicle == mainTableSelectedVehicle)
                        {
                            mainTableSelectedVehicle = null;
                        }
                        editModeSelectedVehicle = vehicleList[0];
                    }catch(IndexOutOfRangeException ioore)
                    {
                        editModeSelectedVehicle = null;
                    }
                }
            }
        }

        /// <summary>
        /// Get the name of the currently selected vehicle.
        /// </summary>
        /// <returns>The name of the currently selected vehicle.</returns>
        public string GetNameOfSelectedVehicle()
        {
            if(mainTableSelectedVehicle != null)
            {
                return mainTableSelectedVehicle.GetName();
            }
            return "";
        }

        /// <summary>
        /// Get the id of the currently selected vehicle.
        /// </summary>
        /// <returns>The id of the currently selected vehicle.</returns>
        public string GetIdOfSelectedVehicle()
        {
            if(mainTableSelectedVehicle != null)
            {
                return mainTableSelectedVehicle.GetId();
            }
            return "";
        }

        /// <summary>
        /// Get the price of the currently selected vehicle. This is used in order to calculate
        /// and/or show the final price.
        /// </summary>
        /// <returns>The price of the currently selected vehicle.</returns>
        public long GetPriceOfSelectedVehicle()
        {
            if(mainTableSelectedVehicle != null)
            {
                return mainTableSelectedVehicle.GetPrice();
            }
            return 0;
        }

        /// <summary>
        /// Get the refernce of the currently selected vehicle.
        /// </summary>
        /// <returns>The currently selected vehicle.</returns>
        public Vehicle GetSelectedVehicle()
        {
            if(mainTableSelectedVehicle != null)
            {
                return mainTableSelectedVehicle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the refernce of the currently selected vehicle in the edit mode.
        /// </summary>
        /// <returns>The currently selected vehicle in the edit mode.</returns>
        public Vehicle GetEditModeSelectedVehicle()
        {
            if(editModeSelectedVehicle != null)
            {
                return editModeSelectedVehicle;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Clone this collection of vehicles.
        /// </summary>
        /// <returns>A clone of this collections of vehicles.</returns>
        public Vehicles Clone()
        {
            Vehicles vs = new Vehicles();
            foreach(Vehicle v in vehicleList)
            {
                vs.AddVehicle(v.Clone());
            }
            vs.mainTableSelectedVehicle = this.mainTableSelectedVehicle;
            vs.editModeSelectedVehicle = this.editModeSelectedVehicle;
            return vs;
        }

        /// <summary>
        /// Return a textual representation of this object.
        /// </summary>
        /// <returns>A textuel representation of this object.</returns>
        public string ToString()
        {
            return "[Vehicles:\n"
                + this.vehicleList
                + "]";
        }

        /// <summary>
        /// Get the default vehicles.
        /// </summary>
        /// <returns>The default vehicles.</returns>
        public static Vehicles getDefaultVehicles()
        {
            Vehicles v = new Vehicles();
            String allVehicles = Language.GetString("vehicles");
            foreach(String s in allVehicles.Split(new string[] { "|" }, StringSplitOptions.None))
            {
                try
                {
                    v.AddVehicle(
                        new Vehicle(
                            Language.GetString("vehicles." + s + ".name"),
                            Language.GetString("vehicles." + s + ".id"),
                            Int32.Parse(Language.GetString("vehicles." + s + ".price"))
                        )
                    );
                }catch(InvalidPriceException ipe)
                {

                }
            }
            return v;
        }
    }
}
