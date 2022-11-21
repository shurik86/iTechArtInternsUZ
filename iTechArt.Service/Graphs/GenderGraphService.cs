using iTechArt.Domain.ModelInterfaces;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;

namespace iTechArt.Service.Graphs
{
    public sealed class GenderGraphService:IGenderGraphService
    {
        IGraphRepository _graphRepository;
        public GenderGraphService(IGraphRepository graphRepository)
        {
            _graphRepository = graphRepository;
        }
        /// <summary>
        /// Collects tables names count of males and females for tables data into one collection.
        /// </summary>
        public async Task<List<IGraph>> GetGraphDataAsync() 
        {
            var result = new List<IGraph>();
            result.Add(await _graphRepository.GetGroceryGraphDataAsync());
            result.Add(await _graphRepository.GetPupilsGraphDataAsync());
            result.Add(await _graphRepository.GetPoliceGraphDataAsync());
            result.Add(await _graphRepository.GetStudentsGraphDataAsync());
            result.Add(await _graphRepository.GetMedstaffGraphDataAsync());
            return result;
        }
    }
}
