using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
//using System.Net.Mail;
using WebAppATM.Core.Enums;
using WebAppATM.Core.Repositories;
using WebAppATM.Core.Repositories.Dtos;
using WebAppATM.Core.Services;
using static WebAppATM.Shared.Constants;

namespace WebAppATM.Services;

public class MailService : IMailService
{
	private readonly IConfiguration _configuration;
	IConfigService _configService;
	private readonly IUnitOfWork _unitOfWork;

	public MailService(IConfigService configService, IConfiguration configuration, IUnitOfWork unitofWork)
	{
		_configService = configService;
		_configuration = configuration;
		_unitOfWork = unitofWork;
	}
	public async Task SendEmailAsync(EmailDto request)
	{
		var emailConfigs = _configService.GetConfigsByType(ConfigType.Email).ToDictionary(x => x.Key, x => x.Value);

		var address = emailConfigs[Config.Email.Keys.Address];
		var displayName = emailConfigs[Config.Email.Keys.DisplayName];
		var host = emailConfigs[Config.Email.Keys.Host];
		var username = emailConfigs[Config.Email.Keys.Username];
		var password = emailConfigs[Config.Email.Keys.Password];
		_ = int.TryParse(emailConfigs[Config.Email.Keys.Port] ?? "0", out int port);
		var useSsl = emailConfigs[Config.Email.Keys.UseSsl] == "1";

		var email = new MimeMessage();
		email.From.Add(MailboxAddress.Parse(address));
		email.To.Add(MailboxAddress.Parse(request.To));
		email.Subject = request.Subject;
		email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

		using var smtp1 = new SmtpClient();
		smtp1.Connect(host, port, SecureSocketOptions.StartTls);
		smtp1.Authenticate(username, password);
		smtp1.Send(email);
		smtp1.Disconnect(true);
	}
}
