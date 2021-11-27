using MongoDB.Driver;
using MongoNet6NOGIT.Interfaces;
using MongoNet6NOGIT.Models;

namespace MongoNet6NOGIT.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUsersDatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollection);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            user.Id = String.Empty;
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userObj) =>
            _users.ReplaceOne(user => user.Id == id, userObj);

        public void Remove(User userObj) =>
            _users.DeleteOne(user => user.Id == userObj.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);
    }
}
