﻿using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;
using iTechArt.Domain.ModelInterfaces;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IMedStaffService
    {
        /// <summary>
        /// Uploads a file of data. 
        /// </summary>
        public Task ImportMedStaffFileAsync(IFormFile file);

        /// <summary>
        /// Uploads excel file of data.
        /// </summary>
        public Task ExcelParseAsync(IFormFile file);

        /// <summary>
        /// Uploads xml file of data.
        /// </summary>
        public Task XMLParseAsync(IFormFile file);

        /// <summary>
        /// Uploads csv file of data.
        /// </summary>
        public Task CSVParseAsync(IFormFile file);

        /// <summary>
        /// Gets all info from database.
        /// </summary>
        public Task<IMedStaff[]> ExportMedStaffFileAsync(int pageIndex, int pageSize, string fieldName, 
            SortDirection sortDirection, IMedStaffFilter medStaffFilter);

        /// <summary>
        /// Exports MedStaff Data to a new XML file.
        /// </summary>
        public Task<byte[]> ExportXmlAsync();

        /// <summary>
        /// Exports MedStaff Data to a new Excel file.
        /// </summary>
        public Task<byte[]> ExportExcelAsync();

        /// <summary>
        /// Exports Medstaff Data to a new Csv file.
        /// </summary>
        public Task<byte[]> ExportCsvAsync();
    }
}
