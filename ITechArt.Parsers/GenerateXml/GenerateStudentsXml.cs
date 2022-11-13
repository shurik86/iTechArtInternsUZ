using iTechArt.Database.DbContexts;
using iTechArt.Domain.ParserInterfaces.IGenerateXml;
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
    public sealed class GenerateStudentsXml : IGenerateStudentXml
    {
        private readonly AppDbContext _dbContext;

        public GenerateStudentsXml(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Generates a new XML file of type Students table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetStudentsXmlAsync()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            XmlElement dataset = xmlDocument.CreateElement(null, XmlConstants.dataset, null);

            var studentsArray = await _dbContext.Students.ToArrayAsync();
            foreach (var student in studentsArray)
            {
                XmlElement record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlElement FirstName = xmlDocument.CreateElement(null, StudentsConstants.FirstName, null);
                XmlElement LastName = xmlDocument.CreateElement(null, StudentsConstants.LastName, null);
                XmlElement Email = xmlDocument.CreateElement(null, StudentsConstants.Email, null);
                XmlElement Password = xmlDocument.CreateElement(null, StudentsConstants.Password, null);
                XmlElement Majority = xmlDocument.CreateElement(null, StudentsConstants.Majority, null);
                XmlElement Gender = xmlDocument.CreateElement(null, StudentsConstants.Gender, null);
                XmlElement DateOfBirth = xmlDocument.CreateElement(null, StudentsConstants.DateOfBirth, null);
                XmlElement University = xmlDocument.CreateElement(null, StudentsConstants.University, null);

                XmlText FirstNameText = xmlDocument.CreateTextNode(student.FirstName);
                XmlText LastNameText = xmlDocument.CreateTextNode(student.LastName);
                XmlText EmailText = xmlDocument.CreateTextNode(student.Email);
                XmlText PasswordText = xmlDocument.CreateTextNode(student.Password);
                XmlText MajorityText = xmlDocument.CreateTextNode(student.Majority);
                XmlText GenderText = xmlDocument.CreateTextNode(student.Gender.ToString());
                XmlText DateOfBirthText = xmlDocument.CreateTextNode(student.DateOfBirth.ToString());
                XmlText UniversityText = xmlDocument.CreateTextNode(student.University);

                FirstName.AppendChild(FirstNameText);
                LastName.AppendChild(LastNameText);
                Email.AppendChild(EmailText);
                Password.AppendChild(PasswordText);
                Majority.AppendChild(MajorityText);
                Gender.AppendChild(GenderText);
                DateOfBirth.AppendChild(DateOfBirthText);
                University.AppendChild(UniversityText);

                record.AppendChild(FirstName);
                record.AppendChild(LastName);
                record.AppendChild(Email);
                record.AppendChild(Password);
                record.AppendChild(Majority);
                record.AppendChild(Gender);
                record.AppendChild(DateOfBirth);
                record.AppendChild(University);
                dataset.AppendChild(record);
            }
            xmlDocument.AppendChild(dataset);

            return xmlDocument;
        }
    }
}
