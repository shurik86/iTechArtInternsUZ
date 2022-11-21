using CsvHelper.Configuration;

namespace ITechArt.Parsers.Dtos.Airports
{
    public sealed class AirportMap : ClassMap<AirportDTO>
    {
        public AirportMap()
        {
            Map(a => a.AirportName).Name("AirportName");
            Map(a => a.BuiltDate).Name("BuiltDate");
            Map(a => a.Capacity).Name("Capacity");
            Map(a => a.Address).Name("Address");
            Map(a => a.City).Name("City");
            Map(a => a.EmployeesCount).Name("EmployeesCount");
            Map(a => a.PassengersPerYear).Name("PassengersPerYear");
            Map(a => a.FlightsPerYear).Name("FlightsPerYear");
            Map(a => a.AverageTicketPrice).Name("AverageTicketPrice");
        }
    }
}
