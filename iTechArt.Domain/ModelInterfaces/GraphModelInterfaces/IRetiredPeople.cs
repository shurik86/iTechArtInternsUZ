namespace iTechArt.Domain.ModelInterfaces.GraphModelInterfaces
{
    public interface IRetiredPeople
    {
        /// <summary>
        /// Gets number of retired polices.
        /// </summary>
        public int RetiredPolice { get; }

        /// <summary>
        /// Gets number of retired medstaff.
        /// </summary>
        public int RetiredMedStaff { get; }

        /// <summary>
        /// Gets number of retired groceries.
        /// </summary>
        public int RetiredGrocery { get; }
    }
}
