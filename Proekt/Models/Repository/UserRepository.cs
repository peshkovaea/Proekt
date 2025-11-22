using Proekt.Domain;
using Proekt.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt.Models.Repository
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User user)
        {
            try
            {
                using var context = new MyDatabaseContext();
                context.Update(user);
                context.SaveChanges();
            }
            catch
            {
                //Логгирование
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    context.Remove(user);
                    context.SaveChanges();
                }
            }
            catch { }
        }
        public void Update(int id, User user)
        {
            try
            {
                using var context = new MyDatabaseContext();
                var _userInDb = context.Users.FirstOrDefault(x => x.Id == id);
                if (_userInDb != null && _userInDb.Id == id)
                {
                    _userInDb.Information = user.Information;
                    _userInDb.Rating = user.Rating;
                    _userInDb.Phone = user.Phone;
                    _userInDb.Username = user.Username;
                    ///Либо так, помечаем самостоятельно
                    //context.Entry(_userInDb).State = EntityState.Modified;
                    //Либо оставляем это контексту
                    context.Update(_userInDb);
                    context.SaveChanges();
                }
            }
            catch { }
        }

        public User? Find(Predicate<User> predicate)
        {
            using var context = new MyDatabaseContext();
            return context.Users.FirstOrDefault(u => predicate(u));
        }
        public User? Get(int id)
        {
            using var context = new MyDatabaseContext();
            return context.Users.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<User> GetAll()
        {
            using var context = new MyDatabaseContext();
            return [.. context.Users];
        }

    }
}
