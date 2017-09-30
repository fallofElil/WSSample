using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WSSample.Models
{
    class Repository
    {
        private static Repository _instance;
        public static Repository Instance { get { return _instance; } }

        private AppData _context;

        public Repository(string connection)
        {
            if (_instance == null)
                _instance = this;

            _context = new AppData(connection);
            Database.SetInitializer(new DataInitializer());
            new Task(() => _context.Database.Initialize(true)).Start();
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            return _context.Profiles;
        }

        public Task<int> SaveUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            return _context.SaveChangesAsync();
        }
    }
}
