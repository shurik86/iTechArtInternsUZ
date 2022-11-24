using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class GetRetirementInfoService : IGetRetirementInfoService
    {
        private readonly IRetirementRepository _retirementRepository;

        public GetRetirementInfoService(IRetirementRepository retirementRepository)
        {
            _retirementRepository = retirementRepository;
        }


        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredPeopleAsync(int from, int to)
        {
            return await _retirementRepository.GetRetiredPeopleAsync(from, to);
        }
    }
}
