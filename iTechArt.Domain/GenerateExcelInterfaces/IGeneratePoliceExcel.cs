using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.GenerateExcelInterfaces
{
    public interface IGeneratePoliceExcel
    {
        /// <summary>
        /// Creates excel file and converts it to memory stream array.
        /// </summary>
        public Task<byte[]> GetExcelAsync();
    }
}
