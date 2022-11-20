﻿using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
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
            var xmlDocument = new XmlDocument();
            var declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            var medStaffs = xmlDocument.CreateElement(null, XmlConstants.medstaff, null);

            var medStaffArray = await _medStaffRepository.GetAllAsync();
            foreach (var medStaff in medStaffArray)
            {
                var staffElement = xmlDocument.CreateElement(null, XmlConstants.staff, null);
                
                var FirstName = xmlDocument.CreateAttribute(null, MedStaffConstants.FirstName, null);
                var LastName = xmlDocument.CreateAttribute(null, MedStaffConstants.LastName, null);
                var Gender = xmlDocument.CreateAttribute(null, MedStaffConstants.Gender, null);
                var Email = xmlDocument.CreateAttribute(null, MedStaffConstants.Email, null);
                var PhoneNumber = xmlDocument.CreateAttribute(null, MedStaffConstants.PhoneNumber, null);
                var DateOfBirth = xmlDocument.CreateAttribute(null, MedStaffConstants.DateOfBirth, null);
                var Address = xmlDocument.CreateAttribute(null, MedStaffConstants.Address, null);
                var Salary = xmlDocument.CreateAttribute(null, MedStaffConstants.Salary, null);
                var HospitalName = xmlDocument.CreateAttribute(null, MedStaffConstants.HospitalName, null);
                var PostalCode = xmlDocument.CreateAttribute(null, MedStaffConstants.PostalCode, null);
                var Shift = xmlDocument.CreateAttribute(null, MedStaffConstants.Shift, null);

                FirstName.Value = medStaff.FirstName;
                LastName.Value = medStaff.LastName;
                Gender.Value = medStaff.Gender.ToString();
                Email.Value = medStaff.Email;
                PhoneNumber.Value = medStaff.PhoneNumber;
                DateOfBirth.Value = medStaff.DateOfBirth.ToString();
                Address.Value = medStaff.Address;
                Salary.Value = medStaff.Salary.ToString();
                HospitalName.Value = medStaff.HospitalName;
                PostalCode.Value = medStaff.PostalCode;
                Shift.Value = medStaff.Shift.ToString();

                staffElement.Attributes.Append(FirstName);
                staffElement.Attributes.Append(LastName);
                staffElement.Attributes.Append(Gender);
                staffElement.Attributes.Append(Email);
                staffElement.Attributes.Append(PhoneNumber);
                staffElement.Attributes.Append(DateOfBirth);
                staffElement.Attributes.Append(Address);
                staffElement.Attributes.Append(Salary);
                staffElement.Attributes.Append(HospitalName);
                staffElement.Attributes.Append(PostalCode);
                staffElement.Attributes.Append(Shift);

                medStaffs.AppendChild(staffElement);
            }
            xmlDocument.AppendChild(medStaffs);

            return xmlDocument;
        }
    }
}
