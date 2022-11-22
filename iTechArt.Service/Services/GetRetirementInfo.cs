using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class GetRetirementInfo : IGetRetirementInfo
    {
        private readonly IRetirementRepository _retirementRepository;

        public GetRetirementInfo(IRetirementRepository retirementRepository)
        {
            _retirementRepository = retirementRepository;
        }


        /// <summary>
        /// Gets all polices from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredPoliceAsync()
        {
            return await _retirementRepository.GetRetiredPolicesAsync();
        }
    }
}
