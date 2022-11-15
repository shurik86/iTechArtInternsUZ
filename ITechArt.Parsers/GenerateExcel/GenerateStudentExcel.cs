using iTechArt.Domain.GenerateExcelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITechArt.Parsers.GenerateExcel
{
    public sealed class GenerateStudentExcel : IGenerateStudentExcel
    {
        public Task<byte[]> GetExcelAsync()
        {
            throw new NotImplementedException();
        }
    }
}
