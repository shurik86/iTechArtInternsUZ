using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml;


namespace ITechArt.Parsers.XmlGenerate
{
    public sealed class GroceryXmlGenerate : IGroceryXmlGenerate
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceryXmlGenerate(IGroceryRepository groceryRepository)
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
                XmlNode record = xmlDocument.CreateElement(null, XmlConstants.record, null);
                XmlNode FirstName = xmlDocument.CreateElement(null, GroceryConstants.FirstName, null);
                XmlNode LastName = xmlDocument.CreateElement(null, GroceryConstants.LastName, null);
                XmlNode Birthday = xmlDocument.CreateElement(null, GroceryConstants.Birthday, null);
                XmlNode Gender = xmlDocument.CreateElement(null, GroceryConstants.Gender, null);
                XmlNode Email = xmlDocument.CreateElement(null, GroceryConstants.Email, null);
                XmlNode Jobtitle = xmlDocument.CreateElement(null, GroceryConstants.Jobtitle, null);
                XmlNode Departmentretail = xmlDocument.CreateElement(null, GroceryConstants.Departmentretail, null);
                XmlNode Salary = xmlDocument.CreateElement(null, GroceryConstants.Salary, null);

                FirstName.AppendChild(xmlDocument.CreateTextNode(grocery.FirstName));
                LastName.AppendChild(xmlDocument.CreateTextNode(grocery.LastName));
                Birthday.AppendChild(xmlDocument.CreateTextNode(grocery.Birthday.ToString()));
                Gender.AppendChild(xmlDocument.CreateTextNode(grocery.Gender.ToString()));
                Email.AppendChild(xmlDocument.CreateTextNode(grocery.Email));
                Jobtitle.AppendChild(xmlDocument.CreateTextNode(grocery.JobTitle));
                Departmentretail.AppendChild(xmlDocument.CreateTextNode(grocery.DepartmentRetail));
                Salary.AppendChild(xmlDocument.CreateTextNode(grocery.Salary.ToString()));

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
