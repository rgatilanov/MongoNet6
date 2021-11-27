using MongoNet6NOGIT.Interfaces;

namespace MongoNet6NOGIT.Models
{
    public class UsersDatabaseSettings: IUsersDatabaseSetting
    {
        public string UsersCollection { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
