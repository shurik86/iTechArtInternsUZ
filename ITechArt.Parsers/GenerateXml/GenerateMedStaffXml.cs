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
    public sealed class GenerateMedStaffXml : IGenerateMedStaffXml
    {
        private readonly IMedStaffRepository _medStaffRepository;

        public GenerateMedStaffXml(IMedStaffRepository medStaffRepository)
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
                XmlElement record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlElement FirstName = xmlDocument.CreateElement(null, MedStaffConstants.FirstName, null);
                XmlElement LastName = xmlDocument.CreateElement(null, MedStaffConstants.LastName, null);
                XmlElement Gender = xmlDocument.CreateElement(null, MedStaffConstants.Gender, null);
                XmlElement Email = xmlDocument.CreateElement(null, MedStaffConstants.Email, null);
                XmlElement PhoneNumber = xmlDocument.CreateElement(null, MedStaffConstants.PhoneNumber, null);
                XmlElement DateOfBirth = xmlDocument.CreateElement(null, MedStaffConstants.DateOfBirth, null);
                XmlElement Address = xmlDocument.CreateElement(null, MedStaffConstants.Address, null);
                XmlElement Salary = xmlDocument.CreateElement(null, MedStaffConstants.Salary, null);
                XmlElement HospitalName = xmlDocument.CreateElement(null, MedStaffConstants.HospitalName, null);
                XmlElement PostalCode = xmlDocument.CreateElement(null, MedStaffConstants.PostalCode, null);
                XmlElement Shift = xmlDocument.CreateElement(null, MedStaffConstants.Shift, null);

                XmlText FirstNameText = xmlDocument.CreateTextNode(medStaff.FirstName);
                XmlText LastNameText = xmlDocument.CreateTextNode(medStaff.LastName);
                XmlText GenderText = xmlDocument.CreateTextNode(medStaff.Gender.ToString());
                XmlText EmailText = xmlDocument.CreateTextNode(medStaff.Email);
                XmlText PhoneNumberText = xmlDocument.CreateTextNode(medStaff.PhoneNumber);
                XmlText DateOfBirthText = xmlDocument.CreateTextNode(medStaff.DateOfBirth.ToString());
                XmlText AddressText = xmlDocument.CreateTextNode(medStaff.Address);
                XmlText SalaryText = xmlDocument.CreateTextNode(medStaff.Salary.ToString());
                XmlText HospitalNameText = xmlDocument.CreateTextNode(medStaff.HospitalName);
                XmlText PostalCodeText = xmlDocument.CreateTextNode(medStaff.PostalCode);
                XmlText ShiftText = xmlDocument.CreateTextNode(medStaff.Shift.ToString());

                FirstName.AppendChild(FirstNameText);
                LastName.AppendChild(LastNameText);
                Gender.AppendChild(GenderText);
                Email.AppendChild(EmailText);
                PhoneNumber.AppendChild(PhoneNumberText);
                DateOfBirth.AppendChild(DateOfBirthText);
                Address.AppendChild(AddressText);
                Salary.AppendChild(SalaryText);
                HospitalName.AppendChild(HospitalNameText);
                PostalCode.AppendChild(PostalCodeText);
                Shift.AppendChild(ShiftText);

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
