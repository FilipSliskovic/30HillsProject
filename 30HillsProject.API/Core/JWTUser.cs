using _30HillsProject.Domain;

namespace _30HillsProject.API.Core
{
    public class JWTUser : IApplicationUser
    {
        public string Identity { get; set; }

        public int Id { get; set; }

        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>();

        public string Username { get; set; }
    }
}
