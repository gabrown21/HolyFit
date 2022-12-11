namespace HolyFitLibrary.DataAccess
{
    public interface IDbConnection
    {
        MongoClient Client { get; }
        string DbName { get; }
        string UserCollectionName { get; }
        IMongoCollection<UserModel> UserCollection { get; }
    }
}