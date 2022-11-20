using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    internal sealed class Police : IPolice
    {
        /// <summary>
        /// Gets and internal sets police Officer's id.
        /// </summary>
        public long Id { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's firstname.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's lastname.
        /// </summary>
        public string Surname { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's email address.
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's gender.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's address.
        /// </summary>
        public string Address { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's job title.
        /// </summary> 
        public string JobTitle { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's salary in us dollars with 2 double precision.
        /// </summary>
        public double Salary { get; internal set; }

        /// <summary>
        /// Gets and internal sets police officer's birthdate.
        /// </summary>
        public DateTime BirthDate { get; internal set; }
    }
}
