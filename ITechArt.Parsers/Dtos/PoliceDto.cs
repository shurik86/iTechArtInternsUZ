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
        /// Gets and sets Police Officers Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets and sets Police Officers Firstname.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets Police Officers Lastname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets and sets Police Officers email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets and sets Police Officers gender.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets and sets Police Officers address.
        /// </summary>
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
