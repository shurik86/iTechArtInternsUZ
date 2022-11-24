using iTechArt.Domain.ModelInterfaces;
using ITechArt.Parsers.Constants;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ITechArt.Parsers.Dtos.Airports
{
    public sealed class AirportDTO : IAirport
    {
        /// <summary>
        /// Gets or internal sets Id of airport.
        /// </summary>
        [XmlIgnore]
        public long Id { get; }

        /// <summary>
        /// Gets or internal sets Airport Name.
        /// </summary>
        [MaxLength(32)]
        [XmlElement(ElementName = AirportConstants.AIRPORTNAME)]
        public string AirportName { get; set; }

        /// <summary>
        /// Gets or internal sets The built date of airport.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.BUILTDATE)]
        public DateTime BuiltDate { get; set; }

        /// <summary>
        /// Gets or internal sets A number of people can be in at the same time at the airport.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.CAPACITY)]
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or internal sets Address location of the airport.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = AirportConstants.ADDRESS)]
        public string Address { get; set; }

        /// <summary>
        /// Gets or internal sets City location of the airport.
        /// </summary>
        [MaxLength(64)]
        [XmlElement(ElementName = AirportConstants.CITY)]
        public string City { get; set; }

        /// <summary>
        /// Gets or internal sets A number of employees.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.EMPLOYEESCOUNT)]
        public int EmployeesCount { get; set; }

        /// <summary>
        /// Gets or internal sets The number of passengers who fly from a particular airport.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.PASSERNGERSPERYEAR)]
        public long PassengersPerYear { get; set; }

        /// <summary>
        /// Gets or internal sets The number of flights from a particular airport in a year.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.FLIGHTSPERYEAR)]
        public uint FlightsPerYear { get; set; }

        /// <summary>
        /// Gets or internal sets The average price of tickets.
        /// </summary>
        [XmlElement(ElementName = AirportConstants.AVERAGETICKETPRICE)]
        public int AverageTicketPrice { get; set; }
    }
}
