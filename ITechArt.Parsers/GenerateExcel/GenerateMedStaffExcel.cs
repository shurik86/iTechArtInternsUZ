using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GenerateMedStaffExcel : IGenerateMedStaffExcel
    {
        private readonly IMedStaffRepository _medStaffRepository;
        private readonly IGenerateExcel _generateExcel;

        public GenerateMedStaffExcel(IMedStaffRepository medStaffRepository, IGenerateExcel generateExcel)
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
