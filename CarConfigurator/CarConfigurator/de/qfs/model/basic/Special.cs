using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigurator.de.qfs.model.basic
{
    class Special
    {
        /// <summary>
        /// The name of this special
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// The description of the special.
        /// </summary>
        public string description { get; private set; }

        /// <summary>
        /// The price of this special in cents.
        /// </summary>
        public long price { get; private set; }

        /// <summary>
        /// The price of this special as string and already formated.
        /// </summary>
        public string priceString { get; private set; }

        /// <summary>
        /// The list of accessories that are connected to this special.
        /// </summary>
        private List<Accessory> accessories;

        /// <summary>
        /// Construct this special by its name, description, price and the list of connected accessories
        /// </summary>
        /// <param name="name">The name of this special.</param>
        /// <param name="description">The description of this special.</param>
        /// <param name="price">The price of this special.</param>
        /// <param name="accessories">The list of accessories of this special.</param>
        public Special(string name, string description, long price, List<Accessory> accessories)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetAccessories(accessories);
        }

        /// <summary>
        /// Construct this special by its naame, description, price and the list of connected accessories.
        /// </summary>
        /// <param name="name">The name of this special.</param>
        /// <param name="description">The description of this special.</param>
        /// <param name="price">The price of this special.</param>
        /// <param name="accessories">The list of accessories of this special.</param>
        public Special(string name, string description, string price, List<Accessory> accessories)
        {
            SetName(name);
            SetDescription(description);
            SetPriceByPriceString(price);
            SetAccessories(accessories);
        }

        /// <summary>
        /// Get the name of this special.
        /// </summary>
        /// <returns>The name of this special.</returns>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Set the name of this special.
        /// </summary>
        /// <param name="name">The new name of this special.</param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Get the description of this special.
        /// </summary>
        /// <returns>The description of this special.</returns>
        public string GetDescription()
        {
            return description;
        }

        /// <summary>
        /// Get the list of accessories included in this special.
        /// </summary>
        /// <returns>The list of accessories included in this special.</returns>
        public List<Accessory> GetAccessories()
        {
            return this.accessories;
        }

        /// <summary>
        /// Set a new description of this special.
        /// </summary>
        /// <param name="description">The new description of this special.</param>
        public void SetDescription(string description)
        {
            this.description = description;
        }

        /// <summary>
        /// Get the price of this special.
        /// </summary>
        /// <returns>The price of this special.</returns>
        public long GetPrice()
        {
            return price;
        }

        /// <summary>
        /// Get the price of this special as a string.
        /// </summary>
        /// <returns>The price of this special as a string.</returns>
        public string GetPriceString()
        {
            return this.priceString;
        }

        /// <summary>
        /// Set the price of this special.
        /// </summary>
        /// <param name="price">The new price of this special.</param>
        public void SetPrice(long price)
        {
            if(price < 0)
            {
                throw new InvalidPriceException();
            }
            this.price = price;
            this.priceString = Language.FormatPrice(price);
        }

        /// <summary>
        /// Set the price of this special by string.
        /// </summary>
        /// <param name="price">The new price of this special as string.</param>
        public void SetPriceByPriceString(string price)
        {
            SetPrice(Language.ParsePrice(price));
        }

        /// <summary>
        /// Set the list of accessories.
        /// </summary>
        /// <param name="accessories">The new list of accessories to set.</param>
        public void SetAccessories(List<Accessory> accessories)
        {
            if(accessories == null)
            {
                accessories = new List<Accessory>();
            }
            this.accessories = new List<Accessory>();
            foreach(Accessory a in accessories)
            {
                if(a != null)
                {
                    AddAccessory(a);
                }
            }
        }

        /// <summary>
        /// Add an accessory to this special.
        /// </summary>
        /// <param name="accessory">The accessory to add to this special.</param>
        public void AddAccessory(Accessory accessory)
        {
            if (!IncludesAccessory(accessory))
            {
                this.accessories.Add(accessory);
            }
        }

        /// <summary>
        /// Check whether this special contains a certain accessory.
        /// </summary>
        /// <param name="accessory">The accessory to check.</param>
        /// <returns>True, when this special includes a certain accessory, otherwise false.</returns>
        public Boolean IncludesAccessory(Accessory accessory)
        {
            return this.accessories.Contains(accessory);
        }

        /// <summary>
        /// Remove an (maybe present) accessory from the list of accessories.
        /// If the accessory is not present in this special, nothing is done.
        /// </summary>
        /// <param name="accessory">The accessory to remove.</param>
        public void RemoveAccessory(Accessory accessory)
        {
            this.accessories.Remove(accessory);
        }

        /// <summary>
        /// If an accessory is present in this special, remove it. By contrast if the special does
        /// not contain this accessory, add it.
        /// </summary>
        /// <param name="accessory">The accessory to toggle.</param>
        public void ToggleAccessory(Accessory accessory)
        {
            if (IncludesAccessory(accessory))
            {
                RemoveAccessory(accessory);
            }
            else
            {
                AddAccessory(accessory);
            }
        }

        /// <summary>
        /// Clone this special.
        /// </summary>
        /// <returns>A cloned version of this special.</returns>
        public Special Clone()
        {
            try
            {
                return new Special(this.name, this.description, this.price, this.accessories);
            }catch(InvalidPriceException ipe)
            {
                try
                {
                    Special s = new Special(this.name, this.description, 100000000, this.accessories);
                    return s;
                }catch(InvalidPriceException ipe2)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Return a string version of this special. Mainly used for debug purpose.
        /// </summary>
        /// <returns>A string version of this special.</returns>
        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Special:[");
            sb.Append("name=");
            sb.Append(name);
            sb.Append("; price=");
            sb.Append(price);
            sb.Append("; description=");
            sb.Append(description);
            sb.Append("; accessories=");
            sb.Append(accessories);
            sb.Append("]");
            return sb.ToString();
        }
    }
}
