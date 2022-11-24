using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Repository.BusinessModels.GraphModels
{
    internal sealed class RetiredPeople : IRetiredPeople
    {
        /// <summary>
        /// Gets and internal sets number for year 1980 to 1984.
        /// </summary>
        public int Y1980to84 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 1985 to 1989.
        /// </summary>
        public int Y1985to89 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 1990 to 1994.
        /// </summary>
        public int Y1990to94 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 1995 to 1999.
        /// </summary>
        public int Y1995to99 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 2000 to 2004.
        /// </summary>
        public int Y2000to04 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 2005 to 2009.
        /// </summary>
        public int Y2005to09 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 2010 to 2014.
        /// </summary>
        public int Y2010to14 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 2015 to 2019.
        /// </summary>
        public int Y2015to19 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 2020 to 2021.
        /// </summary>
        public int Y2020to21 { get; internal set; }

        /// <summary>
        /// Gets and internal sets number for year 2022.
        /// </summary>
        public int Y2022 { get; internal set; }
    }
}
