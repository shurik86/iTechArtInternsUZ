using iTechArt.Domain.ModelInterfaces;
namespace iTechArt.Domain.RepositoryInterfaces
{
    public interface IGraphRepository
    {
        public Task<List<IGraph>> GetGroceryGraphData();
        public Task<List<IGraph>> GetPupilsGraphData();
        public Task<List<IGraph>> GetStudentsGraphData();
        public Task<List<IGraph>> GetMedstaffGraphData();
        public Task<List<IGraph>> GetPoliceGraphData();
    }
}
