using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.ModelInterfaces.GraphModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Services
{
    public sealed class GetRetirementInfoService : IGetRetirementInfo
    {
        private readonly IRetirementRepository _retirementRepository;

        public GetRetirementInfoService(IRetirementRepository retirementRepository)
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

        /// <summary>
        /// Gets all medstaffs from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredMedStaffsAsync()
        {
            return await _retirementRepository.GetRetiredMedStaffAsync();
        }

        /// <summary>
        /// Gets all groceries from database who already retired
        /// </summary>
        public async Task<IRetiredPeople> GetRetiredGroceriesAsync()
        {
            return await _retirementRepository.GetRetiredGroceriesAsync();
        }
    }
}
