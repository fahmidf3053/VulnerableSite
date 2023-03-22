using VulnerableWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace VulnerableWebApp.Interfaces
{
    public interface IDataAccessService
    {
        IQueryable<User> GetAllUsers();
        User GetUserById(int userId);
        void UpdateUsers(params User[] users);
        void AddUsers(params User[] users);
        void DeleteUsers(params User[] users);

        IQueryable<Request> GetAllRequests();
        Request GetRequestById(int requestId);
        void UpdateRequests(params Request[] requests);
        void AddRequests(params Request[] requests);
        void DeleteRequests(params Request[] requests);

    }
}