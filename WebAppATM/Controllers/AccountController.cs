using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppATM.Core.Repositories.Dtos;
using WebAppATM.Core.Services;
using WebAppATM.Core.Services.Communication;
using WebAppATM.Extensions;

namespace WebAppATM.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
	IAccountTransactionService _accountTransactionService;
	IUserService _userService;
	IMailService _mailService;

	public AccountController(IUserService userService, IAccountTransactionService accountTransactionService, IMailService mailService)
	{
		_accountTransactionService = accountTransactionService;
		_userService = userService;
		_mailService = mailService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAccountBalanceInformation()
	{
		var currentUserId = (await _userService.FindByUsernameAsync(HttpContext.User.GetUsername())).Id;
		var result = await _accountTransactionService.SumOfQuantityAsync(currentUserId);
		return Ok(result);
	}
	[HttpPost("depositTransaction")]
	public async Task<IActionResult> DepositTransaction(decimal quantity)
	{
		var currentUser = (await _userService.FindByUsernameAsync(HttpContext.User.GetUsername()));
		var result = await _accountTransactionService
			.DepositAsync(new DepositTransactionRequest()
			{
				Date = DateTime.Now,
				Quantity = quantity,
				UserId = currentUser.Id
			});
		if (!result.Success)
		{
			return BadRequest(result.Message);
		}

		await _mailService.SendEmailAsync(new EmailDto()
		{
			Body = "Para yatırma İşlemi",
			Subject = "Para Yatırma",
			To = currentUser.Email
		});

		return Ok(result.Message);
	}

	[HttpPost("withdrawalTransaction")]
	public async Task<IActionResult> WithdrawalTransaction(decimal quantity)
	{
		var currentUser = (await _userService.FindByUsernameAsync(HttpContext.User.GetUsername()));
		var result = await _accountTransactionService
			.WithdrawalAsync(new WithdrawalTransactionRequest()
			{
				Date = DateTime.Now,
				Quantity = quantity * -1,
				UserId = currentUser.Id
			});
		if (!result.Success)
		{
			return BadRequest(result.Message);
		}

		await _mailService.SendEmailAsync(new EmailDto()
		{
			Body = "Para çekme İşlemi",
			Subject = "Para Çekme",
			To = currentUser.Email
		});

		return Ok(result.Message);
	}
}
