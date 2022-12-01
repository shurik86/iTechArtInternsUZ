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
            { "firstname", f => f.FirstName },
            { "lastname", l => l.LastName },
            { "gender", g => g.Gender},
            { "email", e => e.Email },
            { "phonenumber", p => p.PhoneNumber },
            { "dateofbirth", d => d.DateOfBirth },
            { "address", a => a.Address },
            { "salary", s => s.Salary },
            { "hospitalname", h => h.HospitalName },
            { "postalcode", p => p.PostalCode },
            { "shist", s => s.Shift }
        };

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<MedStaffDb, object>> DefaultFieldSorter => TableFieldSorters["firstname"];
    }
}
