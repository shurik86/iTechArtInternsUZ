using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml;


namespace ITechArt.Parsers.XmlGenerate
{
    public sealed class PupilXmlGenerate : IPupilXmlGenerate
    {
        private readonly IPupilRepository _pupilRepository;

        public PupilXmlGenerate(IPupilRepository pupilRepository)
        {
            _pupilRepository = pupilRepository;
        }


        /// <summary>
        /// Generates a new XML file of type Pupils table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetPupilsXmlAsync()
        {
            var xmlDocument = new XmlDocument();
            var declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            var pupils = xmlDocument.CreateElement(null, XmlConstants.pupils, null);

            var pupilsArray = await _pupilRepository.GetAllAsync();
            foreach (var pupil in pupilsArray)
            {
                var pupilElement = xmlDocument.CreateElement(null, XmlConstants.pupil, null);
                
                var FirstName = xmlDocument.CreateAttribute(null, PupilConstants.FIRSTNAME, null);
                var LastName = xmlDocument.CreateAttribute(null, PupilConstants.LASTNAME, null);
                var DateOfBirth = xmlDocument.CreateAttribute(null, PupilConstants.DATEOFBIRTH, null);
                var Gender = xmlDocument.CreateAttribute(null, PupilConstants.GENDER, null);
                var PhoneNumber = xmlDocument.CreateAttribute(null, PupilConstants.PHONENUMBER, null);
                var Address = xmlDocument.CreateAttribute(null, PupilConstants.ADDRESS, null);
                var City = xmlDocument.CreateAttribute(null, PupilConstants.CITY, null);
                var SchoolName = xmlDocument.CreateAttribute(null, PupilConstants.SCHOOLNAME, null);
                var Grade = xmlDocument.CreateAttribute(null, PupilConstants.GRADE, null);
                var CourseLanguage = xmlDocument.CreateAttribute(null, PupilConstants.COURSELANGUAGE, null);
                var Shift = xmlDocument.CreateAttribute(null, PupilConstants.SHIFT, null);

                FirstName.Value = pupil.FirstName;
                LastName.Value = pupil.LastName;
                DateOfBirth.Value = pupil.DateOfBirth.ToString();
                Gender.Value = pupil.Gender.ToString();
                PhoneNumber.Value = pupil.PhoneNumber;
                Address.Value = pupil.Address;
                City.Value = pupil.City;
                SchoolName.Value = pupil.SchoolName;
                Grade.Value = pupil.Grade.ToString();
                CourseLanguage.Value = pupil.CourseLanguage.ToString();
                Shift.Value = pupil.Shift.ToString();

                pupilElement.Attributes.Append(FirstName);
                pupilElement.Attributes.Append(LastName);
                pupilElement.Attributes.Append(DateOfBirth);
                pupilElement.Attributes.Append(Gender);
                pupilElement.Attributes.Append(PhoneNumber);
                pupilElement.Attributes.Append(Address);
                pupilElement.Attributes.Append(City);
                pupilElement.Attributes.Append(SchoolName);
                pupilElement.Attributes.Append(Grade);
                pupilElement.Attributes.Append(CourseLanguage);
                pupilElement.Attributes.Append(Shift);

                pupils.AppendChild(pupilElement);
            }
            xmlDocument.AppendChild(pupils);

            return xmlDocument;
        }
    }
}
