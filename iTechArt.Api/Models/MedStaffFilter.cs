using iTechArt.Domain.Enums;
using iTechArt.Domain.FilterModels;

namespace iTechArt.Api.Models
{
    public class MedStaffFilter : IMedStaffFilter
    {
        /// <summary>
        /// Gets or sets Id of a medStaff.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets Firstname of a medStaff.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Lastname of a medStaff.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Gender of a medStaff.
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Gets or sets Email of a medStaff.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Phonenumber of a medStaff.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or setsDate of birth of a medStaff.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets Address of a medStaff.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets Current salay of a medStaff.
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Gets or sets Hospital name where the medStaff works.
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// Gets or sets Postal code of the city where medStaff lives.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets Shift of a medStaff [day/night].
        /// </summary>
        public Shift? Shift { get; set; }
    }
}
