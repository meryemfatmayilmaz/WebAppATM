using WebAppATM.Core.Enums;

namespace WebAppATM.Core.Repositories.Dtos;

public class CreateAccountTransactionDto
{
	public decimal Quantity { get; set; }
	public int? TransactionNumber { get; set; }
	public DateTime Date { get; set; }
	public Guid UserId { get; set; }
	public TransactionTypes TransactionType { get; set; }
}
