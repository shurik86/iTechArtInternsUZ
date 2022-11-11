using CsvHelper;
using CsvHelper.Configuration;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.SpreadSheet;
using iTechArt.Database.Entities.Airports;
using iTechArt.Database.Entities.Police;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Repository.Repositories;
using iTechArt.Service.Constants;
using iTechArt.Service.DTOs;
using iTechArt.Service.Helpers;
using ITechArt.Parsers.Constants;
using ITechArt.Parsers.Dtos;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Xml;

namespace iTechArt.Service.Parsers
{
    public sealed class AirportParser : IAirportParsers
    {
        private readonly IAirportRepository _airportRepository;
        public AirportParser(IAirportRepository airportRepository)
        {
            _airportRepository= airportRepository;
        }

        /// <summary>
        /// csv airport parser
        /// </summary>
        public async Task CsvParserAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (fileExtension == FileExtensions.csv)
            {
                using var fileStream = new MemoryStream();

                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;

                using (TextReader csvReader = new StreamReader(fileStream))
                {
                    using (var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<AirportMap>();
                        var records = csv.GetRecords<AirportDTO>().ToArray();

                        await _airportRepository.AddRangeAsync(records);
                    }
                }
            }
        }   
        public async Task ExcelParserAsync(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);

            if (!FileConstants.excelExtensions.Contains(fileExtension))
            {
                throw new Exception("Upload correct File!!!");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0;

                IList<AirportDTO> airports;

                if (fileExtension == FileExtensions.xlsx)
                {
                    airports = ParseXlsx(stream);
                }
                else if (fileExtension == FileExtensions.xls)
                {
                    airports = ParseXls(stream);
                }
                else
                {
                    throw new Exception("This Excel format is not supported yet.");
                }

                await _airportRepository.AddRangeAsync(airports);
            }
        }

        private IList<AirportDTO> ParseXlsx(MemoryStream stream)
        {

            using (var package = new ExcelPackage(stream))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                IList<AirportDTO> airports = new List<AirportDTO>(rowCount - 2);

                for (int r = 2; r <= rowCount; r++)
                {
                    var airport = new AirportDTO
                    {
                        AirportName = worksheet.Cells[r, 1 + AirportIndexConstants.AIRPORTNAMEINDEX].Value.ToString().Trim(),
                        BuiltDate = DateOnly.Parse(worksheet.Cells[r, 1 + AirportIndexConstants.BUILDDATEINDEX].Value.ToString()),
                        Capacity = Convert.ToUInt16(worksheet.Cells[r, 1 + AirportIndexConstants.CAPACITYINDEX].Value),
                        Address = worksheet.Cells[r, 1 + AirportIndexConstants.ADDRESSINDEX].Value.ToString().Trim(),
                        City = worksheet.Cells[r, 1 + AirportIndexConstants.CITYINDEX].Value.ToString().Trim(),
                        EmployeesCount = Convert.ToUInt16(worksheet.Cells[r, 1 + AirportIndexConstants.EMPLOYEESCOUNTINDEX].Value),
                        PassengersPerYear = Convert.ToInt64(worksheet.Cells[r, 1 + AirportIndexConstants.PASSANGERPERYEARINDEX].Value),
                        FlightsPerYear = Convert.ToUInt32(worksheet.Cells[r, 1 + AirportIndexConstants.FLIGHTSPERYEARINDEX].Value),
                        AverageTicketPrice = Convert.ToUInt16(worksheet.Cells[r, 1 + AirportIndexConstants.AVERAGETICKETPRICEINDEX].Value)
                    };

                    airports.Add(airport);
                }

                return airports;
            }
        }
        private IList<AirportDTO> ParseXls(MemoryStream stream)
        {
            var workBook = Workbook.Load(stream);
            var workSheet = workBook.Worksheets[0];
            var cells = workSheet.Cells;
            var rowCount = cells.Rows.Count;

            IList<AirportDTO> airports = new List<AirportDTO>(rowCount - 2);

            for (int i = Nums.One; i < rowCount; i++)
            {
                var airportDto = new AirportDTO
                {
                    AirportName = cells[i, AirportIndexConstants.AIRPORTNAMEINDEX].Value.ToString().Trim(),
                    BuiltDate = DateOnly.Parse(cells[i, AirportIndexConstants.BUILDDATEINDEX].Value.ToString()),
                    Capacity = Convert.ToUInt16(cells[i, AirportIndexConstants.CAPACITYINDEX].Value),
                    Address = cells[i, AirportIndexConstants.ADDRESSINDEX].Value.ToString().Trim(),
                    City = cells[i, AirportIndexConstants.CITYINDEX].Value.ToString().Trim(),
                    EmployeesCount = Convert.ToUInt16(cells[i, AirportIndexConstants.EMPLOYEESCOUNTINDEX].Value),
                    PassengersPerYear = Convert.ToInt64(cells[i, AirportIndexConstants.PASSANGERPERYEARINDEX].Value),
                    FlightsPerYear = Convert.ToUInt32(cells[i, AirportIndexConstants.FLIGHTSPERYEARINDEX].Value),
                    AverageTicketPrice = Convert.ToUInt16(cells[i, AirportIndexConstants.AVERAGETICKETPRICEINDEX].Value),
                };
            }

            return airports;
        }

        public async Task XmlParserAsync(IFormFile file)
        {
             var fileExtension = Path.GetExtension(file.FileName);

             if (FileConstants.xmlExtensions.Contains(fileExtension))
             {
                using var fileStream = new MemoryStream();
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                var nodes = xmlDocument.SelectNodes("/airports/airport");

                    IList<AirportDTO> airports = new List<AirportDTO>(nodes.Count);

                    for (int node = 0; node < nodes.Count; node++)
                    {
                        AirportDTO airport = new AirportDTO
                        {
                            AirportName = nodes[node]["AirportName"].InnerText,
                            BuiltDate = DateOnly.Parse(nodes[node]["BuiltDate"].InnerText),
                            Capacity = Convert.ToUInt16(nodes[node]["Capacity"].InnerText),
                            Address = nodes[node]["Address"].InnerText,
                            City = nodes[node]["City"].InnerText,
                            EmployeesCount = Convert.ToUInt16(nodes[node]["EmployeesCount"].InnerText),
                            PassengersPerYear = Convert.ToInt64(nodes[node]["PassengersPerYear"].InnerText),
                            FlightsPerYear = Convert.ToUInt32(nodes[node]["FlightsPerYear"].InnerText),
                            AverageTicketPrice = Convert.ToUInt16(nodes[node]["AverageTicketPrice"].InnerText),
                        };
                        airports.Add(airport);
                    }
                    await _airportRepository.AddRangeAsync(airports);
                }
                else
                {
                    throw new ArgumentException("Invalid file format");
                }
            }         
    }

    public sealed class AirportMap : ClassMap<AirportDTO>
    {
        public AirportMap()
        {
            Map(a => a.AirportName).Name("AirportName");
            Map(a => a.BuiltDate).Name("BuiltDate");
            Map(a => a.Capacity).Name("Capacity");
            Map(a => a.Address).Name("Address");
            Map(a => a.City).Name("City");
            Map(a => a.EmployeesCount).Name("EmployeesCount");
            Map(a => a.PassengersPerYear).Name("PassengersPerYear");
            Map(a => a.FlightsPerYear).Name("FlightsPerYear");
            Map(a => a.AverageTicketPrice).Name("AverageTicketPrice");
        }
    }
}
