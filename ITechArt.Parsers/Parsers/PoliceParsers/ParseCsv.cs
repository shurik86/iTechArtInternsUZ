using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using ITechArt.Parsers.Constants;
using ITechArt.Parsers.Dtos.Polices;
using Microsoft.AspNetCore.Http;


namespace ITechArt.Parsers.PoliceParsers
{
    public class ParseCsv : ICsvParse
    {
        /// <summary>
        /// Parse CSV file and returns array of entities.
        /// </summary>
        public async Task<IPolice[]> ParseCSVAsync(IFormFile file)
        {
            await using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                using (var sr = new StreamReader(fileStream))
                {
                    using (var csv = new CsvReader(sr, System.Globalization.CultureInfo.InvariantCulture))

                    {
                        csv.Context.RegisterClassMap<PoliceMap>();
                        var records = csv.GetRecords<PoliceDto>().ToArray();
                        return records;
                    }
                }
            }
        }
    }

    /// <summary>
    /// class for mapping police model for CSVReader.
    /// </summary>
    internal sealed class PoliceMap : ClassMap<PoliceDto>
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
