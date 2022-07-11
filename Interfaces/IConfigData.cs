using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IConfigData
    {
        public Task<ICollection<ConfigModel>> GetAllAsync(CancellationToken cancellationToken);
        public Task<ConfigModel> GetOneAsync(CancellationToken cancellationToken, string Id);
        public Task UpdateAsync(CancellationToken cancellationToken, ConfigModel configModel);
        public Task AddToConfigAsync(CancellationToken cancellationToken, ConfigModel configModel);
        public Task DeleteAsync(CancellationToken cancellationToken, string Id);
        public Task DeprecateAsync(CancellationToken cancellationToken, string Id);

    }
}
