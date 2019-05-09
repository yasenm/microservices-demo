using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Messaging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Data;
using UsersApi.Data.Model;

namespace UsersApi.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDbContext db;
        private readonly IMessagePublisher messagePublisher;

        public UserService(UsersDbContext db, IMessagePublisher messagePublisher)
        {
            this.db = db;
            this.messagePublisher = messagePublisher;
        }

        public async Task<bool> AddOrUpdate<T>(T user)
        {
            try
            {
                var newUser = Mapper.Map<ApplicationUser>(user);

                if (!this.db.Users.Any(x => x.Id == newUser.Id))
                {
                    await this.db.Users.AddAsync(newUser);
                    await this.db.SaveChangesAsync();

                    this.messagePublisher.PublishMessageAsync("NewUser", newUser, "users.add").Wait();
                }
                else
                {
                    this.db.Users.Update(newUser);
                    await this.db.SaveChangesAsync();

                    this.messagePublisher.PublishMessageAsync("UpdateUser", newUser, "users.update").Wait();
                }
            }
            catch (Exception e)
            {
                this.messagePublisher.PublishMessageAsync("AddOrUpdateUserError", e, "users.error").Wait();
                Log.Error("AddOrUpdateUserError: {0}", e.Message);
                return false;
            }

            return true;
        }

        public T Get<T>(string id)
        {
            var user = this.db.Users.Where(x => x.Id == id).ProjectTo<T>().FirstOrDefault();
            return user;
        }

        public IEnumerable<T> Get<T>()
        {
            var users = this.db.Users.ProjectTo<T>();
            return users;
        }
    }
}
