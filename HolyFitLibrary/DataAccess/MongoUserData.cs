using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyFitLibrary.DataAccess
{
    public class MongoUserData : IMongoUserData
    {
        private readonly IMongoCollection<UserModel> _users;
        public MongoUserData(IDbConnection db)
        {
            _users = db.UserCollection;
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var results = await _users.FindAsync(_ => true); //Means Find them all
            return results.ToList();
        }

        public async Task<UserModel> GetUserAsync(string id)
        {
            var results = await _users.FindAsync(u => u.Id == id);
            return results.FirstOrDefault();
        }

        public async Task<UserModel> GetUserFromAuthentication(string objectId)
        {
            var results = await _users.FindAsync(u => u.ObjectIdentifier.Equals(objectId));//maybe?
            return results.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return _users.InsertOneAsync(user);
        }
        public Task UpdateWeight(string id, int newWeight)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", id);
            var results = Builders<UserModel>.Update.AddToSet("Weight", newWeight);
            return _users.UpdateOneAsync(filter, results);

        }
        public Task UpdateHeight(string id, int newHeight)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", id);
            var results = Builders<UserModel>.Update.AddToSet("Height", newHeight);
            return _users.UpdateOneAsync(filter, results);

        }
        public Task UpdateGoals(string id, string newGoals)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", id);
            var results = Builders<UserModel>.Update.AddToSet("Goals", newGoals);
            return _users.UpdateOneAsync(filter, results);

        }
        public Task UpdateWorkOutDays(string id, int newWorkOutDays)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", id);
            var results = Builders<UserModel>.Update.AddToSet("DaysToWorkOut", newWorkOutDays);
            return _users.UpdateOneAsync(filter, results);

        }
        public Task UpdateDisplayName(string id, string newDisplayName)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", id);
            var results = Builders<UserModel>.Update.AddToSet("DisplayName", newDisplayName);
            return _users.UpdateOneAsync(filter, results);
        }
        public Task UpdateUser(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
            return _users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true }); //Add object if not found otherwise update the object with the new user
        }

    }
}
