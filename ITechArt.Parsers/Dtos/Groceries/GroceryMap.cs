using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using ITechArt.Parsers.Helpers;

namespace ITechArt.Parsers.Dtos.Groceries
{
    public sealed class GroceryMap : ClassMap<GroceryDto>
    {
        public GroceryMap()
        {
            Map(p => p.FirstName).Name("first_name");
            Map(p => p.LastName).Name("last_name");
            Map(p => p.Email).Name("email");
            Map(p => p.Gender).Name("gender").TypeConverter<EnumConverterHelper<Gender>>(); ;
            Map(p => p.Birthday).Name("birthday");
            Map(p => p.JobTitle).Name("job_Title");
            Map(p => p.DepartmentRetail).Name("department_retail");
            Map(p => p.Salary).Name("salary");
        }
    }
}
