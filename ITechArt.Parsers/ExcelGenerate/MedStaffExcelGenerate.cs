using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.RepositoryInterfaces;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class MedStaffExcelGenerate : IMedStaffExcelGenerate
    {
        private readonly IMedStaffRepository _medStaffRepository;
        private readonly IExcelGenerator _generateExcel;

        public MedStaffExcelGenerate(IMedStaffRepository medStaffRepository, IExcelGenerator generateExcel)
        {
            _medStaffRepository = medStaffRepository;
            _generateExcel = generateExcel;
        }


        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public async Task<byte[]> GetExcelAsync()
        {
            var entitesArray = await _medStaffRepository.GetAllAsync();
            return await _generateExcel.GetExcelAsync(entitesArray);
        }
    }
}
