using LibMgmtSys.Models;
using System.Data.Entity;

namespace LibMgmtSys.DAL
{
    public class LMSContext : DbContext
    {
        public LMSContext() : base("DbConnectionString")
        {

        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Book> Books { get; set; }
    }
}
