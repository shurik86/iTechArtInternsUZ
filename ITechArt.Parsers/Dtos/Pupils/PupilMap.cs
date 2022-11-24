using CsvHelper.Configuration;

namespace ITechArt.Parsers.Dtos.Pupils
{
    public sealed class PupilMap : ClassMap<PupilDto>
    {
        public PupilMap()
        {
            Map(p => p.FirstName).Name("FirstName");
            Map(p => p.LastName).Name("LastName");
            Map(p => p.DateOfBirth).Name("DateOfBirth");
            Map(p => p.Gender).Name("Gender");
            Map(p => p.PhoneNumber).Name("PhoneNumber");
            Map(p => p.Address).Name("Address");
            Map(p => p.City).Name("City");
            Map(p => p.SchoolName).Name("SchoolName");
            Map(p => p.Grade).Name("Grade");
            Map(p => p.CourseLanguage).Name("CourseLanguage");
            Map(p => p.Shift).Name("Shift");
        }
    }
}
