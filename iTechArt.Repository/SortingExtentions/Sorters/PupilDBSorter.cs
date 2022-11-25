using iTechArt.Database.Entities.Pupils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class PupilDBSorter : BaseDBSorter<PupilDb>
    {
        protected override Dictionary<string, Expression<Func<PupilDb, object>>> TableFieldSorters { get; } = new() {
            { "firtstname", f => f.FirstName },
            { "lastname", l => l.LastName },
            { "dateofbirth", d => d.DateOfBirth },
            { "gender", g => g.Gender },
            { "phonenumber", p => p.PhoneNumber},
            { "address", a => a.Address },
            { "city", c => c.City },
            { "schoolname", s => s.SchoolName },
            { "grade", g => g.Grade },
            { "courselanguage", c => c.CourseLanguage },
            { "shift", s => s.Shift }
        };
    }
}
