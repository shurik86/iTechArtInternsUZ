using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IXmlGenerate
{
    public interface IStudentXmlGenerate
    {
        /// <summary>
        /// Generates new xml document of Student table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetStudentsXmlAsync();
    }
}
