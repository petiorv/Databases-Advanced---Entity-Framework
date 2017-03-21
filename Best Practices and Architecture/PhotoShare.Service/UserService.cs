using System;
using System.Collections.Generic;
namespace PhotoShare.Service
{
    using PhotoShare.Models;

    public class UserService
    {
        public virtual void Add(string username, string password, string email)
        {
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                //TODO: Check for username
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
