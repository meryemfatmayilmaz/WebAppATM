using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;
using WebAppATM.Core.Repositories;
using WebAppATM.Core.Services;
using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Services
{
	public class AccountTransactionService : IAccountTransactionService
	{
		public readonly IAccountTransactionRepository _accountTransactionRepository;
		private readonly IUnitOfWork _unitOfWork;
		public AccountTransactionService(IAccountTransactionRepository accountTransactionRepository, IUnitOfWork unitOfWork)
		{
			_accountTransactionRepository = accountTransactionRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<WithdrawalTransactionResponse> WithdrawalAsync(WithdrawalTransactionRequest request)
		{
			if (await _accountTransactionRepository.SumOfQuantityAsync(request.UserId) < 0.0m)
			{
				return new WithdrawalTransactionResponse(false, "Yetersiz Bakiye");
			}
			var transectionType = TransactionTypes.WithDrawalFromAccount;
			if (_accountTransactionRepository.RecordCountByTransactionType(transectionType) == 0)
			{
				request.TransactionNumber = 1000;
			}
			else
			{
				request.TransactionNumber = _accountTransactionRepository.GetMaxTransactionNumber();
			}
			await _accountTransactionRepository.CreateAccountTransactionAsync(
				new AccountTransaction(request.UserId, request.Quantity, request.Date));
			await _unitOfWork.CompleteAsync();
			return new WithdrawalTransactionResponse(true, "İşlem Başarılı");
		}
		public async Task<AccountTransaction> FindByTransectionNumberAsync(int transectionNumber)
		{
			return await _accountTransactionRepository.FindByTransectionNumberAsync(transectionNumber);
		}

		public Task<decimal> SumOfQuantityAsync(Guid userId)
		{
			return _accountTransactionRepository.SumOfQuantityAsync(userId);
		}

		public async Task<DepositTransactionResponse> DepositAsync(DepositTransactionRequest request)
		{
			await _accountTransactionRepository.CreateAccountTransactionAsync(
				new AccountTransaction(request.UserId, request.Quantity, request.Date));
			await _unitOfWork.CompleteAsync();
			return new DepositTransactionResponse(true, "İşlem Başarılı");
		}
	}
}
