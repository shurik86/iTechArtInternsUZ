using iTechArt.Database.DbContexts;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ITechArt.Parsers.GenerateXml
{
    public sealed class GeneratePupilsXml : IGeneratePupilsXml
    {
        private readonly IPupilRepository _pupilRepository;

        public GeneratePupilsXml(IPupilRepository pupilRepository)
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
                XmlElement record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlElement FirstName = xmlDocument.CreateElement(null, PupilsConstants.FirstName, null);
                XmlElement LastName = xmlDocument.CreateElement(null, PupilsConstants.LastName, null);
                XmlElement DateOfBirth = xmlDocument.CreateElement(null, PupilsConstants.DateOfBirth, null);
                XmlElement Gender = xmlDocument.CreateElement(null, PupilsConstants.Gender, null);
                XmlElement PhoneNumber = xmlDocument.CreateElement(null, PupilsConstants.PhoneNumber, null);
                XmlElement Address = xmlDocument.CreateElement(null, PupilsConstants.Address, null);
                XmlElement City = xmlDocument.CreateElement(null, PupilsConstants.City, null);
                XmlElement SchoolName = xmlDocument.CreateElement(null, PupilsConstants.SchoolName, null);
                XmlElement Grade = xmlDocument.CreateElement(null, PupilsConstants.Grade, null);
                XmlElement CourseLanguage = xmlDocument.CreateElement(null, PupilsConstants.CourseLanguage, null);
                XmlElement Shift = xmlDocument.CreateElement(null, PupilsConstants.Shift, null);

                XmlText FirstNameText = xmlDocument.CreateTextNode(pupil.FirstName);
                XmlText LastNameText = xmlDocument.CreateTextNode(pupil.LastName);
                XmlText DateOfBirthText = xmlDocument.CreateTextNode(pupil.DateOfBirth.ToString());
                XmlText GenderText = xmlDocument.CreateTextNode(pupil.Gender.ToString());
                XmlText PhoneNumberText = xmlDocument.CreateTextNode(pupil.PhoneNumber);
                XmlText AddressText = xmlDocument.CreateTextNode(pupil.Address);
                XmlText CityText = xmlDocument.CreateTextNode(pupil.City);
                XmlText SchoolNameText = xmlDocument.CreateTextNode(pupil.SchoolName);
                XmlText GradeText = xmlDocument.CreateTextNode(pupil.Grade.ToString());
                XmlText CourseLanguageText = xmlDocument.CreateTextNode(pupil.CourseLanguage.ToString());
                XmlText ShiftText = xmlDocument.CreateTextNode(pupil.Shift.ToString());

                FirstName.AppendChild(FirstNameText);
                LastName.AppendChild(LastNameText);
                DateOfBirth.AppendChild(DateOfBirthText);
                Gender.AppendChild(GenderText);
                PhoneNumber.AppendChild(PhoneNumberText);
                Address.AppendChild(AddressText);
                City.AppendChild(CityText);
                SchoolName.AppendChild(SchoolNameText);
                Grade.AppendChild(GradeText);
                CourseLanguage.AppendChild(CourseLanguageText);
                Shift.AppendChild(ShiftText);

                record.AppendChild(FirstName);
                record.AppendChild(LastName);
                record.AppendChild(DateOfBirthText);
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
