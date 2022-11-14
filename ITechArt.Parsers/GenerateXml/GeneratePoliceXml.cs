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
    public sealed class GeneratePoliceXml : IGeneratePoliceXml
    {
        private readonly IPoliceRepository _policeRepository;

        public GeneratePoliceXml(IPoliceRepository policeRepository)
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
            foreach(var police in policeArray)
            {
                XmlElement record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlElement Name = xmlDocument.CreateElement(null, PoliceConstants.Name, null);
                XmlElement Surname = xmlDocument.CreateElement(null, PoliceConstants.Surname, null);
                XmlElement Email = xmlDocument.CreateElement(null, PoliceConstants.Email, null);
                XmlElement Gender = xmlDocument.CreateElement(null, PoliceConstants.Gender, null);
                XmlElement Address = xmlDocument.CreateElement(null, PoliceConstants.Address, null);
                XmlElement JobTitle = xmlDocument.CreateElement(null, PoliceConstants.JobTitle, null);
                XmlElement Salary = xmlDocument.CreateElement(null, PoliceConstants.Salary, null);

                XmlText NameText = xmlDocument.CreateTextNode(police.Name);
                XmlText SurnameText = xmlDocument.CreateTextNode(police.Surname);
                XmlText EmailText = xmlDocument.CreateTextNode(police.Email);
                XmlText GenderText = xmlDocument.CreateTextNode(police.Gender.ToString());
                XmlText AddressText = xmlDocument.CreateTextNode(police.Address);
                XmlText JobTitleText = xmlDocument.CreateTextNode(police.JobTitle);
                XmlText SalaryText = xmlDocument.CreateTextNode(police.Salary.ToString());

                Name.AppendChild(NameText);
                Surname.AppendChild(SurnameText);
                Email.AppendChild(EmailText);
                Gender.AppendChild(GenderText);
                Address.AppendChild(AddressText);
                JobTitle.AppendChild(JobTitleText);
                Salary.AppendChild(SalaryText);

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
