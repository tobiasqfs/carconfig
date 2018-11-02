using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.exceptions;
using System;
using System.Collections.Generic;

namespace CarConfigurator.de.qfs.model
{
    class CarConfig
    {
        /// <summary>
        /// The stack of vehicles.
        /// </summary>
        private List<Vehicles> vehicles;

        /// <summary>
        /// The stack of specials.
        /// </summary>
        private List<Specials> specials;

        /// <summary>
        /// The stack of accessories.
        /// </summary>
        private List<Accessories> accessories;

        /// <summary>
        /// Whether to add the accessories price to the final price.
        /// </summary>
        private Boolean addAccessoriesPriceToFinalPrice = true;

        /// <summary>
        /// The amount of discount set.
        /// </summary>
        private float discount = 0;

        /// <summary>
        /// The max amount of ms to sleep when loadtesting is enabled.
        /// </summary>
        private int loadtestWaittime = 3000;

        /// <summary>
        /// The instance of this CarConfig.
        /// </summary>
        private static CarConfig instance;

        /// <summary>
        /// The current CarConfig.
        /// </summary>
        private CarConfig() { ActionFileReset(); }

        /// <summary>
        /// Get the list of vehicles.
        /// </summary>
        /// <returns>The list of vehicles.</returns>
        public List<Vehicles> GetVehicles()
        {
            return this.vehicles;
        }

        /// <summary>
        /// Get the list of specials.
        /// </summary>
        /// <returns>The list of specials.</returns>
        public List<Specials> GetSpecials()
        {
            return this.specials;
        }

        /// <summary>
        /// Get the list of accessories.
        /// </summary>
        /// <returns>The list of accessories.</returns>
        public List<Accessories> GetAccessories()
        {
            return this.accessories;
        }
        
        /// <summary>
        /// Get the current discount.
        /// </summary>
        /// <returns>The current discount.</returns>
        public float GetDiscount()
        {
            return this.discount;
        }

        /// <summary>
        /// Set the discount.
        /// </summary>
        /// <param name="d">The discount to set.</param>
        public void SetDiscount(float d)
        {
            if (!CarConfigContext.buggy)
            {
                if (d > 0.99f || d < 0.00f)
                {
                    this.discount = 0;
                    throw new InvalidDiscountException();
                }
                else
                {
                    this.discount = d;
                }
            }
            else
            {
                if(d < 0.00f)
                {
                    this.discount = 0;
                    throw new InvalidDiscountException();
                }
                this.discount = d;
            }
        }

        /// <summary>
        /// Get whether the accessories price should be added to the final price.
        /// </summary>
        /// <returns>whether the accessories price should be added to the final price.</returns>
        public Boolean GetAddAccessoriesPriceToFinalPrice()
        {
            return this.addAccessoriesPriceToFinalPrice;
        }

        /// <summary>
        /// Set whether the accessories price should be added to the final price.
        /// </summary>
        /// <param name="add">whether the accessories price should be added to the final price.</param>
        public void SetAddAccessoriesPriceToFinalPrice(Boolean add)
        {
            this.addAccessoriesPriceToFinalPrice = add;
        }

        /// <summary>
        /// Handle the file reset action.
        /// </summary>
        public void ActionFileReset()
        {
            vehicles = new List<Vehicles>();
            vehicles.Add(Vehicles.getDefaultVehicles());
            accessories = new List<Accessories>();
            accessories.Add(Accessories.GetDefaultAccessories());
            specials = new List<Specials>();
            specials.Add(Specials.GetDefaultSpecials(accessories[0]));
            specials[0].SelectSpecialMainTableMode(0);

            CarConfigContext.buggy = false;
            CarConfigContext.newVersion = false;
            CarConfigContext.loadTest = false;

            this.discount = 0.00f;
        }

        /// <summary>
        /// Updates the selected attribute for all accessories according to the selected special.
        /// </summary>
        public void UpdateAccessories()
        {
            foreach(Accessory a in accessories[0].GetAccessoryList())
            {
                a.SetSelected(false);
            }
            foreach(Accessory a in specials[0].GetSelectedSpecial().GetAccessories())
            {
                a.SetSelected(true);
            }
        }

        /// <summary>
        /// Get the end price.
        /// </summary>
        /// <returns>The end price.</returns>
        public float GetEndPrice()
        {
            float returnValue = 0.00f;
            if (CarConfigContext.buggy && vehicles[0].GetIndexOfVehicle(vehicles[0].GetSelectedVehicle()) == vehicles[0].GetVehicleList().Count - 1)
            {
                returnValue = 0.00f;
            }
            else
            {
                returnValue += vehicles[0].GetPriceOfSelectedVehicle() * (1.00f - discount);
            }
            returnValue += specials[0].GetPriceOfSelectedSpecial();
            if (addAccessoriesPriceToFinalPrice)
            {
                foreach (Accessory a in accessories[0].GetAccessories())
                {
                    if (CarConfigContext.buggy)
                    {
                        if (a.selected)
                        {
                            returnValue += a.GetPrice() * (1.00f - discount);
                        }
                    }
                    else
                    {
                        if (a.selected && !specials[0].GetSelectedSpecial().GetAccessories().Contains(a))
                        {
                            returnValue += a.GetPrice() * (1.00f - discount);
                        }
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Get the instance of this CarConfig.
        /// </summary>
        /// <returns>The instance of this CarConfig.</returns>
        public static CarConfig GetInstance()
        {
            if (instance == null)
            {
                lock (typeof(CarConfig))
                {
                    if (instance == null) { instance = new CarConfig(); }
                }
            }
            return instance;
        }

        /// <summary>
        /// sleep to immitate loadtesting
        /// </summary>
        public void SleepForLoadtesting()
        {
            if (CarConfigContext.loadTest)
            {
                Random r = new Random();
                int sleepTime = r.Next(loadtestWaittime);
                System.Threading.Thread.Sleep(sleepTime);
            }
        }
    }
}
