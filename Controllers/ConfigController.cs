using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("ApiController")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigData _configData;
        private readonly ILogger<ConfigController> _logger;

        public ConfigController(ILogger<ConfigController> logger, IConfigData configData)
        {
            _logger = logger;
            _configData = configData;

        }

        [HttpGet("GetConfigData")]
        public async Task<ICollection<ConfigModel>> GetConfigs(CancellationToken cancellationToken)
        {
            try
            {
                return await _configData.GetAllAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        [HttpGet("GetOneConfigData")]
        public async Task<ConfigModel> GetConfig(CancellationToken cancellationToken, string Id)
        {
            try
            {
                return await _configData.GetOneAsync(cancellationToken, Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        [HttpPost("AddData")]
        public async Task<ConfigModel> AddConfig(CancellationToken cancellationToken, ConfigModel configModel)
        {
            try
            {
                await _configData.AddToConfigAsync(cancellationToken, configModel);
                return new ConfigModel();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("UpdateData")]
        public async Task<ConfigModel> UpdateConfig(CancellationToken cancellationToken, ConfigModel configModel)
        {
            try
            {
                await _configData.UpdateAsync(cancellationToken, configModel);
                return new ConfigModel();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }


        [HttpDelete("DeleteData")]
        public async Task<IActionResult> Delete(CancellationToken cancellationToken, string Id)
        {
            try
            {
                await _configData.DeleteAsync(cancellationToken, Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }

        [HttpGet("DeprecateData")]
        public async Task<IActionResult> Deprecate(CancellationToken cancellationToken, string Id)
        {
            try
            {
                await _configData.DeprecateAsync(cancellationToken, Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }

        }
    }
}
