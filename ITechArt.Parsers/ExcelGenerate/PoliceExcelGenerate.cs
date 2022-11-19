using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.RepositoryInterfaces;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class PoliceExcelGenerate : IPoliceExcelGenerate
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly IExcelGenerator _generateExcel;

        public PoliceExcelGenerate(IPoliceRepository policeRepository, IExcelGenerator generateExcel)
        {
            _policeRepository = policeRepository;
            _generateExcel = generateExcel;
        }

        public async Task<byte[]> GetExcelAsync()
        {
            var entitiesArray = await _policeRepository.GetAllAsync();
            return await _generateExcel.GetExcelAsync(entitiesArray);
        }
    }
}
