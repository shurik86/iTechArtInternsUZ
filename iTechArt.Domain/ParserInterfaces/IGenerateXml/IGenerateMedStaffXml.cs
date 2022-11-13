using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IGenerateXml
{
    public interface IGenerateMedStaffXml
    {
        /// <summary>
        /// Generates new xml document of MedStaff table in Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetMedStaffXmlAsync();
    }
}
