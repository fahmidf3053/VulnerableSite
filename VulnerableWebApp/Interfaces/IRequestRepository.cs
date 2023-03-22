using VulnerableWebApp.Models;
using System;

namespace VulnerableWebApp.Interfaces
{
    public interface IUserRepository : IGenericDataRepository<User>, IDisposable
    {

    }
}
