﻿using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Service.Models
{
    internal sealed class DashboardInfo : IDashboardInfo
    {
        /// <summary>
        /// Count of pupils
        /// </summary>
        public int PupilCount { get; set; }

        /// <summary>
        /// Count of students
        /// </summary>
        public int StudentCount { get; set; }

        /// <summary>
        /// Count of groceries
        /// </summary>
        public long GroceryCount { get; set; }

        /// <summary>
        /// Count of polices
        /// </summary>
        public int PoliceCount { get; set; }

        /// <summary>
        /// Count of doctors
        /// </summary>
        public int DoctorCount { get; set; }

        /// <summary>
        /// Count of airports
        /// </summary>
        public int AirportCount { get; set; }
    }
}
