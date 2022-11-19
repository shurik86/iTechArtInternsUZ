using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IXmlGenerate
{
    public interface IAirportXmlGenerate
    {
        /// <summary>
        /// Generates new xml document of Airport table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetAirportXmlAsync();
    }
}
