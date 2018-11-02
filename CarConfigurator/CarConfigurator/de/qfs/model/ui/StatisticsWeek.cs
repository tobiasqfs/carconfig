using System;
using System.Collections.Generic;
using System.Text;

namespace CarConfigurator.de.qfs.model.ui
{
    class StatisticsWeek
    {
        /// <summary>
        /// The week of this item.
        /// </summary>
        public string week { get; set; }

        /// <summary>
        /// The amount of ordered vehicles in this week.
        /// </summary>
        public string amount { get; set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="week">The week of this item.</param>
        /// <param name="amount">The amount of ordered vehicles in this week.</param>
        public StatisticsWeek(string week, string amount)
        {
            this.week = week;
            this.amount = amount;
        }
    }
}
