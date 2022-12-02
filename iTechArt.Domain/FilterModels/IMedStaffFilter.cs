using iTechArt.Domain.Enums;

namespace iTechArt.Domain.FilterModels
{
    public interface IMedStaffFilter
    {
        /// <summary>
        /// Gets id of a medStaff.
        /// </summary>
        public long? Id { get; }

        /// <summary>
        /// Gets firstname of a medStaff.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets lastname of a medStaff.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Gets gender of a medStaff.
        /// </summary>
        public Gender? Gender { get; }

        /// <summary>
        /// Gets email of a medStaff.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets phonenumber of a medStaff.
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Gets date of birth of a medStaff.
        /// </summary>
        public int? Age { get; }

        /// <summary>
        /// Gets address of a medStaff.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets current salay of a medStaff.
        /// </summary>
        public decimal? Salary { get; }

        /// <summary>
        /// Gets hospital name where the medStaff works.
        /// </summary>
        public string HospitalName { get; }

        /// <summary>
        /// Gets postal code of the city where medStaff lives.
        /// </summary>
        public string PostalCode { get; }

        /// <summary>
        /// Gets shift of a medStaff [day/night].
        /// </summary>
        public Shift? Shift { get; }
    }
}
