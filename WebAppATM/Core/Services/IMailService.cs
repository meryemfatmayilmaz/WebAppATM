using WebAppATM.Core.Repositories.Dtos;

namespace WebAppATM.Core.Services
{
	public interface IMailService
	{
		Task SendEmailAsync(EmailDto request);
	}
}
