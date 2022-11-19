using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml;


namespace ITechArt.Parsers.XmlGenerate
{
    public sealed class AirportXmlGenerate : IAirportXmlGenerate
    {
        private readonly IAirportRepository _airportRepository;

        public AirportXmlGenerate(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }



        /// <summary>
        /// Generates a new XML file of type Airport table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetAirportXmlAsync()
        {
            var xmlDocument = new XmlDocument();
            var declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            var airports = xmlDocument.CreateElement(null, XmlConstants.airports, null);

            var airportArray = await _airportRepository.GetAllAsync();
            foreach (var airport in airportArray)
            {
                var airportElement = xmlDocument.CreateElement(null, XmlConstants.airport, null);
                
                var AirportName = xmlDocument.CreateAttribute(null, AirportConstants.AirportName, null);
                var BuiltDate = xmlDocument.CreateAttribute(null, AirportConstants.BuiltDate, null);
                var Capacity = xmlDocument.CreateAttribute(null, AirportConstants.Capacity, null);
                var Address = xmlDocument.CreateAttribute(null, AirportConstants.Address, null);
                var City = xmlDocument.CreateAttribute(null, AirportConstants.City, null);
                var EmployeesCount = xmlDocument.CreateAttribute(null, AirportConstants.EmpoyeesCount, null);
                var PassengersPerYear = xmlDocument.CreateAttribute(null, AirportConstants.PassengersPerYear, null);
                var FlightsPerYear = xmlDocument.CreateAttribute(null, AirportConstants.FlightsPerYear, null);
                var AverageTicketPrice = xmlDocument.CreateAttribute(null, AirportConstants.AverageTicketPrice, null);

                AirportName.Value = airport.AirportName;
                BuiltDate.Value = airport.BuiltDate.ToString();
                Capacity.Value = airport.Capacity.ToString();
                Address.Value = airport.Address.ToString();
                City.Value = airport.City.ToString();
                EmployeesCount.Value = airport.EmployeesCount.ToString();
                PassengersPerYear.Value = airport.PassengersPerYear.ToString();
                FlightsPerYear.Value = airport.FlightsPerYear.ToString();
                AverageTicketPrice.Value = airport.AverageTicketPrice.ToString();

                airportElement.Attributes.Append(AirportName);
                airportElement.Attributes.Append(BuiltDate);
                airportElement.Attributes.Append(Capacity);
                airportElement.Attributes.Append(Address);
                airportElement.Attributes.Append(City);
                airportElement.Attributes.Append(EmployeesCount);
                airportElement.Attributes.Append(PassengersPerYear);
                airportElement.Attributes.Append(FlightsPerYear);
                airportElement.Attributes.Append(AverageTicketPrice);

                airports.AppendChild(airportElement);
            }
            xmlDocument.AppendChild(airports);

            return xmlDocument;
        }
    }
}
