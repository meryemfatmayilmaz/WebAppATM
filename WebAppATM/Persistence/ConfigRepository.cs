using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;
using WebAppATM.Core.Repositories;

namespace WebAppATM.Persistence
{
	public class ConfigRepository : IConfigRepository
	{
		private readonly AppDbContext _dbCcontext;

		public ConfigRepository(AppDbContext context) => _dbCcontext = context;

		public List<Config> GetConfigsByType(ConfigType configType)
		{
			return _dbCcontext.Configs.Where(x => x.Type == configType).ToList();
		}
	}
}
