//talk to mongodb
namespace Catalog.Settings{
    public class MongoDbSettings{
        public string Host {get; set;}

        public int Port {get; set;}

        //easy way to grab the connection string
        public string ConnectionString
         {
            get{
                return $"mongodb://{Host}:{Port}";
             }
        }
    }
}