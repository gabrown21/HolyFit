using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyFitLibrary.DataAccess
{
    /// <summary>
    /// Used to setup a DbConnection to mongo use the styling of the commented code to set up other parts of the database and the connections for them.
    /// </summary>
    public class DbConnection : IDbConnection
    {

        private readonly IConfiguration _config;
        private readonly IMongoDatabase _db;
        private const string _connectionId = "MongoDB"; //references appsettings.json

        public string DbName { get; private set; }
        public string UserCollectionName { get; private set; } = "users";

        public string WorkOutCollectionName {get; private set;} = "workOuts";

        public string WorkOutCollectionDays { get; private set; } = "days";


        public MongoClient Client { get; private set; }

        public IMongoCollection<WorkOutModel> WorkOutCollection {get; private set;}
        public IMongoCollection<DayModel> DayCollection { get; private set; }
        public IMongoCollection<UserModel> UserCollection { get; private set; }


        public DbConnection(IConfiguration config)
        {
            _config = config;
            Client = new MongoClient(_config.GetConnectionString(_connectionId));
            DbName = _config["DatabaseName"];
            _db = Client.GetDatabase(DbName);

            WorkOutCollection = _db.GetCollection<WorkOutModel>(WorkOutCollectionName);
            UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
            DayCollection = _db.GetCollection<DayModel>(WorkOutCollectionDays);

        }

    }
}
