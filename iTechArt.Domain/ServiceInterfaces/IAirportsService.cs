﻿using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IAirportsService
    {
        /// <summary>
        /// Interface of Importing airport datas.
        /// </summary>
        public Task ImportAirportFileAsync(IFormFile file);

        
        /// <summary>
        /// Parse airport's file from excel.
        /// </summary>      
        public Task AirportExcelParseAsync(IFormFile file);


        /// <summary>
        /// Parse airport's file from csv.
        /// </summary>
        public Task AirportCSVParseAsync(IFormFile file);


        ///// <summary>
        ///// Exporting airport datas
        ///// </summary>
        //public Task<IAirport[]> ExportAirportExcel();

        /// <summary>
        /// Parse airport's file from xml.
        /// </summary>
        public Task AirportXMLParseAsync(IFormFile file);
        /// <summary>
    }
}
