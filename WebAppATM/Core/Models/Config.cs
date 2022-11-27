using WebAppATM.Core.Enums;

namespace WebAppATM.Core.Models;
public class Config
{
	public Guid Id { get; set; }
	public string Key { get; set; }
	public string Value { get; set; }
	public ConfigType Type { get; set; }
	public Config(string key, string value, ConfigType type)
	{
		Key = key;
		Value = value;
		Type = type;
	}
}