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
