using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;

namespace iTechArt.Domain.ParserInterfaces
{
    public interface IParser
    {
        /// <summary>
        /// Parse TSource file from excel.
        /// </summary>
        public Task<TSourse[]> ExcelParseAsync<TSourse>(IFormFile file)
            where TSourse : class;

        /// <summary>
        /// Parse TSource file from csv.
        /// </summary>
        public Task<TSourse[]> CsvParseAsync<TMap, TSourse>(IFormFile file)
            where TMap : ClassMap 
            where TSourse : class;

        /// <summary>
        /// Parse TSource file from xml.
        /// </summary>
        public Task<TSource> XmlParseAsync<TSource>(IFormFile file)
            where TSource : class;
    }
}
