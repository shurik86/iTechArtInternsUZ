using iTechArt.Domain.Enums;

namespace iTechArt.Domain.ModelInterfaces
{
    public interface IPolice
    {
        /// <summary>
        /// Gets police officer's id.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets police officer's firstname.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets police officer's lastname.
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Gets police officer's email address.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets police Officer's gender.
        /// </summary>
        public Gender Gender { get; }

        /// <summary>
        /// Gets police officer's address.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets police officer's job title.
        /// </summary>
        public string JobTitle { get; }

        /// <summary>
        /// Gets police officers salary in us dollars with 2 double precision.
        /// </summary>
        public double Salary { get; }

        /// <summary>
        /// Gets birthdate of police officer.
        /// </summary>
        public DateTime BirthDate { get; }
    }
}
