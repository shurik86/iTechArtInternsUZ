using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ITechArt.Parsers.GenerateXml
{
    public sealed class GeneratePupilXml : IGeneratePupilXml
    {
        private readonly IPupilRepository _pupilRepository;

        public GeneratePupilXml(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }


        /// <summary>
        /// Generates a new XML file of type Pupils table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetPupilsXmlAsync()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            XmlElement dataset = xmlDocument.CreateElement(null, XmlConstants.dataset, null);

            var pupilsArray = await _pupilRepository.GetAllAsync();
            foreach (var pupil in pupilsArray)
            {
                XmlNode record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlNode FirstName = xmlDocument.CreateElement(null, PupilsConstants.FirstName, null);
                XmlNode LastName = xmlDocument.CreateElement(null, PupilsConstants.LastName, null);
                XmlNode DateOfBirth = xmlDocument.CreateElement(null, PupilsConstants.DateOfBirth, null);
                XmlNode Gender = xmlDocument.CreateElement(null, PupilsConstants.Gender, null);
                XmlNode PhoneNumber = xmlDocument.CreateElement(null, PupilsConstants.PhoneNumber, null);
                XmlNode Address = xmlDocument.CreateElement(null, PupilsConstants.Address, null);
                XmlNode City = xmlDocument.CreateElement(null, PupilsConstants.City, null);
                XmlNode SchoolName = xmlDocument.CreateElement(null, PupilsConstants.SchoolName, null);
                XmlNode Grade = xmlDocument.CreateElement(null, PupilsConstants.Grade, null);
                XmlNode CourseLanguage = xmlDocument.CreateElement(null, PupilsConstants.CourseLanguage, null);
                XmlNode Shift = xmlDocument.CreateElement(null, PupilsConstants.Shift, null);

                FirstName.AppendChild(xmlDocument.CreateTextNode(pupil.FirstName));
                LastName.AppendChild(xmlDocument.CreateTextNode(pupil.LastName));
                DateOfBirth.AppendChild(xmlDocument.CreateTextNode(pupil.DateOfBirth.ToString()));
                Gender.AppendChild(xmlDocument.CreateTextNode(pupil.Gender.ToString()));
                PhoneNumber.AppendChild(xmlDocument.CreateTextNode(pupil.PhoneNumber));
                Address.AppendChild(xmlDocument.CreateTextNode(pupil.Address));
                City.AppendChild(xmlDocument.CreateTextNode(pupil.City));
                SchoolName.AppendChild(xmlDocument.CreateTextNode(pupil.SchoolName));
                Grade.AppendChild(xmlDocument.CreateTextNode(pupil.Grade.ToString()));
                CourseLanguage.AppendChild(xmlDocument.CreateTextNode(pupil.CourseLanguage.ToString()));
                Shift.AppendChild(xmlDocument.CreateTextNode(pupil.Shift.ToString()));

                record.AppendChild(FirstName);
                record.AppendChild(LastName);
                record.AppendChild(DateOfBirth);
                record.AppendChild(Gender);
                record.AppendChild(PhoneNumber);
                record.AppendChild(Address);
                record.AppendChild(City);
                record.AppendChild(SchoolName);
                record.AppendChild(Grade);
                record.AppendChild(CourseLanguage);
                record.AppendChild(Shift);
                dataset.AppendChild(record);
            }
            xmlDocument.AppendChild(dataset);

            return xmlDocument;
        }
    }
}
