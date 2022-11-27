using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;

namespace WebAppATM.Core.Repositories
{
	public interface IConfigRepository
	{
		List<Config> GetConfigsByType(ConfigType configType);
	}
}
