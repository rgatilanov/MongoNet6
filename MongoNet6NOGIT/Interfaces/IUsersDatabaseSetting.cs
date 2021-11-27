namespace MongoNet6NOGIT.Interfaces
{
    public interface IUsersDatabaseSetting
    {
        string UsersCollection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
