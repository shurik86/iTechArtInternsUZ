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
            var xmlDocument = new XmlDocument();
            var declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            var polices = xmlDocument.CreateElement(null, XmlConstants.polices, null);

            var policeArray = await _policeRepository.GetAllAsync();
            foreach (var police in policeArray)
            {
                var policeElement = xmlDocument.CreateElement(null, XmlConstants.record, null);
                
                var Name = xmlDocument.CreateAttribute(null, PoliceConstants.Name, null);
                var Surname = xmlDocument.CreateAttribute(null, PoliceConstants.Surname, null);
                var Email = xmlDocument.CreateAttribute(null, PoliceConstants.Email, null);
                var Gender = xmlDocument.CreateAttribute(null, PoliceConstants.Gender, null);
                var Address = xmlDocument.CreateAttribute(null, PoliceConstants.Address, null);
                var JobTitle = xmlDocument.CreateAttribute(null, PoliceConstants.JobTitle, null);
                var Salary = xmlDocument.CreateAttribute(null, PoliceConstants.Salary, null);
                var BirthDate = xmlDocument.CreateAttribute(null, PoliceConstants.Birthdate, null);

                Name.Value = police.Name;
                Surname.Value = police.Surname;
                Email.Value = police.Email;
                Gender.Value = police.Gender.ToString();
                Address.Value = police.Address;
                JobTitle.Value = police.JobTitle;
                Salary.Value = police.Salary.ToString();
                BirthDate.Value = police.BirthDate.ToString();

                policeElement.Attributes.Append(Name);
                policeElement.Attributes.Append(Surname);
                policeElement.Attributes.Append(Email);
                policeElement.Attributes.Append(Gender);
                policeElement.Attributes.Append(Address);
                policeElement.Attributes.Append(JobTitle);
                policeElement.Attributes.Append(Salary);
                policeElement.Attributes.Append(BirthDate);

                polices.AppendChild(policeElement);
            }
            xmlDocument.AppendChild(polices);

            return xmlDocument;
        }
    }
}
