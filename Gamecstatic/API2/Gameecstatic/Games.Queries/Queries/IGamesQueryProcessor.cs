using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.API.Models.Games;
using Games.Data.Model;

namespace Games.Queries.Queries
{
    public interface IGamesQueryProcessor
    {
        IQueryable<Game> Get();
        Game Get(int id);
        byte[] GetGameIndex(int id);
        AdditionalGameFile GetAdditionalFile(int id, string path);
        Task<Game> Create(CreateGameModel model);
        Task Delete(int id);
        IQueryable<Tag> GetTags();
        IQueryable<Category> GetCategories();
        public IQueryable<Game> FilterGameQuery(string searchTerm, string sortBy, List<int> tags, List<int> categories);
    }
}