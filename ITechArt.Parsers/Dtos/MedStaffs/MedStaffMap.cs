using CsvHelper.Configuration;
using ITechArt.Parsers.Constants;

namespace ITechArt.Parsers.Dtos.MedStaffs
{
    public sealed class MedStaffMap : ClassMap<MedStaffDto>
    {
        public MedStaffMap()
        {
            Map(m => m.FirstName).Name(MedStaffConstants.FIRSTNAME);
            Map(m => m.LastName).Name(MedStaffConstants.LASTNAME);
            Map(m => m.Gender).Name(MedStaffConstants.GENDER);
            Map(m => m.Email).Name(MedStaffConstants.EMAIL);
            Map(m => m.PhoneNumber).Name(MedStaffConstants.PHONENUMBER);
            Map(m => m.DateOfBirth).Name(MedStaffConstants.DATEOFBIRTH);
            Map(m => m.Address).Name(MedStaffConstants.ADDRESS);
            Map(m => m.Salary).Name(MedStaffConstants.SALARY);
            Map(m => m.HospitalName).Name(MedStaffConstants.HOSPITALNAME);
            Map(m => m.PostalCode).Name(MedStaffConstants.POSTALCODE);
            Map(m => m.Shift).Name(MedStaffConstants.SHIFT);
        }
    }
}
