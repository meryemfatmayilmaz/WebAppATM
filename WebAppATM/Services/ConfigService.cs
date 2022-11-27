using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;
using WebAppATM.Core.Repositories;
using WebAppATM.Core.Services;

namespace WebAppATM.Services
{
	public class ConfigService : IConfigService
	{
		IConfigRepository _configRepository;
		public ConfigService(IConfigRepository configRepository)
		{
			_configRepository = configRepository;
		}

		public List<Config> GetConfigsByType(ConfigType configType)
		{
			return _configRepository.GetConfigsByType(configType);
		}
	}
}
