using VulnerableWebApp.Interfaces;
using VulnerableWebApp.Models;
using System;


namespace VulnerableWebApp.Repository
{
    public class RequestRepository : GenericDataRepository<Request>, IRequestRepository
    {
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        ~RequestRepository()
        {
            Dispose(false);
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
