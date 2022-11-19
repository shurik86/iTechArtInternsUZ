﻿using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IRetirementRepository
    {
        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public Task<IRetiredPeople> GetRetiredPolicesAsync();
    }
}