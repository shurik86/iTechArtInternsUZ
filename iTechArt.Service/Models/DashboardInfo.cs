using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Service.Models
{
    internal sealed class DashboardInfo : IDashboardInfo
    {
        /// <summary>
        /// Get or sets count of pupils.
        /// </summary>
        public long PupilCount { get; set; }

        /// <summary>
        /// Get or sets count of students.
        /// </summary>
        public long StudentCount { get; set; }

        /// <summary>
        /// Get or sets count of groceries.
        /// </summary>
        public long GroceryCount { get; set; }

        /// <summary>
        /// Get or sets count of polices.
        /// </summary>
        public int PoliceCount { get; set; }

        /// <summary>
        /// Get or sets count of doctors.
        /// </summary>
        public int DoctorCount { get; set; }

        /// <summary>
        /// Get or sets count of airports.
        /// </summary>
        public int AirportCount { get; set; }
    }
}
