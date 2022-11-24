using CsvHelper.Configuration;
using ITechArt.Parsers.Constants;

namespace ITechArt.Parsers.Dtos.Polices
{
    public sealed class PoliceMap : ClassMap<PoliceDto>
    {
        public PoliceMap()
        {
            Map(c => c.Name).Name(PoliceConstants.NAME);
            Map(c => c.Surname).Name(PoliceConstants.SURNAME);
            Map(c => c.Email).Name(PoliceConstants.EMAIL);
            Map(c => c.Gender).Name(PoliceConstants.GENDER);
            Map(c => c.Address).Name(PoliceConstants.ADDRESS);
            Map(c => c.JobTitle).Name(PoliceConstants.JOBTITLE);
            Map(c => c.Salary).Name(PoliceConstants.SALARY);
            Map(c => c.BirthDate).Name(PoliceConstants.BIRTHDATE);
        }
    }
}
