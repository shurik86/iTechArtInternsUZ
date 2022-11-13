using iTechArt.Database.DbContexts;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ITechArt.Parsers.GenerateXml
{
    public sealed class GenerateAirportXml : IGenerateAirportXml
    {
        private readonly IAirportRepository _airportRepository;

        public GenerateAirportXml(IAirportRepository airportRepository)
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
                XmlElement record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlElement AirportName = xmlDocument.CreateElement(null, AirportConstants.AirportName, null);
                XmlElement BuiltDate = xmlDocument.CreateElement(null, AirportConstants.BuiltDate, null);
                XmlElement Capacity = xmlDocument.CreateElement(null, AirportConstants.Capacity, null);
                XmlElement Address = xmlDocument.CreateElement(null, AirportConstants.Address, null);
                XmlElement City = xmlDocument.CreateElement(null, AirportConstants.City, null);
                XmlElement EmployeesCount = xmlDocument.CreateElement(null, AirportConstants.EmpoyeesCount, null);
                XmlElement PassengersPerYear = xmlDocument.CreateElement(null, AirportConstants.PassengersPerYear, null);
                XmlElement FlightsPerYear = xmlDocument.CreateElement(null, AirportConstants.FlightsPerYear, null);
                XmlElement AverageTicketPrice = xmlDocument.CreateElement(null, AirportConstants.AverageTicketPrice, null);

                XmlText AirportNameText = xmlDocument.CreateTextNode(airport.AirportName);
                XmlText BuiltDateText = xmlDocument.CreateTextNode(airport.BuiltDate.ToString());
                XmlText CapacityText = xmlDocument.CreateTextNode(airport.Capacity.ToString());
                XmlText AddressText = xmlDocument.CreateTextNode(airport.Address);
                XmlText CityText = xmlDocument.CreateTextNode(airport.City);
                XmlText EmployeesCountText = xmlDocument.CreateTextNode(airport.EmployeesCount.ToString());
                XmlText PassengersPerYearText = xmlDocument.CreateTextNode(airport.PassengersPerYear.ToString());
                XmlText FlightsPerYearText = xmlDocument.CreateTextNode(airport.FlightsPerYear.ToString());
                XmlText AverageTicketPriceText = xmlDocument.CreateTextNode(airport.AverageTicketPrice.ToString());

                AirportName.AppendChild(AirportNameText);
                BuiltDate.AppendChild(BuiltDateText);
                Capacity.AppendChild(CapacityText);
                Address.AppendChild(AddressText);
                City.AppendChild(CityText);
                EmployeesCount.AppendChild(EmployeesCountText);
                PassengersPerYear.AppendChild(PassengersPerYearText);
                FlightsPerYear.AppendChild(FlightsPerYearText);
                AverageTicketPrice.AppendChild(AverageTicketPriceText);

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
