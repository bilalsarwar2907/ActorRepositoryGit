using ActorRepositoryGit.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ActorRepositoryGit.Repositories
{
    public class ActorRepositoryList
    {

        private readonly List<Actor> _actors = new List<Actor>();

        private int _nextId = 1;

        public ActorRepositoryList()
        {
            // Seed with some initial data
            Add(new Actor { Name = "Leonardo DiCaprio", YearOfBirth = 1974 });
            Add(new Actor { Name = "Meryl Streep", YearOfBirth = 1949 });
            Add(new Actor { Name = "Denzel Washington", YearOfBirth = 1954 });
        }

        public IEnumerable<Actor> GetAll()
        {
            return _actors;
        }

        public Actor? GetById(int id)
        {
            return _actors.FirstOrDefault(actor => actor.Id == id);
        }
        public Actor? Add(Actor actor)
        {
            if (actor == null)
                return null;

            actor.Id = _nextId++;
            _actors.Add(actor);
            return actor;
        }
        public Actor? Update(int id, Actor data)
        { 

var exisitingactor = GetById(id);
            if (exisitingactor != null)
            {
                exisitingactor.Name = data.Name;
                exisitingactor.YearOfBirth = data.YearOfBirth;
               
            }
            return exisitingactor;
        }
        public Actor? Delete(int id)
        {
            var actorToDelete = GetById(id);

            if (actorToDelete == null)
                return null;
            _actors.Remove(actorToDelete);
            return actorToDelete;
        }

        public IEnumerable<Actor> Get(int? birthYearBefore)
        {

            if (birthYearBefore == null)
                return _actors;

            return _actors.Where(actor => actor.YearOfBirth < birthYearBefore);

        }
        public IEnumerable<Actor> Get(int? birthYearBefore, int?birthYearAfter)
        {

            if (birthYearBefore == null && birthYearAfter == null)
                        return _actors;

        }
    }

    }

