using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml;


namespace ITechArt.Parsers.XmlGenerate
{
    public sealed class MedStaffXmlGenerate : IMedStaffXmlGenerate
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public MedStaffXmlGenerate(IMedStaffRepository medStaffRepository)
        {
            _medStaffRepository = medStaffRepository;
        }

        /// <summary>
        /// Generates a new XML file of type MedStaff table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetMedStaffXmlAsync()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            XmlElement dataset = xmlDocument.CreateElement(null, XmlConstants.dataset, null);

            var medStaffArray = await _medStaffRepository.GetAllAsync();
            foreach (var medStaff in medStaffArray)
            {
                XmlNode record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlNode FirstName = xmlDocument.CreateElement(null, MedStaffConstants.FirstName, null);
                XmlNode LastName = xmlDocument.CreateElement(null, MedStaffConstants.LastName, null);
                XmlNode Gender = xmlDocument.CreateElement(null, MedStaffConstants.Gender, null);
                XmlNode Email = xmlDocument.CreateElement(null, MedStaffConstants.Email, null);
                XmlNode PhoneNumber = xmlDocument.CreateElement(null, MedStaffConstants.PhoneNumber, null);
                XmlNode DateOfBirth = xmlDocument.CreateElement(null, MedStaffConstants.DateOfBirth, null);
                XmlNode Address = xmlDocument.CreateElement(null, MedStaffConstants.Address, null);
                XmlNode Salary = xmlDocument.CreateElement(null, MedStaffConstants.Salary, null);
                XmlNode HospitalName = xmlDocument.CreateElement(null, MedStaffConstants.HospitalName, null);
                XmlNode PostalCode = xmlDocument.CreateElement(null, MedStaffConstants.PostalCode, null);
                XmlNode Shift = xmlDocument.CreateElement(null, MedStaffConstants.Shift, null);

                FirstName.AppendChild(xmlDocument.CreateTextNode(medStaff.FirstName));
                LastName.AppendChild(xmlDocument.CreateTextNode(medStaff.LastName));
                Gender.AppendChild(xmlDocument.CreateTextNode(medStaff.Gender.ToString()));
                Email.AppendChild(xmlDocument.CreateTextNode(medStaff.Email));
                PhoneNumber.AppendChild(xmlDocument.CreateTextNode(medStaff.PhoneNumber));
                DateOfBirth.AppendChild(xmlDocument.CreateTextNode(medStaff.DateOfBirth.ToString()));
                Address.AppendChild(xmlDocument.CreateTextNode(medStaff.Address));
                Salary.AppendChild(xmlDocument.CreateTextNode(medStaff.Salary.ToString()));
                HospitalName.AppendChild(xmlDocument.CreateTextNode(medStaff.HospitalName));
                PostalCode.AppendChild(xmlDocument.CreateTextNode(medStaff.PostalCode));
                Shift.AppendChild(xmlDocument.CreateTextNode(medStaff.Shift.ToString()));

                record.AppendChild(FirstName);
                record.AppendChild(LastName);
                record.AppendChild(Gender);
                record.AppendChild(Email);
                record.AppendChild(PhoneNumber);
                record.AppendChild(DateOfBirth);
                record.AppendChild(Address);
                record.AppendChild(Salary);
                record.AppendChild(HospitalName);
                record.AppendChild(PostalCode);
                record.AppendChild(Shift);
                dataset.AppendChild(record);
            }
            xmlDocument.AppendChild(dataset);

            return xmlDocument;
        }
    }
}
