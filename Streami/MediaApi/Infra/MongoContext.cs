using MediaApi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MediaApi.Infra
{
    public class MongoContext
    {
        private readonly IMongoDatabase database = null;

        public MongoContext(IOptions<MongoConnectionSettings> settings)
        {
            var client = new MongoClient(settings.Value.String);
            if (client != null)
            {
                this.database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Video> Videos
        {
            get
            {
                return database.GetCollection<Video>("Video");
            }
        }
    }
}
