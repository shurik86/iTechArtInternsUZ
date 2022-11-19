using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Database.Entities.Police
{
    public sealed class PoliceDb
    {
        /// <summary>
        /// Gets and sets police officers id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets and sets Police Officers Firstname.
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets police officers lastname.
        /// </summary>
        [MaxLength(32)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets and sets police officers email address.
        /// </summary>
        [MaxLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// Gets and sets police officers gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and sets police officers address.
        /// </summary>
        [MaxLength(32)]
        public string Address { get; set; }

        /// <summary>
        /// Gets and sets police officers job title.
        /// </summary>
        [MaxLength(32)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets and sets police officers salary in us dollars with 2 double precision.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Gets and sets birthdate of police officer.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}