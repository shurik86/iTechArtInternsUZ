using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Airport : IAirport
    {
        /// <summary>
        /// Gets or internal sets Id of airport.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets or internal sets Airport Name.
        /// </summary>
        public string AirportName { get; internal set; }

        /// <summary>
        /// Gets or internal sets The built date of airport.
        /// </summary>
        //[JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateTime BuiltDate { get; internal set; }

        /// <summary>
        /// Gets or internal sets A number of people can be in at the same time at the airport.
        /// </summary>

        public int Capacity { get; internal set; }

        /// <summary>
        /// Gets or internal sets  Address location of the airport.
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Gets or internal sets City location of the airport.
        /// </summary>
        public string City { get; internal set; }

        /// <summary>
        /// Gets or internal sets A number of employees.
        /// </summary>

        public int EmployeesCount { get; internal set; }

        /// <summary>
        /// Gets or internal sets The number of passengers who fly from a particular airport.
        /// </summary>
        public long PassengersPerYear { get; internal set; }

        /// <summary>
        /// Gets or internal sets The number of flights from a particular airport in a year.
        /// </summary>
        public uint FlightsPerYear { get; internal set; }

        /// <summary>
        /// Gets or internal sets The average price of tickets.
        /// </summary>
        public int AverageTicketPrice { get; internal set; }
    }
}
