using System.Data.Entity;
using System;

using RandomNameGeneratorLibrary;

namespace WSSample.Models
{
    class DataInitializer : DropCreateDatabaseAlways<AppData>
    {
        private PersonNameGenerator nameGenerator = new PersonNameGenerator();
        private Random numberGenerator = new Random();

        protected override void Seed(AppData context)
        {
            for (int i = 0; i < 100; i++)
            {
                string[] name = nameGenerator.GenerateRandomMaleFirstAndLastName().Split(' ');
                int age = numberGenerator.Next(18, 48);

                context.Users.Add(new User
                {         
                    Email = $"{name[0]}@mail.com",
                    UserName = name[0],
                    Profile = new Profile
                    {
                        UserId = i,
                        FirstName = name[0],
                        LastName = name[1],
                        Age = age
                    }
                });  
            }

            context.SaveChanges();
        }
    }
}
