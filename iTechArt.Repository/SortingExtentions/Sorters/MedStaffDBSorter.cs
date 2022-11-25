using iTechArt.Database.Entities.MedicalStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class MedStaffDBSorter : BaseDBSorter<MedStaffDb>
    {
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
       
    }
}
