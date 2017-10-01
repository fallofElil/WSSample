using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WSSample.Models
{
    class Repository
    {
        private static Repository _instance;
        public static Repository Instance { get { return _instance; } }

        private AppData _context;

        public event EventHandler DataInitialized;

        public Repository(string connection)
        {
            if (_instance == null)
                _instance = this;

            _context = new AppData(connection);
        }

        public void InitDataAsync()
        {
            if (Environment.GetEnvironmentVariable("env") != "production")
                Database.SetInitializer(new DataInitializer());

            Task init = new Task(() =>
            {
                _context.Database.Initialize(true);
                DataInitialized(this, new EventArgs());
            });
            init.Start();
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
