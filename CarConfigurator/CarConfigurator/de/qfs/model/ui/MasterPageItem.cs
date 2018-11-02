using System;

namespace CarConfigurator.de.qfs.model.ui
{
    class MasterPageItem
    {
        /// <summary>
        /// The title of the MasterPage item.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The target type of the MasterPage item.
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// the default constructor.
        /// </summary>
        /// <param name="Title">The title of the MasterPage item.</param>
        /// <param name="TargetType">The target type of the MasterPage item.</param>
        public MasterPageItem(string Title, Type TargetType)
        {
            this.Title = Title;
            this.TargetType = TargetType;
        }
    }
}
