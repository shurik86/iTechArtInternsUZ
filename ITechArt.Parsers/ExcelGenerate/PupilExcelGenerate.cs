using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.RepositoryInterfaces;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class PupilExcelGenerate : IPupilExcelGenerate
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IExcelGenerator _generateExcel;

        public PupilExcelGenerate(IPupilRepository pupilRepository, IExcelGenerator generateExcel)
        {
            _pupilRepository = pupilRepository;
            _generateExcel = generateExcel;
        }

        public async Task<byte[]> GetExcelAsync()
        {
            var entitiesArray = await _pupilRepository.GetAllAsync();
            return await _generateExcel.GetExcelAsync(entitiesArray);
        }
    }
}
