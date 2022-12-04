using iTechArt.Database.Entities.Airports;
using iTechArt.Database.Entities.Groceries;
using iTechArt.Database.Entities.MedicalStaff;
using iTechArt.Database.Entities.Police;
using iTechArt.Database.Entities.Pupils;
using iTechArt.Database.Entities.Students;
using iTechArt.Domain.FilterModels;
using LinqKit;

namespace iTechArt.Repository.FilterExtensions
{
    public static class Filtering
    {
        private const string FalsePredicate = "f => False";

        /// <summary>
        /// Filtrate pupils.
        /// </summary>
        public static IQueryable<PupilDb> Filtrate(this IQueryable<PupilDb> pupils, IPupilFilter pupilFilter)
        {
            var where = PredicateBuilder.New<PupilDb>();

            if (pupilFilter.Id != null)
            {
                where.And(p => p.Id < pupilFilter.Id);
            }

            if (!string.IsNullOrEmpty(pupilFilter.FirstName))
            {
                where.And(p => p.FirstName.ToLower().StartsWith(pupilFilter.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(pupilFilter.LastName))
            {
                where.And(p => p.LastName.ToLower().StartsWith(pupilFilter.LastName.ToLower()));
            }

            if (pupilFilter.Age != null)
            {
                where.And(p => DateTime.Now.Year - p.DateOfBirth.Year < pupilFilter.Age);
            }

            if (pupilFilter.Gender == Domain.Enums.Gender.Male || pupilFilter.Gender == Domain.Enums.Gender.Female)
            {
                where.And(p => p.Gender.Equals(pupilFilter.Gender));
            }

            if (!string.IsNullOrEmpty(pupilFilter.PhoneNumber))
            {
                where.And(p => p.PhoneNumber.ToLower().StartsWith(pupilFilter.PhoneNumber.ToLower()));
            }

            if (!string.IsNullOrEmpty(pupilFilter.Address))
            {
                where.And(p => p.Address.ToLower().StartsWith(pupilFilter.Address.ToLower()));
            }

            if (!string.IsNullOrEmpty(pupilFilter.City))
            {
                where.And(p => p.City.ToLower().StartsWith(pupilFilter.City.ToLower()));
            }

            if (!string.IsNullOrEmpty(pupilFilter.SchoolName))
            {
                where.And(p => p.SchoolName.ToLower().StartsWith(pupilFilter.SchoolName.ToLower()));
            }

            if (pupilFilter.Grade != null)
            {
                where.And(p => p.Grade < pupilFilter.Grade);
            }

            if (pupilFilter.CourseLanguage == Domain.Enums.CourseLanguage.Russian ||
                pupilFilter.CourseLanguage == Domain.Enums.CourseLanguage.Uzbek ||
                pupilFilter.CourseLanguage == Domain.Enums.CourseLanguage.English)
            {
                where.And(p => p.CourseLanguage.Equals(pupilFilter.CourseLanguage));
            }

            if (pupilFilter.Shift == Domain.Enums.Shift.Day || pupilFilter.Shift == Domain.Enums.Shift.Night)
            {
                where.And(p => p.Shift.Equals(pupilFilter.Shift));
            }

            if (FalsePredicate.Equals(where.ToString()))
            {
                return pupils;
            }

            return pupils.Where(where);
        }

        /// <summary>
        /// Filtrate students.
        /// </summary>
        public static IQueryable<StudentDb> Filtrate(this IQueryable<StudentDb> students, IStudentFilter studentFilter)
        {
            var where = PredicateBuilder.New<StudentDb>();

            if (studentFilter.Id != null)
            {
                where.And(s => s.Id < studentFilter.Id);
            }

            if (!string.IsNullOrEmpty(studentFilter.FirstName))
            {
                where.And(s => s.FirstName.ToLower().StartsWith(studentFilter.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(studentFilter.LastName))
            {
                where.And(s => s.LastName.ToLower().StartsWith(studentFilter.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(studentFilter.Email))
            {
                where.And(s => s.Email.ToLower().StartsWith(studentFilter.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(studentFilter.Password))
            {
                where.And(s => s.Password.ToLower().StartsWith(studentFilter.Password.ToLower()));
            }

            if (!string.IsNullOrEmpty(studentFilter.Majority))
            {
                where.And(s => s.Majority.ToLower().StartsWith(studentFilter.Majority.ToLower()));
            }

            if (!string.IsNullOrEmpty(studentFilter.Majority))
            {
                where.And(s => s.Majority.ToLower().StartsWith(studentFilter.Majority.ToLower()));
            }

            if (studentFilter.Gender == Domain.Enums.Gender.Male || studentFilter.Gender == Domain.Enums.Gender.Female)
            {
                where.And(p => p.Gender.Equals(studentFilter.Gender));
            }

            if (studentFilter.Age != null)
            {
                where.And(p => DateTime.Now.Year - p.DateOfBirth.Year < studentFilter.Age);
            }

            if (!string.IsNullOrEmpty(studentFilter.University))
            {
                where.And(s => s.University.ToLower().StartsWith(studentFilter.University.ToLower()));
            }

            if (studentFilter.Faculty == Domain.Enums.Faculty.Economics ||
                studentFilter.Faculty == Domain.Enums.Faculty.Science ||
                studentFilter.Faculty == Domain.Enums.Faculty.Engineering ||
                studentFilter.Faculty == Domain.Enums.Faculty.Medicine ||
                studentFilter.Faculty == Domain.Enums.Faculty.Psychology ||
                studentFilter.Faculty == Domain.Enums.Faculty.Law)
            {
                where.And(s => s.Faculty.Equals(studentFilter.Faculty));
            }

            if (FalsePredicate.Equals(where.ToString()))
            {
                return students;
            }

            return students.Where(where);
        }

        /// <summary>
        /// Filtrate polices
        /// </summary>
        public static IQueryable<PoliceDb> Filtrate(this IQueryable<PoliceDb> polices, IPoliceFilter policeFilter)
        {
            var where = PredicateBuilder.New<PoliceDb>();

            if (policeFilter.Id != null)
            {
                where.And(s => s.Id < policeFilter.Id);
            }

            if (!string.IsNullOrEmpty(policeFilter.Name))
            {
                where.And(p => p.Name.ToLower().StartsWith(policeFilter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(policeFilter.Surname))
            {
                where.And(p => p.Surname.ToLower().StartsWith(policeFilter.Surname.ToLower()));
            }

            if (!string.IsNullOrEmpty(policeFilter.Email))
            {
                where.And(p => p.Email.ToLower().StartsWith(policeFilter.Email.ToLower()));
            }

            if (policeFilter.Gender == Domain.Enums.Gender.Male || policeFilter.Gender == Domain.Enums.Gender.Female)
            {
                where.And(p => p.Gender.Equals(policeFilter.Gender));
            }

            if (!string.IsNullOrEmpty(policeFilter.Address))
            {
                where.And(p => p.Address.ToLower().StartsWith(policeFilter.Address.ToLower()));
            }

            if (!string.IsNullOrEmpty(policeFilter.JobTitle))
            {
                where.And(p => p.JobTitle.ToLower().StartsWith(policeFilter.JobTitle.ToLower()));
            }

            if (policeFilter.Salary != null)
            {
                where.And(p => p.Salary < policeFilter.Salary);
            }

            if (policeFilter.Age != null)
            {
                where.And(p => DateTime.Now.Year - p.BirthDate.Year < policeFilter.Age);
            }

            if (FalsePredicate.Equals(where.ToString()))
            {
                return polices;
            }

            return polices.Where(where);
        }

        /// <summary>
        /// Filtrate medstaffs.
        /// </summary>
        public static IQueryable<MedStaffDb> Filtrate(this IQueryable<MedStaffDb> medStaffs, IMedStaffFilter medStaffFilter)
        {
            var where = PredicateBuilder.New<MedStaffDb>();

            if (medStaffFilter.Id != null)
            {
                where.And(m => m.Id < medStaffFilter.Id);
            }

            if (!string.IsNullOrEmpty(medStaffFilter.FirstName))
            {
                where.And(m => m.FirstName.ToLower().StartsWith(medStaffFilter.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(medStaffFilter.LastName))
            {
                where.And(m => m.LastName.ToLower().StartsWith(medStaffFilter.LastName.ToLower()));
            }

            if (medStaffFilter.Gender == Domain.Enums.Gender.Male || medStaffFilter.Gender == Domain.Enums.Gender.Female)
            {
                where.And(p => p.Gender.Equals(medStaffFilter.Gender));
            }

            if (!string.IsNullOrEmpty(medStaffFilter.Email))
            {
                where.And(m => m.Email.ToLower().StartsWith(medStaffFilter.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(medStaffFilter.PhoneNumber))
            {
                where.And(m => m.PhoneNumber.ToLower().StartsWith(medStaffFilter.PhoneNumber.ToLower()));
            }

            if (medStaffFilter.Age != null)
            {
                where.And(p => DateTime.Now.Year - p.DateOfBirth.Year < medStaffFilter.Age);
            }

            if (!string.IsNullOrEmpty(medStaffFilter.Address))
            {
                where.And(m => m.Address.ToLower().StartsWith(medStaffFilter.Address.ToLower()));
            }

            if (medStaffFilter.Salary != null)
            {
                where.And(m => m.Salary < medStaffFilter.Salary);
            }

            if (!string.IsNullOrEmpty(medStaffFilter.HospitalName))
            {
                where.And(m => m.HospitalName.ToLower().StartsWith(medStaffFilter.HospitalName.ToLower()));
            }

            if (!string.IsNullOrEmpty(medStaffFilter.PostalCode))
            {
                where.And(m => m.PostalCode.ToLower().StartsWith(medStaffFilter.PostalCode.ToLower()));
            }

            if (medStaffFilter.Shift == Domain.Enums.Shift.Day || medStaffFilter.Shift == Domain.Enums.Shift.Night)
            {
                where.And(p => p.Shift.Equals(medStaffFilter.Shift));
            }

            if (FalsePredicate.Equals(where.ToString()))
            {
                return medStaffs;
            }

            return medStaffs.Where(where);
        }

        /// <summary>
        /// Filtrate airports.
        /// </summary>
        public static IQueryable<AirportDb> Filtrate(this IQueryable<AirportDb> airports, IAirportFilter airportFilter)
        {
            var where = PredicateBuilder.New<AirportDb>();

            if (airportFilter.Id != null)
            {
                where.And(a => a.Id < airportFilter.Id);
            }

            if (!string.IsNullOrEmpty(airportFilter.AirportName))
            {
                where.And(a => a.AirportName.ToLower().StartsWith(airportFilter.AirportName.ToLower()));
            }

            if (airportFilter.BuiltDate != null)
            {
                where.And(a => a.BuiltDate.Year < airportFilter.BuiltDate);
            }
            
            if (airportFilter.Capacity != null)
            {
                where.And(a => a.Capacity < airportFilter.Capacity);
            }

            if (!string.IsNullOrEmpty(airportFilter.Address))
            {
                where.And(a => a.Address.ToLower().StartsWith(airportFilter.Address.ToLower()));
            }

            if (!string.IsNullOrEmpty(airportFilter.City))
            {
                where.And(a => a.City.ToLower().StartsWith(airportFilter.City.ToLower()));
            }

            if (airportFilter.EmployeesCount != null)
            {
                where.And(a => a.EmpoyeesCount < airportFilter.EmployeesCount);
            }

            if (airportFilter.PassengersPerYear != null)
            {
                where.And(a => a.PassengersPerYear < airportFilter.PassengersPerYear);
            }

            if (airportFilter.FlightsPerYear != null)
            {
                where.And(a => a.FlightsPerYear < airportFilter.FlightsPerYear);
            }

            if (airportFilter.AverageTicketPrice != null)
            {
                where.And(a => a.AverageTicketPrice < airportFilter.AverageTicketPrice);
            }

            if (FalsePredicate.Equals(where.ToString()))
            {
                return airports;
            }

            return airports.Where(where);
        }

        /// <summary>
        /// Filtrate groceries.
        /// </summary>
        public static IQueryable<GroceryDb> Filtrate(this IQueryable<GroceryDb> groceries, IGroceryFilter groceryFilter)
        {
            var where = PredicateBuilder.New<GroceryDb>();

            if (groceryFilter.Id != null)
            {
                where.And(m => m.Id < groceryFilter.Id);
            }

            if (!string.IsNullOrEmpty(groceryFilter.FirstName))
            {
                where.And(s => s.FirstName.ToLower().StartsWith(groceryFilter.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(groceryFilter.LastName))
            {
                where.And(s => s.LastName.ToLower().StartsWith(groceryFilter.LastName.ToLower()));
            }

            if (groceryFilter.Age != null)
            {
                where.And(p => DateTime.Now.Year - p.Birthday.Year < groceryFilter.Age);
            }

            if (groceryFilter.Gender == Domain.Enums.Gender.Male || groceryFilter.Gender == Domain.Enums.Gender.Female)
            {
                where.And(p => p.Gender.Equals(groceryFilter.Gender));
            }

            if (!string.IsNullOrEmpty(groceryFilter.Email))
            {
                where.And(p => p.Email.ToLower().StartsWith(groceryFilter.Email.ToLower()));
            }

            if (!string.IsNullOrEmpty(groceryFilter.JobTitle))
            {
                where.And(p => p.Jobtitle.ToLower().StartsWith(groceryFilter.JobTitle.ToLower()));
            }

            if (!string.IsNullOrEmpty(groceryFilter.DepartmentRetail))
            {
                where.And(p => p.Departmentretail.ToLower().StartsWith(groceryFilter.DepartmentRetail.ToLower()));
            }

            if (groceryFilter.Salary != null)
            {
                where.And(p => p.Salary < groceryFilter.Salary);
            }

            if (FalsePredicate.Equals(where.ToString()))
            {
                return groceries;
            }

            return groceries.Where(where);
        }
    }
}
