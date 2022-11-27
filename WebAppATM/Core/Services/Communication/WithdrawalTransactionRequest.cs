namespace WebAppATM.Core.Services.Communication;

public class WithdrawalTransactionRequest
{
	public decimal Quantity { get; set; }
	public int? TransactionNumber { get; set; }
	public DateTime Date { get; set; }
	public Guid UserId { get; set; }
}
