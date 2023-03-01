//talk to mongodb
namespace Catalog.Settings{
    public class MongoDbSettings{

        //stuff that gets populated into app
        public string Host {get; set;}

        public int Port {get; set;}

        public string User {get; set;}

        public string Password {get; set;}

        //easy way to grab the connection string
        public string ConnectionString
         {
            get{
                return $"mongodb://{User}:{Password}@{Host}:{Port}";
             }
        }
    }
}