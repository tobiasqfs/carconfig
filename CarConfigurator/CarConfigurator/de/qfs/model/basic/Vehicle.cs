using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;

namespace CarConfigurator.de.qfs.model.basic
{
    class Vehicle
    {
        /// <summary>
        /// The name of the vehicle.
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// The id of the vehicle. The id is shown in the new version mode only.
        /// </summary>
        public string id { get; private set; }

        /// <summary>
        /// The price of this vehicle in cents.
        /// </summary>
        public long price { get; private set; }

        /// <summary>
        /// The price of this vehicle as string and already formated.
        /// </summary>
        public string priceString { get; private set; }

        /// <summary>
        /// Construct a new vehicle.
        /// </summary>
        /// <param name="name">The name of the vehicle.</param>
        /// <param name="id">The id of the vehicle.</param>
        /// <param name="price">The price of the vehicle in cents.</param>
        public Vehicle(string name, string id, long price)
        {
            SetName(name);
            SetId(id);
            SetPrice(price);
        }

        /// <summary>
        /// Construct a new vehicle.
        /// </summary>
        /// <param name="name">The name of the vehicle.</param>
        /// <param name="id">The id of the vehicle.</param>
        /// <param name="price">The price of the vehicle in cents.</param>
        public Vehicle(string name, string id, string price)
        {
            SetName(name);
            SetId(id);
            SetPriceByPriceString(price);
        }

        /// <summary>
        /// Get the name of this vehicle.
        /// </summary>
        /// <returns>The name of the vehicle.</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Set the name of this vehicle.
        /// </summary>
        /// <param name="name">The new name of this vehicle.</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Get the id of this vehicle.
        /// </summary>
        /// <returns>The id of this vehicle.</returns>
        public string GetId()
        {
            return this.id;
        }

        /// <summary>
        /// Set the id of this vehicle.
        /// </summary>
        /// <param name="id">The new id of this vehicle.</param>
        public void SetId(string id)
        {
            this.id = id;
        }

        /// <summary>
        /// Get the price of this vehicle.
        /// </summary>
        /// <returns>The price of this vehicle in cents.</returns>
        public long GetPrice()
        {
            return this.price;
        }

        /// <summary>
        /// Get the price of this vehicle as a string.
        /// </summary
        /// <returns>The price of this vehicle as a string.</returns>
        public string GetPriceString()
        {
            return this.priceString;
        }

        /// <summary>
        /// Set the price of this vehicle.
        /// </summary>
        /// <param name="price">The new price of this vehicle in cents.</param>
        public void SetPrice(long price)
        {
            if(price <= 0)
            {
                throw new InvalidPriceException();
            }
            this.price = price;
            this.priceString = Language.FormatPrice(price);
        }

        /// <summary>
        /// Set the price of this vehicle by a string.
        /// </summary>
        /// <param name="price">The new price of this vehicle as string.</param>
        public void SetPriceByPriceString(string price)
        {
            this.SetPrice(Language.ParsePrice(price));
        }

        /// <summary>
        /// Return a clone of this object.
        /// </summary>
        /// <returns>A clone of this object.</returns>
        public Vehicle Clone()
        {
            try
            {
                Vehicle v = new Vehicle(this.name, this.id, this.price);
                return v;
            }
            catch (InvalidPriceException ipe)
            {
                try
                {
                    Vehicle v = new Vehicle(this.name, this.id, 100000000);
                    return v;
                }
                catch (InvalidPriceException ipe2)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Return a textual representation of this vehicle.
        /// </summary>
        /// <returns>A textual representation of this vehicle.</returns>
        public String ToString()
        {
            return "Vehicle[name=" + this.name
                + "; id=" + this.id
                + "; price=" + this.price
                + "]";
        }
    }
}
