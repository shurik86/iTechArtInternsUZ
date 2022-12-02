using iTechArt.Database.Entities.Pupils;
using iTechArt.Database.Entities.Students;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class PupilDBSorter : BaseDBSorter<PupilDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
        protected override Dictionary<string, Expression<Func<PupilDb, object>>> TableFieldSorters { get; } = new() {
            { "firstName", f => f.FirstName },
            { "lastName", l => l.LastName },
            { "dateOfBirth", d => d.DateOfBirth },
            { "gender", g => g.Gender },
            { "phoneNumber", p => p.PhoneNumber},
            { "address", a => a.Address },
            { "city", c => c.City },
            { "schoolName", s => s.SchoolName },
            { "grade", g => g.Grade },
            { "courseLanguage", c => c.CourseLanguage },
            { "shift", s => s.Shift }
        };

        /// <summary>
        /// Gets default field sorter.
        /// </summary>
        protected override Expression<Func<PupilDb, object>> DefaultFieldSorter => TableFieldSorters["firstName"];
    }
}
