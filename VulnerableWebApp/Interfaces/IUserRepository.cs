using VulnerableWebApp.Models;
using System;

namespace VulnerableWebApp.Interfaces
{
    public interface IRequestRepository : IGenericDataRepository<Request>, IDisposable
    {

    }
}
