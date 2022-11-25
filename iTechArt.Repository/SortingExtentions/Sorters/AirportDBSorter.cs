using iTechArt.Database.Entities.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class AirportDBSorter : BaseDBSorter<AirportDb>
    {
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
