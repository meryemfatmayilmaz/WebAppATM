using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;

namespace WebAppATM.Core.Repositories
{
	public interface IAccountTransactionRepository
	{
		Task<AccountTransaction> FindByTransectionNumberAsync(int transectionNumber);
		Task<decimal> SumOfQuantityAsync(Guid userId);
		Task CreateAccountTransactionAsync(AccountTransaction accountRansection);
		int GetMaxTransactionNumber();
		int RecordCountByTransactionType(TransactionTypes transactionType);
	}
}
