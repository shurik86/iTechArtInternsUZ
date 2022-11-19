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
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            XmlElement dataset = xmlDocument.CreateElement(null, XmlConstants.dataset, null);

            var airportArray = await _airportRepository.GetAllAsync();
            foreach (var airport in airportArray)
            {
                XmlNode record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlNode AirportName = xmlDocument.CreateElement(null, AirportConstants.AirportName, null);
                XmlNode BuiltDate = xmlDocument.CreateElement(null, AirportConstants.BuiltDate, null);
                XmlNode Capacity = xmlDocument.CreateElement(null, AirportConstants.Capacity, null);
                XmlNode Address = xmlDocument.CreateElement(null, AirportConstants.Address, null);
                XmlNode City = xmlDocument.CreateElement(null, AirportConstants.City, null);
                XmlNode EmployeesCount = xmlDocument.CreateElement(null, AirportConstants.EmpoyeesCount, null);
                XmlNode PassengersPerYear = xmlDocument.CreateElement(null, AirportConstants.PassengersPerYear, null);
                XmlNode FlightsPerYear = xmlDocument.CreateElement(null, AirportConstants.FlightsPerYear, null);
                XmlNode AverageTicketPrice = xmlDocument.CreateElement(null, AirportConstants.AverageTicketPrice, null);

                AirportName.AppendChild(xmlDocument.CreateTextNode(airport.AirportName));
                BuiltDate.AppendChild(xmlDocument.CreateTextNode(airport.BuiltDate.ToString()));
                Capacity.AppendChild(xmlDocument.CreateTextNode(airport.Capacity.ToString()));
                Address.AppendChild(xmlDocument.CreateTextNode(airport.Address));
                City.AppendChild(xmlDocument.CreateTextNode(airport.City));
                EmployeesCount.AppendChild(xmlDocument.CreateTextNode(airport.EmployeesCount.ToString()));
                PassengersPerYear.AppendChild(xmlDocument.CreateTextNode(airport.PassengersPerYear.ToString()));
                FlightsPerYear.AppendChild(xmlDocument.CreateTextNode(airport.FlightsPerYear.ToString()));
                AverageTicketPrice.AppendChild(xmlDocument.CreateTextNode(airport.AverageTicketPrice.ToString()));

                record.AppendChild(AirportName);
                record.AppendChild(BuiltDate);
                record.AppendChild(Capacity);
                record.AppendChild(Address);
                record.AppendChild(City);
                record.AppendChild(EmployeesCount);
                record.AppendChild(PassengersPerYear);
                record.AppendChild(FlightsPerYear);
                record.AppendChild(AverageTicketPrice);
                dataset.AppendChild(record);
            }
            xmlDocument.AppendChild(dataset);

            return xmlDocument;
        }
    }
}
