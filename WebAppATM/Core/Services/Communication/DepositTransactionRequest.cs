namespace WebAppATM.Core.Services.Communication
{
	public class DepositTransactionRequest
	{
		public decimal Quantity { get; set; }
		public DateTime Date { get; set; }
		public Guid UserId { get; set; }
	}
}