using AutoMapper;
using iTechArt.Domain.GenerateExcelInterfaces;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GenerateAirportExcel : IGenerateAirportExcel
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IGenerateExcel _generateExcel;

        public GenerateAirportExcel(IAirportRepository airportRepository, IGenerateExcel generateExcel)
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
