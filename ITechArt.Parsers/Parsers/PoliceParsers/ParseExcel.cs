using ExcelLibrary.SpreadSheet;
using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using ITechArt.Parsers.Constants;
using ITechArt.Parsers.Dtos;
using ITechArt.Parsers.Dtos.Polices;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;


namespace ITechArt.Parsers.PoliceParsers
{
    public class ParseExcel : IExcelParse
    {
        /// <summary>
        /// Parse XLSX or XLS file and returns array of entities.
        /// </summary>
        public async Task<IPolice[]> ParseExcelAsync(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            var polices = new List<IPolice>();
            await using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;

                if (fileExtension == FileExtensions.xlsx)
                {
                    using (var package = new ExcelPackage(fileStream))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = Nums.RowTwo; row <= rowCount; row++)
                        {
                            var policeDto = new PoliceDto
                            {
                                Name = worksheet.GetValue<string>(row, Nums.ColumnOne).Trim(),
                                Surname = worksheet.GetValue<string>(row, Nums.ColumnTwo).Trim(),
                                Email = worksheet.GetValue<string>(row, Nums.ColumnThree).Trim(),
                                Gender = Enum.Parse<Gender>(worksheet.GetValue<string>(row, Nums.ColumnFour)),
                                Address = worksheet.GetValue<string>(row, Nums.ColumnFive).Trim(),
                                JobTitle = worksheet.GetValue<string>(row, Nums.ColumnSix).Trim(),
                                Salary = Convert.ToDouble(worksheet.Cells[row, Nums.ColumnSeven].Value),
                                BirthDate = Convert.ToDateTime(worksheet.Cells[row, Nums.ColumnEight].Value),
                            };
                            polices.Add(policeDto);
                        }
                    }
                }
                // for type XLS.
                else
                {
                    var workBook = Workbook.Load(fileStream);
                    var workSheet = workBook.Worksheets[0];
                    var cells = workSheet.Cells;
                    var rowCount = cells.Rows.Count;
                    
                    for(int rowIndex = Nums.RowOne; rowIndex < rowCount; rowIndex++)
                    {
                        var policeDto = new PoliceDto
                        {
                            Name = cells[rowIndex, Nums.ColumnZero].Value.ToString().Trim(),
                            Surname = cells[rowIndex, Nums.ColumnOne].Value.ToString().Trim(),
                            Email = cells[rowIndex, Nums.ColumnTwo].Value.ToString().Trim(),
                            Gender = Enum.Parse<Gender>(cells[rowIndex, Nums.ColumnThree].Value.ToString()),
                            Address = cells[rowIndex, Nums.ColumnFour].Value.ToString().Trim(),
                            JobTitle = cells[rowIndex, Nums.ColumnFive].Value.ToString().Trim(),
                            Salary = Convert.ToDouble(cells[rowIndex, Nums.ColumnSix].Value),
                            BirthDate = Convert.ToDateTime(cells[rowIndex, Nums.ColumnSeven].Value)
                        };
                        polices.Add(policeDto);
                    }
                }
            }
            return polices.ToArray();
        }
    }
}
