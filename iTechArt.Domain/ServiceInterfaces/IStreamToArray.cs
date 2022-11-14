using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IStreamToArray
    {
        /// <summary>
        /// Converts MemoryStream of XML Document to Array of Bytes.
        /// </summary>
        public Task<byte[]> XmlStreamToArrayAsync(XmlDocument xmlDocument);
    }
}
