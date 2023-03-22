using static VulnerableWebApp.Constants;

namespace VulnerableWebApp.Interfaces
{

    public interface IEntity
    {
        EntityState EntityState { get; set; }
    }
}
