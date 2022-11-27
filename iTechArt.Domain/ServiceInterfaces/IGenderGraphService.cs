using iTechArt.Domain.ModelInterfaces;

namespace iTechArt.Domain.ServiceInterfaces
{
    public interface IGenderGraphService
    {
        /// <summary>
        /// Table names, count of males and females for 5 tables such as grocery,police, staff,pupil, and students.
        /// </summary>
        public Task<List<IGraph>> GetGraphDataAsync();
    }
}
