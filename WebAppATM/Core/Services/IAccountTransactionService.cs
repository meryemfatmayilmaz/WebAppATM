using WebAppATM.Core.Models;
using WebAppATM.Core.Services.Communication;

namespace WebAppATM.Core.Services;

public interface IAccountTransactionService
{
	Task<DepositTransactionResponse> DepositAsync(DepositTransactionRequest request);
	Task<WithdrawalTransactionResponse> WithdrawalAsync(WithdrawalTransactionRequest request);
	Task<AccountTransaction> FindByTransectionNumberAsync(int transectionNumber);
	Task<decimal> SumOfQuantityAsync(Guid userId);
}
