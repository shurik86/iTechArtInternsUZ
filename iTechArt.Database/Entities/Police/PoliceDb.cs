using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Database.Entities.Police
{
    public sealed class PoliceDb
    {
        /// <summary>
        /// Gets and sets Police Officers Id.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets and sets Police Officers Firstname.
        /// </summary>
        [Required]
        [MaxLength(24)]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets Police Officers Lastname.
        /// </summary>
        [MaxLength(24)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets and sets Police Officers email address.
        /// </summary>
        [MaxLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// Gets and sets Police Officers gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and sets Police Officers address.
        /// </summary>
        [MaxLength(32)]
        public string Address { get; set; }

        /// <summary>
        /// Gets and sets Police Officers job title.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets and sets Police Officers salary in US dollars with 2 double precision.
        /// </summary>
        public double Salary { get; set; }
    }
}
