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
            var xmlDocument = new XmlDocument();
            var declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            var groceries = xmlDocument.CreateElement(null, XmlConstants.groceries, null);

            var groceryArray = await _groceryRepository.GetAllAsync();
            foreach (var grocery in groceryArray)
            {
                var groceryElement = xmlDocument.CreateElement(null, XmlConstants.grocery, null);
                
                var FirstName = xmlDocument.CreateAttribute(null, GroceryConstants.FirstName, null);
                var LastName = xmlDocument.CreateAttribute(null, GroceryConstants.LastName, null);
                var Birthday = xmlDocument.CreateAttribute(null, GroceryConstants.Birthday, null);
                var Gender = xmlDocument.CreateAttribute(null, GroceryConstants.Gender, null);
                var Email = xmlDocument.CreateAttribute(null, GroceryConstants.Email, null);
                var Jobtitle = xmlDocument.CreateAttribute(null, GroceryConstants.Jobtitle, null);
                var Departmentretail = xmlDocument.CreateAttribute(null, GroceryConstants.Departmentretail, null);
                var Salary = xmlDocument.CreateAttribute(null, GroceryConstants.Salary, null);

                FirstName.Value = grocery.FirstName;
                LastName.Value = grocery.LastName;
                Birthday.Value = grocery.Birthday.ToString();
                Gender.Value = grocery.Gender.ToString();
                Email.Value = grocery.Email;
                Jobtitle.Value = grocery.JobTitle;
                Departmentretail.Value = grocery.DepartmentRetail;
                Salary.Value = grocery.Salary.ToString();

                groceries.AppendChild(groceryElement);
            }
            xmlDocument.AppendChild(groceries);

            return xmlDocument;
        }
    }
}
