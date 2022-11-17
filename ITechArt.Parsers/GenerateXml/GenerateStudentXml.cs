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
    public sealed class GenerateStudentXml : IGenerateStudentXml
    {
        private readonly IStudentRepository _studentRepository;

        public GenerateStudentXml(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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

            var studentsArray = await _studentRepository.GetAllAsync();
            foreach (var student in studentsArray)
            {
                XmlNode record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlNode FirstName = xmlDocument.CreateElement(null, StudentsConstants.FirstName, null);
                XmlNode LastName = xmlDocument.CreateElement(null, StudentsConstants.LastName, null);
                XmlNode Email = xmlDocument.CreateElement(null, StudentsConstants.Email, null);
                XmlNode Password = xmlDocument.CreateElement(null, StudentsConstants.Password, null);
                XmlNode Majority = xmlDocument.CreateElement(null, StudentsConstants.Majority, null);
                XmlNode Gender = xmlDocument.CreateElement(null, StudentsConstants.Gender, null);
                XmlNode DateOfBirth = xmlDocument.CreateElement(null, StudentsConstants.DateOfBirth, null);
                XmlNode University = xmlDocument.CreateElement(null, StudentsConstants.University, null);

                FirstName.AppendChild(xmlDocument.CreateTextNode(student.FirstName));
                LastName.AppendChild(xmlDocument.CreateTextNode(student.LastName));
                Email.AppendChild(xmlDocument.CreateTextNode(student.Email));
                Password.AppendChild(xmlDocument.CreateTextNode(student.Password));
                Majority.AppendChild(xmlDocument.CreateTextNode(student.Majority));
                Gender.AppendChild(xmlDocument.CreateTextNode(student.Gender.ToString()));
                DateOfBirth.AppendChild(xmlDocument.CreateTextNode(student.DateOfBirth.ToString()));
                University.AppendChild(xmlDocument.CreateTextNode(student.University));

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
