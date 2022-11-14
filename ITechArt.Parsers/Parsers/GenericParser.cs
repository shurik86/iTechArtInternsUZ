using CsvHelper.Configuration;
using CsvHelper;
using iTechArt.Domain.ParserInterfaces;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Xml.Serialization;
using Ganss.Excel;

namespace ITechArt.Parsers.Parsers
{
    public sealed class GenericParser : IGenericParser
    {
        /// <summary>
        /// Parse TSource file from csv.
        /// </summary>
        public async Task<TSourse[]> CsvParseAsync<TMap, TSourse>(IFormFile file)
            where TMap : ClassMap 
            where TSourse : class
        {
            await using var fileStream = new MemoryStream();

            await file.CopyToAsync(fileStream);
            fileStream.Position = 0;

            using TextReader csvReader = new StreamReader(fileStream);
            using var csv = new CsvReader(csvReader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<TMap>();
            var records = csv.GetRecords<TSourse>();

            return records.ToArray();
        }

        /// <summary>
        /// Parse pupil's file from excel.
        /// </summary>
        public async Task<TSourse[]> ExcelParseAsync<TSourse>(IFormFile file) 
            where TSourse : class
        {
            await using var stream = new MemoryStream();

            await file.CopyToAsync(stream);

            stream.Position = 0;

            var excelMapper = new ExcelMapper(stream);

            return excelMapper.Fetch<TSourse>().ToArray();
        }

        /// <summary>
        /// Parse TSource file from xml.
        /// </summary>
        public async Task<TSource> XmlParseAsync<TSource>(IFormFile file) 
            where TSource : class
        {
            await using var stream = new MemoryStream();

            await file.CopyToAsync(stream);

            stream.Position = 0;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TSource));
            using TextReader reader = new StreamReader(stream);

            return (TSource)xmlSerializer.Deserialize(reader);
        }
    }
}
