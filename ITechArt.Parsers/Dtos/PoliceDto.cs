using iTechArt.Domain.Enums;
using iTechArt.Domain.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.Dtos
{
    public sealed class PoliceDto : IPolice
    {
        /// <summary>
        /// Gets and sets police officer's id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets and sets police officer's firstname.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets police officer's lastname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets and sets police officer's email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets and sets police officer's gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and sets police officer's address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets and sets police officer's job title.
        /// </summary> 
        public string JobTitle { get; set; }

        /// <summary>
        /// Gets and sets police officer's salary in us dollars with 2 double precision.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Gets and sets police officer's birthdate.
        /// </summary>
        public DateTime BirthDate { get; set; }
    }
}
