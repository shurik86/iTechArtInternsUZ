using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GeneratePoliceExcel : IGeneratePoliceExcel
    {
        private readonly IPoliceRepository _policeRepository;
        private readonly IGenerateExcel _generateExcel;

        public GeneratePoliceExcel(IPoliceRepository policeRepository, IGenerateExcel generateExcel)
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
