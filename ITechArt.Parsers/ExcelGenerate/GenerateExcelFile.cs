using iTechArt.Domain.IExcelGenerate;
using OfficeOpenXml;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class GenerateExcelFile : IExcelGenerator
    {
        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetExcelAsync<T>(T[] arrayOfEntities)
            where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                Console.WriteLine(typeof(T));
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(modelBind[typeof(T).ToString()]);
                var range = worksheet.Cells["A1"].LoadFromCollection(arrayOfEntities, true);
                await package.SaveAsync();
                using (var memoryStream = new MemoryStream())
                {
                    package.SaveAs(memoryStream);
                    await memoryStream.FlushAsync();
                    return memoryStream.ToArray();
                }
            }
        }

        private readonly Dictionary<string, string> modelBind = new Dictionary<string, string>()
        {
            {"iTechArt.Domain.ModelInterfaces.IAirport", "Airport" }, 
            {"iTechArt.Domain.ModelInterfaces.IGrocery", "Grocery"}, 
            {"iTechArt.Domain.ModelInterfaces.IMedStaff", "MedStaff"}, 
            {"iTechArt.Domain.ModelInterfaces.IPolice", "Police"}, 
            {"iTechArt.Domain.ModelInterfaces.IPupil", "Pupil"}, 
            {"iTechArt.Domain.ModelInterfaces.IStudent", "Student"}
        };
    }
}
