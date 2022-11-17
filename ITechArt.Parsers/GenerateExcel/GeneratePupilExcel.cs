using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GeneratePupilExcel : IGeneratePupilExcel
    {
        private readonly IPupilRepository _pupilRepository;
        private readonly IGenerateExcel _generateExcel;

        public GeneratePupilExcel(IPupilRepository pupilRepository, IGenerateExcel generateExcel)
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
