using System.Data.Entity;

namespace WSSample.Models
{
    class AppData : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public AppData(string connection) : base(connection) { }
    }
}
