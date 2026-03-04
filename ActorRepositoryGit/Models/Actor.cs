namespace ActorRepositoryGit.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;

        public int YearOfBirth { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, YearOfBirth: {YearOfBirth}";
        }

    }
}
