namespace WebAppATM.Core.Repositories.Dtos
{
	public class ConfigDto
	{
		public string Key { get; set; }
		public int Port { get; set; }
		public string Value { get; set; }
		public string Type { get; set; }
		public bool State { get; set; }
	}
}
