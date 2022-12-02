using iTechArt.Domain.FilterModels;

namespace iTechArt.Api.Models
{
    public class AirportFilter : IAirportFilter
    {
        /// <summary>
        /// Gets or sets Id of airport.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets airport name.
        /// </summary>
        public string AirportName { get; set; }

        /// <summary>
        /// Gets or sets the built date of airport.
        /// </summary>
        public int? BuiltDate { get; set; }

        /// <summary>
        /// Gets or sets a number of people can be in at the same time at the airport.
        /// </summary>

        public int? Capacity { get; set; }

        /// <summary>
        /// Gets or sets address location of the airport.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets city location of the airport.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets a number of employees.
        /// </summary>
        public int? EmployeesCount { get; set; }

        /// <summary>
        /// Gets or sets the number of passengers who fly from a particular airport.
        /// </summary>
        public long? PassengersPerYear { get; set; }

        /// <summary>
        /// Gets or sets the number of flights from a particular airport in a year.
        /// </summary>
        public uint? FlightsPerYear { get; set; }

        /// <summary>
        /// Gets or sets the average price of tickets.
        /// </summary>
        public int? AverageTicketPrice { get; set; }
    }
}
