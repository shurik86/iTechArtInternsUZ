using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IXmlGenerate
{
    public interface IGroceryXmlGenerate
    {
        /// <summary>
        /// Generates new xml document of Grocery table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetGroceryXmlAsync();
    }
}
