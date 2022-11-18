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
        public async Task<List<IGraph>> GetGraphData() 
        {
            var result = new List<IGraph>();
            result.Add(await _graphRepository.GetGroceryGraphData());
            result.Add(await _graphRepository.GetPupilsGraphData());
            result.Add(await _graphRepository.GetPoliceGraphData());
            result.Add(await _graphRepository.GetStudentsGraphData());
            result.Add(await _graphRepository.GetMedstaffGraphData());
            return result;
        }
    }
}
