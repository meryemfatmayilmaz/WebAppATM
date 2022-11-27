namespace WebAppATM.Security.Tokens;

public class TokenOptions
{
	public string Audience { get; set; }
	public string Issuer { get; set; }
	public long AccessTokenExpirationMinutes { get; set; }
	public string Secret { get; set; }
}