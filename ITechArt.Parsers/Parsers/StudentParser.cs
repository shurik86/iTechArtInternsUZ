using CsvHelper;
using CsvHelper.Configuration;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using ITechArt.Parsers.Dtos;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.Xml;

namespace ITechArt.Parsers.Parsers
{
    public sealed class StudentParser : IStudentParser
    {
        /// <summary>
        /// Parse student's file from csv.
        /// </summary>
        public async Task<IStudent[]> CsvParseAsync(IFormFile file)
        {
            using var fileStream = new MemoryStream();

            await file.CopyToAsync(fileStream);
            fileStream.Position = 0;
            using TextReader csvReader = new StreamReader(fileStream);
            using var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<StudentMap>();
            var records = csv.GetRecords<StudentDto>();

            return records.ToArray();
        }

        /// <summary>
        /// Parse student's file from excel.
        /// </summary>
        public async Task<IStudent[]> ExcelParseAsync(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var package = new ExcelPackage(stream);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;
            IList<StudentDto> students = new List<StudentDto>(rowCount - 1);

            for (int row = 2; row <= rowCount; row++)
            {
                StudentDto student = new()
                {
                    FirstName = worksheet.GetValue<string>(row, 1).Trim(),
                    LastName = worksheet.GetValue<string>(row, 2).Trim(),
                    Email = worksheet.GetValue<string>(row, 3).Trim(),
                    Password = worksheet.GetValue<string>(row, 4).Trim(),
                    Majority = worksheet.GetValue<string>(row, 5).Trim(),
                    Gender = Enum.Parse<Gender>(worksheet.GetValue<string>(row, 6).Trim()),
                    DateOfBirth = DateOnly.Parse(worksheet.GetValue<string>(row, 7).Trim()),
                    University = worksheet.GetValue<string>(row, 8).Trim()
                };
                students.Add(student);
            }
            return students.ToArray();
        }

        /// <summary>
        /// Parse student's file from xml.
        /// </summary>
        public async Task<IStudent[]> XmlParseAsync(IFormFile file)
        {
            using var fileStream = new MemoryStream();

            await file.CopyToAsync(fileStream);

            fileStream.Position = 0;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileStream);

            var nodes = xmlDocument.SelectNodes("/students/student");

            IList<StudentDto> students = new List<StudentDto>(nodes.Count);

            for (int node = 0; node < nodes.Count; node++)
            {
                StudentDto student = new()
                {
                    FirstName = nodes[node]["FirstName"].InnerText,
                    LastName = nodes[node]["LastName"].InnerText,
                    Email = nodes[node]["Email"].InnerText,
                    Password = nodes[node]["Password"].InnerText,
                    Majority = nodes[node]["Majority"].InnerText,
                    Gender = Enum.Parse<Gender>(nodes[node]["Gender"].InnerText),
                    DateOfBirth = DateOnly.Parse(nodes[node]["DateOfBirth"].InnerText),
                    University = nodes[node]["University"].InnerText
                };
                students.Add(student);
            }
            return students.ToArray();
        }
    }

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
        }
    }
}
