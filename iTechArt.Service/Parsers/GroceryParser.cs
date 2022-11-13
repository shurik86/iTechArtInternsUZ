using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml.Linq;

namespace iTechArt.Service.Parsers
{
    public sealed class GroceryParser : IGroceryParser
    {
        private const string DATETIMEFORMAT = "MM/dd/yyyy";
        private const string INVALID_DOUBLE_MESSAGE = "Could not conver string to double: ";
        private const string INVALID_DATETIME_MESSAGE = "Could not convert string to DateTime: ";
        private const string INVALID_ENUM_MESSAGE = "Could not convert string to Enum: ";

        private static IList<IGrocery> _grocery;
        private readonly IGroceryRepository _groceryRepository;
        /// <summary>
        /// Checking the coming input for parsing from string to double and returning the result if its parsed
        /// </summary>
        private static double DoubleGuard(string input)
        {
            double doubleOutput;
            var result = double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out doubleOutput);
            if (result)
                return doubleOutput;
            throw new InvalidDataException($"{INVALID_DOUBLE_MESSAGE}{input}");
        }
        /// <summary>
        /// Checking the coming input for parsing from string to DateTime and returning the result if its parsed
        /// </summary>
        private static DateTime DateTimeGuard(string input)
        {
            DateTime datetimeOutput;
            var result = DateTime.TryParseExact(input, DATETIMEFORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out datetimeOutput);
            if (result)
                return datetimeOutput;
            throw new InvalidDataException($"{INVALID_DATETIME_MESSAGE}{input}");
        }
        /// <summary>
        /// Checking the coming input for parsing from string to Enum and returning the result if its parsed
        /// </summary>
        private static Gender EnumGuard(string input)
        {
            Gender genderOutput;
            var result = Enum.TryParse<Gender>(input, out genderOutput);
            if (result)
                return genderOutput;
            throw new InvalidDataException($"{INVALID_ENUM_MESSAGE}{input}");
        }
        public GroceryParser(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }
        /// <summary>
        /// Parsing Csv format grocery files.
        /// </summary>
        public async Task<IGrocery[]> ParseCsvAsync(IFormFile formFile)
        {
            using var fileStream = new MemoryStream();

            await formFile.CopyToAsync(fileStream);
            fileStream.Position = 0;

            using TextReader csvReader = new StreamReader(fileStream);
            using var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<GroceryMap>();
            var records = csv.GetRecords<GroceryDTO>();

            return records.ToArray();
        }
        /// <summary>
        /// Parsing Excel format grocery files.
        /// </summary>
        public async Task<IGrocery[]> ExcelParseAsync(IFormFile formFile)
        {
            
            _grocery = new List<IGrocery>();
            if (formFile.Length > 0)
            {
                var s = formFile.OpenReadStream();
                try
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    using (var p = new ExcelPackage(s))
                    {
                        var sheet = p.Workbook.Worksheets.First();
                        var count = sheet.Dimension.Rows;
                        
                        for (int index = 2; index < count; index++)
                        {
                            var groceryDTO = new GroceryDTO
                            {
                                FirstName = sheet.GetValue<string>(index,GroceryIndexConstants.FIRSTNAMEINDEX),
                                LastName = sheet.GetValue<string>(index, GroceryIndexConstants.LASTNAMEINDEX),
                                Email = sheet.GetValue<string>(index, GroceryIndexConstants.EMAILINDEX),
                                Gender = Enum.Parse<Gender>(sheet.GetValue<string>(index, GroceryIndexConstants.GENDERINDEX)),
                                Birthday = DateTimeGuard(sheet.GetValue<string>(index,GroceryIndexConstants.BIRTHDAYINDEX)),
                                JobTitle = sheet.GetValue<string>(index, GroceryIndexConstants.GENDERINDEX),
                                DepartmentRetail = sheet.GetValue<string>(index, GroceryIndexConstants.DEPARTMENTRETAILINDEX),
                                Salary = DoubleGuard(sheet.GetValue<string>(index, GroceryIndexConstants.SALARYINDEX))
                            };
                            _grocery.Add(groceryDTO);
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex; 
                }
            }
            return _grocery.ToArray();
        }
        /// <summary>
        /// Parsing XML format grocery files.
        /// </summary>
        public async Task<IGrocery[]> XmlParseAsync(IFormFile formFile)
        {
            _grocery = new List<IGrocery>();
            XDocument xm = new XDocument();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
            var xdoc = XDocument.Load(reader);
             await reader.ReadToEndAsync();
                var items = from item in xdoc.Descendants("dataset").Elements("record")
                            select new GroceryDTO()
                            {
                                FirstName = item.Element(GroceryIndexConstants.FIRSTNAME).Value,
                                LastName = item.Element(GroceryIndexConstants.LASTNAME).Value,
                                Email = item.Element(GroceryIndexConstants.EMAIL).Value,
                                Gender = Enum.Parse<Gender>(item.Element(GroceryIndexConstants.GENDER).Value),
                                Birthday = (DateTime)item.Element(GroceryIndexConstants.BIRTHDAY),
                                JobTitle = item.Element(GroceryIndexConstants.JOBTITLE).Value,
                                DepartmentRetail = item.Element(GroceryIndexConstants.DEPARTMENTRETAIL).Value,
                                Salary = (double)item.Element(GroceryIndexConstants.SALARY)
                            };
                return items.ToArray();
            }
        }
    }
    /// <summary>
    /// Mapping item for Csv helper.
    /// </summary>
    public sealed class GroceryMap : ClassMap<GroceryDTO>
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
