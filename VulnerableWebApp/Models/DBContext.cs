using Microsoft.EntityFrameworkCore;

namespace VulnerableWebApp.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {            
            
        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(Constants.DatabaseUtils.SQL_CONNECTION_STRING);
        }


        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Request> Request { get; set; }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        ~DBContext()
        {
            Dispose(false);
        }

        public new void Dispose()
        {
            Dispose(true);          
        }


        #endregion

    }
}