using Games.Data.Model;

namespace Games.Security
{
    public interface ISecurityContext
    {
        User User { get; }
        bool IsAdministrator { get; }
    }
}
