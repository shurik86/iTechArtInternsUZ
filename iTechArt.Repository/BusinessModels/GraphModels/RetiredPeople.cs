using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;


namespace iTechArt.Repository.BusinessModels.GraphModels
{
    internal sealed class RetiredPeople : IRetiredPeople
    {
        /// <summary>
        /// Gets and internal sets number of retired polices.
        /// </summary>
        public int RetiredPolice { get; internal set; }

        /// <summary>
        /// Gets and internal sets number of retired medstaff.
        /// </summary>
        public int RetiredMedStaff { get; internal set; }

        /// <summary>
        /// Gets and internal sets number of retired groceries.
        /// </summary>
        public int RetiredGrocery { get; internal set; }
    }
}
