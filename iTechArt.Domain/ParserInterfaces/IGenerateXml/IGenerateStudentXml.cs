using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace iTechArt.Domain.ParserInterfaces.IGenerateXml
{
    public interface IGenerateStudentXml
    {
        /// <summary>
        /// Generates new xml document of Student table in Database.
        /// </summary>
        /// <returns>Xml Document</returns>
        public Task<XmlDocument> GetStudentsXmlAsync();
    }
}
