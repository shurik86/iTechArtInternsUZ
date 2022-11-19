using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml;


namespace ITechArt.Parsers.XmlGenerate
{
    public sealed class PoliceXmlGenerate : IPoliceXmlGenerate
    {
        private readonly IPoliceRepository _policeRepository;

        public PoliceXmlGenerate(IPoliceRepository policeRepository)
        {
            _policeRepository = policeRepository;
        }


        /// <summary>
        /// Generates a new XML file of type Police table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetPoliceXmlAsync()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            XmlElement dataset = xmlDocument.CreateElement(null, XmlConstants.dataset, null);

            var policeArray = await _policeRepository.GetAllAsync();
            foreach (var police in policeArray)
            {
                XmlNode record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlNode Name = xmlDocument.CreateElement(null, PoliceConstants.Name, null);
                XmlNode Surname = xmlDocument.CreateElement(null, PoliceConstants.Surname, null);
                XmlNode Email = xmlDocument.CreateElement(null, PoliceConstants.Email, null);
                XmlNode Gender = xmlDocument.CreateElement(null, PoliceConstants.Gender, null);
                XmlNode Address = xmlDocument.CreateElement(null, PoliceConstants.Address, null);
                XmlNode JobTitle = xmlDocument.CreateElement(null, PoliceConstants.JobTitle, null);
                XmlNode Salary = xmlDocument.CreateElement(null, PoliceConstants.Salary, null);

                Name.AppendChild(xmlDocument.CreateTextNode(police.Name));
                Surname.AppendChild(xmlDocument.CreateTextNode(police.Surname));
                Email.AppendChild(xmlDocument.CreateTextNode(police.Email));
                Gender.AppendChild(xmlDocument.CreateTextNode(police.Gender.ToString()));
                Address.AppendChild(xmlDocument.CreateTextNode(police.Address));
                JobTitle.AppendChild(xmlDocument.CreateTextNode(police.JobTitle));
                Salary.AppendChild(xmlDocument.CreateTextNode(police.Salary.ToString()));

                record.AppendChild(Name);
                record.AppendChild(Surname);
                record.AppendChild(Email);
                record.AppendChild(Gender);
                record.AppendChild(Address);
                record.AppendChild(JobTitle);
                record.AppendChild(Salary);
                dataset.AppendChild(record);
            }
            xmlDocument.AppendChild(dataset);

            return xmlDocument;
        }
    }
}
