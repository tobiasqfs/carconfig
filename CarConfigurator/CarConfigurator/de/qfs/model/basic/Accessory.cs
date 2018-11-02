using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;

namespace CarConfigurator.de.qfs.model.basic
{
    class Accessory
    {
        /// <summary>
        /// The name of the accessory
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// The id of the accessory
        /// </summary>
        public string id { get; private set; }

        /// <summary>
        /// Whether this accessory is currently selected
        /// </summary>
        public Boolean selected { get; private set; }

        /// <summary>
        /// The price of the accessory in cents
        /// </summary>
        public long price { get; private set; }

        /// <summary>
        /// The price of this accessory as string and already formated.
        /// </summary>
        public string priceString { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">the name of the accessory</param>
        /// <param name="id">the id of the accessory</param>
        /// <param name="price">the price of the accessory in cents</param>
        public Accessory(string name, string id, long price)
        {
            SetName(name);
            SetId(id);
            SetPrice(price);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">the name of the accessory</param>
        /// <param name="id">the id of the accessory</param>
        /// <param name="price">the price of the accessory</param>
        public Accessory(string name, string id, string price)
        {
            SetName(name);
            SetId(id);
            SetPriceByPriceString(price);
        }

        /// <summary>
        /// Get the name of the accessory
        /// </summary>
        /// <returns>the name</returns>
        public string GetName() { return this.name; }

        /// <summary>
        /// Set the name of the accessory
        /// </summary>
        /// <param name="name">the new name</param>
        public void SetName(string name) { this.name = name; }

        /// <summary>
        /// Get the id of the accessory
        /// </summary>
        /// <returns>the id</returns>
        public string GetId() { return this.id; }

        /// <summary>
        /// Set the id of the accessory
        /// </summary>
        /// <param name="id">the new id</param>
        public void SetId(string id) { this.id = id; }

        /// <summary>
        /// Get the price of the accessory in cents
        /// </summary>
        /// <returns>the price in cents</returns>
        public long GetPrice() { return this.price; }

        /// <summary>
        /// Get the price of this accessory as a string.
        /// </summary>
        /// <returns>The price of this accessory as a string.</returns>
        public string GetPriceString()
        {
            return this.priceString;
        }

        /// <summary>
        /// Set the price of the accessory in cents
        /// </summary>
        /// <param name="price">the new price in cents</param>
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
        /// Set the price of this accessory by a string.
        /// </summary>
        /// <param name="price">The new price of this accessory.</param>
        public void SetPriceByPriceString(string price)
        {
            this.SetPrice(Language.ParsePrice(price));
        }

        /// <summary>
        /// Sets the bool value whether this accessory is selected.s
        /// </summary>
        /// <param name="select">true for select, false for deselect</param>
        public void SetSelected(bool select)
        {
            this.selected = select;
        }

        /// <summary>
        /// Returns a clone of this object
        /// </summary>
        /// <returns>a clone of this object</returns>
        public Accessory Clone()
        {
            Accessory clone = new Accessory(this.name, this.id, this.price);
            return clone;
        }

        /// <summary>
        /// Returns a textual representation of this accessory object. Mainly implemented for debugging purposes
        /// </summary>
        /// <returns>A textual representation of this accessory object</returns>
        public string ToString()
        {
            return "Accessory[name=" + this.name
                + "; id=" + this.id
                + "; price=" + this.price
                + "; selected=" + this.selected
                + "]";
        }
    }
}
