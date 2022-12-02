using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGetRetirementInfoService
    {
        /// <summary>
        /// Gets all polices from database who already retired.
        /// </summary>
        public Task<IRetiredPeople> GetRetiredPeopleAsync(int from, int to);
    }
}
