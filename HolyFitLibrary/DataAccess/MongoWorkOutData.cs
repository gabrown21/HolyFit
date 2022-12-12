using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolyFitLibrary.DataAccess
{
    public class MongoWorkOutData
    {
        private readonly IMongoCollection<WorkOutModel> _users;
        public MongoWorkOutData(IDbConnection db)
        {
            //_users = db.UserCollection;
        }



    }
}