using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IXmlGenerate
{
    public interface IPupilXmlGenerate
    {
        /// <summary>
        /// Generates new xml document of Pupils table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetPupilsXmlAsync();
    }
}
