namespace WebAppATM.Core.Services.Communication
{
	public class WithdrawalTransactionResponse : BaseResponse
	{
		public WithdrawalTransactionResponse(bool success, string message) : base(success, message)
		{
		}
	}
}
