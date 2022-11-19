using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.RepositoryInterfaces;


namespace ITechArt.Parsers.ExcelGenerate
{
    public sealed class StudentExcelGenerate : IStudentExcelGenerate
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IExcelGenerator _generateExcel;

        public StudentExcelGenerate(IStudentRepository studentRepository, IExcelGenerator generateExcel)
        {
            _studentRepository = studentRepository;
            _generateExcel = generateExcel;
        }

        public async Task<byte[]> GetExcelAsync()
        {
            var entities = await _studentRepository.GetAllAsync();
            return await _generateExcel.GetExcelAsync(entities);
        }
    }
}
