using iTechArt.Database.Entities.Airports;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class AirportDBSorter : BaseDBSorter<AirportDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary
        protected override Dictionary<string, Expression<Func<AirportDb, object>>> TableFieldSorters { get; } = new() {
            { "airportname", a => a.AirportName },
            { "capacity", c => c.Capacity },
            { "address", a => a.Address },
            { "city", c => c.City },
            { "empoloyeescount", e => e.EmpoyeesCount },
            { "passengersperyear", p => p.PassengersPerYear },
            { "flightperyear", f => f.FlightsPerYear },
            { "averageticketprice", a => a.AverageTicketPrice }
        };
    }
}
