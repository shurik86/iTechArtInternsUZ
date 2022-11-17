using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GenerateStudentExcel : IGenerateStudentExcel
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGenerateExcel _generateExcel;

        public GenerateStudentExcel(IStudentRepository studentRepository, IGenerateExcel generateExcel)
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
