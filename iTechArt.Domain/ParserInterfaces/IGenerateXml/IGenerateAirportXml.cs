using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IGenerateXml
{
    public interface IGenerateAirportXml
    {
        /// <summary>
        /// Generates new xml document of Airport table from Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetAirportXmlAsync();
    }
}
