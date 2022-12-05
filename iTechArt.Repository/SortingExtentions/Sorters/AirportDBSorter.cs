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
            { "airportName", a => a.AirportName },
            { "capacity", c => c.Capacity },
            { "address", a => a.Address },
            { "city", c => c.City },
            { "empoloyeesCount", e => e.EmpoyeesCount },
            { "passengersPerYear", p => p.PassengersPerYear },
            { "flightPerYear", f => f.FlightsPerYear },
            { "averageTicketPrice", a => a.AverageTicketPrice }
        };

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<AirportDb, object>> DefaultFieldSorter => TableFieldSorters["airportName"];
    }
}
