using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IXmlGenerate
{
    public interface IPoliceXmlGenerate
    {
        /// <summary>
        /// Generates new xml document of Police table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetPoliceXmlAsync();
    }
}
