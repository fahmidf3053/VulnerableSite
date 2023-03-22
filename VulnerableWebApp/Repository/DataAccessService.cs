using System;
using System.Data;
using System.Linq;
using VulnerableWebApp.Interfaces;
using VulnerableWebApp.Models;

namespace VulnerableWebApp.Repository
{
    public class DataAccessService : IDataAccessService, IDisposable
    {
        private readonly IUserRepository _userRepository;
        private readonly IRequestRepository _requestRepository;
        

        public DataAccessService()
        {
            _userRepository = new UserRepository();
            _requestRepository = new RequestRepository();
        }


        public IQueryable<User> GetAllUsers() {
            return _userRepository.GetAll();
        }     

        public User GetUserById(int userId) {
            return _userRepository.GetAll().Where(x => x.UserId == userId).FirstOrDefault();
        }

        public void UpdateUsers(params User[] users) {
            _userRepository.Update(users);
        }

        public void AddUsers(params User[] users)
        {
            _userRepository.Add(users);
        }

        public void DeleteUsers(params User[] users)
        {
            _userRepository.Remove(users);
        }


        public IQueryable<Request> GetAllRequests()
        {
            return _requestRepository.GetAll();
        }

        public Request GetRequestById(int requestId)
        {
            return _requestRepository.GetAll().Where(x => x.Id == requestId).FirstOrDefault();
        }

        public void UpdateRequests(params Request[] requests)
        {
            _requestRepository.Update(requests);
        }

        public void AddRequests(params Request[] requests)
        {
            _requestRepository.Add(requests);
        }

        public void DeleteRequests(params Request[] requests)
        {
            _requestRepository.Remove(requests);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _userRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
