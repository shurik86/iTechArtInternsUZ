using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IXmlGenerate
{
    public interface IMedStaffXmlGenerate
    {
        /// <summary>
        /// Generates new xml document of MedStaff table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetMedStaffXmlAsync();
    }
}
