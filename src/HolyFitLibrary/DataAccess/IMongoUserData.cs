namespace HolyFitLibrary.DataAccess
{
    public interface IMongoUserData
    {
        Task CreateUser(UserModel user);
        Task UpdateUser(UserModel user);
        Task<UserModel> GetUserAsync(string id);
        Task<UserModel> GetUserFromAuthentication(string objectId);
        Task<List<UserModel>> GetUsersAsync();
        Task UpdateDisplayName(string id, string newDisplayName);
        Task UpdateGoals(string id, string newGoals);
        Task UpdateHeight(string id, int newHeight);
        Task UpdateWeight(string id, int newWeight);
        Task UpdateWorkOutDays(string id, int newWorkOutDays);

    }
}