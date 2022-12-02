using iTechArt.Domain.ServiceInterfaces;
using System.Xml;

namespace iTechArt.Service.Services
{
    public sealed class StreamToArray : IStreamToArray
    {
        /// <summary>
        /// Converts MemoryStream of XML Document to Array of Bytes.
        /// </summary>
        public async Task<byte[]> XmlStreamToArrayAsync(XmlDocument xmlDocument)
        {
            using (var memoryStream = new MemoryStream())
            {
                xmlDocument.Save(memoryStream);
                await memoryStream.FlushAsync();
                return memoryStream.ToArray();
            }
        }
    }
}
