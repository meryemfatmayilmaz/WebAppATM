namespace WebAppATM.Shared;

public class Constants
{
	private const int DefaultLength = 75;

	public class User
	{
		public const int UsernameLength = 255;
		public const int PlainPassword = 32;
	}

	public class Config
	{
		public class Email
		{
			public class Keys
			{
				public const string Address = "Address";
				public const string DisplayName = "DisplayName";
				public const string Host = "Host";
				public const string Username = "Username";
				public const string Password = "Password";
				public const string Port = "Port";
				public const string UseSsl = "UseSsl";
			}
		}
	}
}
