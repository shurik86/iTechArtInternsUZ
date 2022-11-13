using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IGenerateXml
{
    public interface IGeneratePoliceXml
    {
        /// <summary>
        /// Generates new xml document of Police table in Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetPoliceXmlAsync();
    }
}
