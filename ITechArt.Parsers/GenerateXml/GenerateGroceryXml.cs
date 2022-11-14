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
    public sealed class GenerateGroceryXml : IGenerateGroceryXml
    {
        private readonly IGroceryRepository _groceryRepository;

        public GenerateGroceryXml(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }


        /// <summary>
        /// Generates a new XML file of type Grocery table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetGroceryXmlAsync()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            XmlElement dataset = xmlDocument.CreateElement(null, XmlConstants.dataset, null);

            var groceryArray = await _groceryRepository.GetAllAsync();
            foreach (var grocery in groceryArray)
            {
                XmlElement record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlElement FirstName = xmlDocument.CreateElement(null, GroceryConstants.FirstName, null);
                XmlElement LastName = xmlDocument.CreateElement(null, GroceryConstants.LastName, null);
                XmlElement Birthday = xmlDocument.CreateElement(null, GroceryConstants.Birthday, null);
                XmlElement Gender = xmlDocument.CreateElement(null, GroceryConstants.Gender, null);
                XmlElement Email = xmlDocument.CreateElement(null, GroceryConstants.Email, null);
                XmlElement Jobtitle = xmlDocument.CreateElement(null, GroceryConstants.Jobtitle, null);
                XmlElement Departmentretail = xmlDocument.CreateElement(null, GroceryConstants.Departmentretail, null);
                XmlElement Salary = xmlDocument.CreateElement(null, GroceryConstants.Salary, null);

                XmlText FirstNameText = xmlDocument.CreateTextNode(grocery.FirstName);
                XmlText LastNameText = xmlDocument.CreateTextNode(grocery.LastName);
                XmlText BirthdayText = xmlDocument.CreateTextNode(grocery.Birthday.ToString());
                XmlText GenderText = xmlDocument.CreateTextNode(grocery.Gender.ToString());
                XmlText EmailText = xmlDocument.CreateTextNode(grocery.Email);
                XmlText JobtitleText = xmlDocument.CreateTextNode(grocery.JobTitle);
                XmlText DepartmentretailText = xmlDocument.CreateTextNode(grocery.DepartmentRetail);
                XmlText SalaryText = xmlDocument.CreateTextNode(grocery.Salary.ToString());

                FirstName.AppendChild(FirstNameText);
                LastName.AppendChild(LastNameText);
                Birthday.AppendChild(BirthdayText);
                Gender.AppendChild(GenderText);
                Email.AppendChild(EmailText);
                Jobtitle.AppendChild(JobtitleText);
                Departmentretail.AppendChild(DepartmentretailText);
                Salary.AppendChild(SalaryText);

                record.AppendChild(FirstName);
                record.AppendChild(LastName);
                record.AppendChild(Birthday);
                record.AppendChild(Gender);
                record.AppendChild(Email);
                record.AppendChild(Jobtitle);
                record.AppendChild(Departmentretail);
                record.AppendChild(Salary);
                dataset.AppendChild(record);
            }
            xmlDocument.AppendChild(dataset);

            return xmlDocument;
        }
    }
}
