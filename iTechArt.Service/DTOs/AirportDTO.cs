using iTechArt.Domain.Helpers;
using iTechArt.Domain.ModelInterfaces;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace iTechArt.Service.DTOs
{
    public sealed class AirportDTO : IAirport
    {

        /// <summary>
        /// Gets or internal sets Id of airport.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets or internal sets Airport Name.
        /// </summary>
        [MaxLength(32)]
        public string AirportName { get; set; }

        /// <summary>
        /// Gets or internal sets The built date of airport.
        /// </summary>
        
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly BuiltDate { get; set; }

        /// <summary>
        /// Gets or internal sets A number of people can be in at the same time at the airport.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or internal sets Address location of the airport.
        /// </summary>
        [MaxLength(64)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or internal sets City location of the airport.
        /// </summary>
        [MaxLength(64)]
        public string City { get; set; }

        /// <summary>
        /// Gets or internal sets A number of employees.
        /// </summary>
        public int EmployeesCount { get; set; }

        /// <summary>
        /// Gets or internal sets The number of passengers who fly from a particular airport.
        /// </summary>
        public long PassengersPerYear { get; set; }

        /// <summary>
        /// Gets or internal sets The number of flights from a particular airport in a year.
        /// </summary>
        public uint FlightsPerYear { get; set; }

        /// <summary>
        /// Gets or internal sets The average price of tickets.
        /// </summary>
        public int AverageTicketPrice { get; set; }
    }
}
