﻿using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IPoliceService
    {
        /// <summary>
        /// function to imports data to the database
        /// </summary>
        public IPolice[] ImportPoliceData();

        /// <summary>
        /// function to exports data from the database
        /// </summary>
        public IPolice[] ExportPoliceData();
    }
}
