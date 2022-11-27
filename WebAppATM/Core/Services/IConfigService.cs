using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;

namespace WebAppATM.Core.Services
{
	public interface IConfigService
	{
		List<Config> GetConfigsByType(ConfigType configType);
	}
}
