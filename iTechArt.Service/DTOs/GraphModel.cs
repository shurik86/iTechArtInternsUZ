using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.DTOs
{
    public sealed class GraphModel
    {
        public string Unit { get; set; }
        public int Male { get; set; }
        public int Female { get; set; }
        public int AverageAgeMale { get; set; }
        public int AverageAgeFemale { get; set; }

    }
}
