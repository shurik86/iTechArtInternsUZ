using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using ITechArt.Parsers.Constants;
using System.Xml;


namespace ITechArt.Parsers.XmlGenerate
{
    public sealed class StudentXmlGenerate : IStudentXmlGenerate
    {
        private readonly IStudentRepository _studentRepository;

        public StudentXmlGenerate(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }



        /// <summary>
        /// Generates a new XML file of type Students table from the Database.
        /// </summary>
        public async Task<XmlDocument> GetStudentsXmlAsync()
        {
            var xmlDocument = new XmlDocument();
            var declaration = xmlDocument.CreateXmlDeclaration(XmlConstants.version, XmlConstants.encoding, null);
            xmlDocument.AppendChild(declaration);
            var students = xmlDocument.CreateElement(null, XmlConstants.students, null);

            var studentsArray = await _studentRepository.GetAllAsync();
            foreach (var student in studentsArray)
            {
                var studentElement = xmlDocument.CreateElement(null, XmlConstants.student, null);
                
                var FirstName = xmlDocument.CreateAttribute(null, StudentsConstants.FirstName, null);
                var LastName = xmlDocument.CreateAttribute(null, StudentsConstants.LastName, null);
                var Email = xmlDocument.CreateAttribute(null, StudentsConstants.Email, null);
                var Password = xmlDocument.CreateAttribute(null, StudentsConstants.Password, null);
                var Majority = xmlDocument.CreateAttribute(null, StudentsConstants.Majority, null);
                var Gender = xmlDocument.CreateAttribute(null, StudentsConstants.Gender, null);
                var DateOfBirth = xmlDocument.CreateAttribute(null, StudentsConstants.DateOfBirth, null);
                var University = xmlDocument.CreateAttribute(null, StudentsConstants.University, null);

                FirstName.Value = student.FirstName;
                LastName.Value = student.LastName;
                Email.Value = student.Email;
                Password.Value = student.Password;
                Majority.Value = student.Majority;
                Gender.Value = student.Gender.ToString();
                DateOfBirth.Value = student.DateOfBirth.ToString();
                University.Value = student.University.ToString();

                studentElement.Attributes.Append(FirstName);
                studentElement.Attributes.Append(LastName);
                studentElement.Attributes.Append(Email);
                studentElement.Attributes.Append(Password);
                studentElement.Attributes.Append(Majority);
                studentElement.Attributes.Append(Gender);
                studentElement.Attributes.Append(DateOfBirth);
                studentElement.Attributes.Append(University);

                students.AppendChild(studentElement);
            }
            xmlDocument.AppendChild(students);

            return xmlDocument;
        }
    }
}
