using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoExample.Services;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repos
{
    public class ConfigData : IConfigData
    {

        private readonly IMongoCollection<ConfigModel> _configCollection;


        public ConfigData(IOptions<MongoDBSettingsModel> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _configCollection = database.GetCollection<ConfigModel>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<ICollection<ConfigModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _configCollection.Find(new BsonDocument()).ToListAsync(cancellationToken);
        }


        public async Task<ConfigModel> GetOneAsync(CancellationToken cancellationToken, string Id)
        {
            return await _configCollection.Find(f => f.Id == Id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddToConfigAsync(CancellationToken cancellationToken, ConfigModel configModel)
        {
            await _configCollection.InsertOneAsync(configModel);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, ConfigModel configModel)
        {
            await _configCollection.ReplaceOneAsync(f => f.Id == configModel.Id, configModel, cancellationToken: cancellationToken);
            return;
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, string Id)
        {
            await _configCollection.DeleteOneAsync(f => f.Id == Id, cancellationToken: cancellationToken);
            return;
        }

        public async Task DeprecateAsync(CancellationToken cancellationToken, string Id)
        {
            var Result = await _configCollection.Find(f => f.Id == Id).FirstOrDefaultAsync(cancellationToken);
            bool IsDepreacted = Result.Deprecated ? false : true;
            Result.Deprecated = IsDepreacted;

            await _configCollection.ReplaceOneAsync(f => f.Id == Id, Result, cancellationToken: cancellationToken);

            return;
        }
    }
}
