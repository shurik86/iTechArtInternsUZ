using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Xml.Serialization;
using Ganss.Excel;
using iTechArt.Domain.Enums;
using ITechArt.Parsers.Dtos.Pupils;
using IParser = iTechArt.Domain.ParserInterfaces.IParser;
using ITechArt.Parsers.Dtos.Students;
using ITechArt.Parsers.Dtos.Groceries;

namespace ITechArt.Parsers.Parsers
{
    public sealed class Parser : IParser
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

            ConfigurationMappingExcel(excelMapper);

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

        private static void ConfigurationMappingExcel(ExcelMapper mapper)
        {
            //Configuration mapping of pupil
            mapper.AddMapping<PupilDto>("Gender", p => p.Gender)
                .SetPropertyUsing(v =>
                {
                    return Enum.Parse<Gender>(v.ToString());
                });

            mapper.AddMapping<PupilDto>("CourseLanguage", p => p.CourseLanguage)
                .SetPropertyUsing(v =>
                {
                    return Enum.Parse<CourseLanguage>(v.ToString());
                });

            mapper.AddMapping<PupilDto>("Shift", p => p.Shift)
                .SetPropertyUsing(v =>
                {
                    return Enum.Parse<Shift>(v.ToString());
                });
            
            // Configuration mapping of student.
            mapper.AddMapping<StudentDto>("Gender", s => s.Gender)
                .SetPropertyUsing(s =>
                {
                    return Enum.Parse<Gender>(s.ToString());
                });

            // Configuration mapping of grocery.
            mapper.AddMapping<GroceryDto>("Gender", g => g.Gender)
                .SetPropertyUsing(g =>
                {
                    return Enum.Parse<Gender>(g.ToString());
                });
        }
    }
}
