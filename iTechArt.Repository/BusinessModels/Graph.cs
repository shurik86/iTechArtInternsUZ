using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Repository.BusinessModels
{
    public sealed class Graph:IGraph
    {
        /// <summary>
        /// Gets or sets the table name.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the males count in table.
        /// </summary>
        public int MaleAmount { get; set; }

        /// <summary>
        /// Gets or sets the females count in table.
        /// </summary>
        public int FemaleAmount { get; set; }

        /// <summary>
        /// Gets or sets the average age count of males in table.
        /// </summary>
        public double AverageAgeMale { get; set; }

        /// <summary>
        /// Gets or sets the average age count of females in table.
        /// </summary>
        public double AverageAgeFemale { get; set; }
    }
}
