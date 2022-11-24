using CsvHelper.Configuration;

namespace ITechArt.Parsers.Dtos.Students
{
    public sealed class StudentMap : ClassMap<StudentDto>
    {
        public StudentMap()
        {
            Map(s => s.FirstName).Name("FirstName");
            Map(s => s.LastName).Name("LastName");
            Map(s => s.Email).Name("Email");
            Map(s => s.Password).Name("Password");
            Map(s => s.Majority).Name("Majority");
            Map(s => s.Gender).Name("Gender");
            Map(s => s.DateOfBirth).Name("DateOfBirth");
            Map(s => s.University).Name("University");
            Map(s => s.Faculty).Name("Faculty");
        }
    }
}
