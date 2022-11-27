namespace WebAppATM.Core.Models;

public class AccountTransaction
{
	public Guid Id { get; protected set; }
	public int TransactionType { get; private set; }
	public decimal Quantity { get; private set; }

	public int? TransactionNumber { get; private set; }
	public DateTime Date { get; set; }
	public Guid UserId { get; private set; }
	public virtual User User { get; private set; }
	public AccountTransaction(Guid userId, decimal quantity, int? transactionNumber, DateTime date)
	{
		Id = Guid.NewGuid();
		UserId = userId;
		TransactionNumber = transactionNumber;
		Date = date;
		Quantity = quantity;

	}
	public AccountTransaction(Guid userId, decimal quantity, DateTime date)
	{
		Id = Guid.NewGuid();
		UserId = userId;
		Quantity = quantity;
		Date = date;

	}

}
