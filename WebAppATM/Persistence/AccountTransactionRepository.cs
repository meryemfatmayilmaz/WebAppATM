using Microsoft.EntityFrameworkCore;
using WebAppATM.Core.Enums;
using WebAppATM.Core.Models;
using WebAppATM.Core.Repositories;

namespace WebAppATM.Persistence
{
	public class AccountTransactionRepository : IAccountTransactionRepository
	{
		private readonly AppDbContext _context;
		public AccountTransactionRepository(AppDbContext context) => _context = context;
		public async Task CreateAccountTransactionAsync(AccountTransaction accountTransection)
		{
			await _context.AccountTransactions.AddAsync(accountTransection);
			await _context.SaveChangesAsync();
		}
		public async Task<AccountTransaction> FindByTransectionNumberAsync(int transectionNumber)
		{
			return await _context.AccountTransactions
				.SingleOrDefaultAsync(x => x.TransactionNumber == transectionNumber);
		}
		public async Task<decimal> SumOfQuantityAsync(Guid userId)
		{
			return await _context.AccountTransactions
				.Where(x => x.UserId == userId)
				.SumAsync(x => x.Quantity);
		}
		public int GetMaxTransactionNumber()
		{
			return Convert.ToInt32(_context.AccountTransactions
				.MaxAsync(x => x.TransactionNumber)) + 1;
		}
		public int RecordCountByTransactionType(TransactionTypes transactionType)
		{
			var type = (int)transactionType;
			return _context.AccountTransactions.Count(x => x.TransactionType == type);
		}
	}
}
