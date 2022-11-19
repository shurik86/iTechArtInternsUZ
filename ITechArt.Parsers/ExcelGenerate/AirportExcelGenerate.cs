using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class AirportExcelGenerate : IAirportExcelGenerate
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IExcelGenerator _generateExcel;

        public AirportExcelGenerate(IAirportRepository airportRepository, IExcelGenerator generateExcel)
        {
            _airportRepository = airportRepository;
            _generateExcel = generateExcel;
        }

        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetExcelAsync()
        {
            var entityArray = await _airportRepository.GetAllAsync();
            return await _generateExcel.GetExcelAsync<IAirport>(entityArray);
        }
    }
}
