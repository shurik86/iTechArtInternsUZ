using iTechArt.Database.Entities.MedicalStaff;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class MedStaffDBSorter : BaseDBSorter<MedStaffDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected override Dictionary<string, Expression<Func<MedStaffDb, object>>> TableFieldSorters { get; } = new()
        {
            { "firstName", f => f.FirstName },
            { "lastName", l => l.LastName },
            { "gender", g => g.Gender},
            { "email", e => e.Email },
            { "phoneNumber", p => p.PhoneNumber },
            { "dateOfBirth", d => d.DateOfBirth },
            { "address", a => a.Address },
            { "salary", s => s.Salary },
            { "hospitalName", h => h.HospitalName },
            { "postalCode", p => p.PostalCode },
            { "shift", s => s.Shift }
        };

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<MedStaffDb, object>> DefaultFieldSorter => TableFieldSorters["firstName"];
    }
}
