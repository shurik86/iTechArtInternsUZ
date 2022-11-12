using iTechArt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.Database.Entities.Police
{
    public sealed class PoliceDb
    {
        /// <summary>
        /// Gets and Sets Police Officers Id.
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers Firstname.
        /// </summary>
        [Required]
        [MaxLength(24)]
        public string Name { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers Lastname.
        /// </summary>
        [MaxLength(24)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers email address.
        /// </summary>
        [MaxLength(32)]
        public string Email { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers address.
        /// </summary>
        [MaxLength(32)]
        public string Address { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers job title.
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets and Sets Police Officers salary in US dollars with 2 double precision.
        /// </summary>
        public double Salary { get; set; }
    }
}
