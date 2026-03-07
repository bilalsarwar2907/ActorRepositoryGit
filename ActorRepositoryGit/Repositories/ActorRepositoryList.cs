using ActorRepositoryGit.Models;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ActorRepositoryGit.Repositories
{
    public class ActorRepositoryList : IActorRepositoryList
    {
        /// <summary>
        /// ////// In-memory list to store actors. This simulates a database for the purpose of this example.
        /// </summary>
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
        public IEnumerable<Actor> Get(int? birthYearBefore, int? birthYearAfter)
        {

            if (birthYearBefore == null && birthYearAfter == null)
            {
                //If only birthYearBefore has value → return actors with birth year less than that value
                return _actors;
            }
            //If both have values → return actors with birth year between after and before (after < year < before)
            if (birthYearBefore.HasValue && birthYearAfter.HasValue)
            {
                return _actors.Where(actor => actor.YearOfBirth < birthYearBefore.Value && actor.YearOfBirth > birthYearAfter.Value);
            }
            if (birthYearBefore.HasValue)
            {
                return _actors.Where(actor => actor.YearOfBirth < birthYearBefore.Value);
            }
            //If only birthYearAfter has value → return actors with birth year greater than that value

            if (birthYearAfter.HasValue)
            {
                return _actors.Where(actor => actor.YearOfBirth > birthYearAfter.Value);
            }
            return _actors;
        }
        public IEnumerable<Actor> Get(string? nameContains)
        {
            // Return all actors if nameContains is null or empty
            if (nameContains == null || nameContains.Trim() == "")
                return _actors;

            // Otherwise filter by name (case-insensitive, contains)
            return _actors.Where(actor => actor.Name != null && actor.Name.Contains(nameContains, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<Actor> Get(int? birthYearBefore, string? nameContains)
        {
            IEnumerable<Actor> result = _actors;

            if (birthYearBefore.HasValue)
            {
                result = result.Where(actor => actor.YearOfBirth < birthYearBefore.Value);

            }

            if (!string.IsNullOrWhiteSpace(nameContains))
            {
                result = result.Where(actor => actor.Name != null && actor.Name.Contains(nameContains, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
        public IEnumerable<Actor> Get(int? birthYearBefore, int? birthYearAfter, string? nameContains)
        {
            IEnumerable<Actor> result = _actors;

            if (birthYearBefore.HasValue)
            {
                result = result.Where(actor => actor.YearOfBirth < birthYearBefore.Value);
            }

            if (birthYearAfter.HasValue)
            {
                result = result.Where(actor => actor.YearOfBirth > birthYearAfter.Value);
            }

            if (!string.IsNullOrWhiteSpace(nameContains))
            {
                result = result.Where(actor => actor.Name != null && actor.Name.Contains(nameContains, StringComparison.OrdinalIgnoreCase));

            }
            return result;

        }
        public IEnumerable<Actor> GetAll(string? sortBy = null, bool descending = false)
        {
            IEnumerable<Actor> result = _actors;

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "id":
                        result = descending
                            ? result.OrderByDescending(actor => actor.Id)
                            : result.OrderBy(actor => actor.Id);
                        break;
                    case "name":
                        result = descending
                            ? result.OrderByDescending(actor => actor.Name)
                            : result.OrderBy(actor => actor.Name);
                        break;
                    case "birthyear":
                        result = descending
                            ? result.OrderByDescending(actor => actor.YearOfBirth)
                            : result.OrderBy(actor => actor.YearOfBirth);
                        break;
                    default:
                        // No sorting or default
                        break;
                }
            }

            return result;
        }
    }
}



