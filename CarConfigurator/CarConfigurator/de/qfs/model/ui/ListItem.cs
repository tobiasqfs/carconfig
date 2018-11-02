using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigurator.de.qfs.model.ui
{
    public class ListItem
    {
        /// <summary>
        /// The title of the List item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The position of this List item in the list.
        /// </summary>
        public int position { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="Title">The title of the List item.</param>
        /// <param name="position">The position of the List item in the list.</param>
        public ListItem(string Title, int position)
        {
            this.Title = Title;
            this.position = position;
        }
    }
}
