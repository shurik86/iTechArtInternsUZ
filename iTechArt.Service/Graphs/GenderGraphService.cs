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
            List<IGraph> result = new List<IGraph>();
            result.AddRange(await _graphRepository.GetGroceryGraphData());
            result.AddRange(await _graphRepository.GetPupilsGraphData());
            result.AddRange(await _graphRepository.GetPoliceGraphData());
            result.AddRange(await _graphRepository.GetStudentsGraphData());
            result.AddRange(await _graphRepository.GetMedstaffGraphData());
            return result;
        }
    }
}
