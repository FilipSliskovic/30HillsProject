using _30HillsProject.Domain;

namespace _30HillsProject.API.Core
{
    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Annonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 1, 2, 3, 4, 5, 6 };

        public string Username => "Anonimous@user.com";
    }
}
