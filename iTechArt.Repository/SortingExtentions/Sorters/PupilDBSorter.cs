using iTechArt.Database.Entities.Pupils;
using System.Linq.Expressions;

namespace iTechArt.Repository.SortingExtentions.Sorters
{
    public sealed class PupilDBSorter : BaseDBSorter<PupilDb>
    {
        /// <summary>
        /// Gets tablesorter.
        /// </summary>
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
