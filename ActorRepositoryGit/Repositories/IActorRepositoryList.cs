using ActorRepositoryGit.Models;

namespace ActorRepositoryGit.Repositories
{
    public interface IActorRepositoryList
    {
        Actor? Add(Actor actor);
        Actor? Delete(int id);
        IEnumerable<Actor> Get(int? birthYearBefore);
        IEnumerable<Actor> Get(int? birthYearBefore, int? birthYearAfter);
        IEnumerable<Actor> Get(int? birthYearBefore, int? birthYearAfter, string? nameContains);
        IEnumerable<Actor> Get(int? birthYearBefore, string? nameContains);
        IEnumerable<Actor> Get(string? nameContains);
        IEnumerable<Actor> GetAll();
        IEnumerable<Actor> GetAll(string? sortBy = null, bool descending = false);
        Actor? GetById(int id);
        Actor? Update(int id, Actor data);
    }
}