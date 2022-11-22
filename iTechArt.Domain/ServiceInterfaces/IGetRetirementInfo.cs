using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGetRetirementInfo
    {
        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public Task<IRetiredPeople> GetRetiredPoliceAsync();
    }
}
