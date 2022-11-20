using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using ITechArt.Parsers.Constants;
using ITechArt.Parsers.Dtos;
using Microsoft.AspNetCore.Http;
using System.Xml;

namespace ITechArt.Parsers.PoliceParsers
{
    public class ParseXml : IXmlParse
    {
        /// <summary>
        /// Parse XML file and returns array of entities.
        /// </summary>
        public async Task<IPolice[]> ParseXMLAsync(IFormFile file)
        {
            List<IPolice> polices = new List<IPolice>();
            await using (var fileStream = new MemoryStream())
            {
                await file.CopyToAsync(fileStream);
                fileStream.Position = 0;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileStream);

                foreach (XmlNode node in xmlDocument.SelectNodes("/dataset/record"))
                {
                    PoliceDto policeDto = new PoliceDto
                    {
                        Name = node[PoliceConstants.Name].InnerText,
                        Surname = node[PoliceConstants.Surname].InnerText,
                        Email = node[PoliceConstants.Email].InnerText,
                        Gender = Enum.Parse<Gender>(node[PoliceConstants.Gender].InnerText),
                        Address = node[PoliceConstants.Address].InnerText,
                        JobTitle = node[PoliceConstants.JobTitle].InnerText,
                        Salary = Convert.ToDouble(node[PoliceConstants.Salary].InnerText),
                        BirthDate = Convert.ToDateTime(node[PoliceConstants.Birthdate].InnerText)
                    };
                    polices.Add(policeDto);
                }
                return polices.ToArray();
            }
        }
    }
}
