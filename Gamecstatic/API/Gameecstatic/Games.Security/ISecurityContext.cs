using Games.Data.Model;

namespace Games.Security
{
    public interface ISecurityContext
    {
        bool LoggedIn { get; }
        User User { get; }
        bool IsAdministrator { get; }
    }
}
