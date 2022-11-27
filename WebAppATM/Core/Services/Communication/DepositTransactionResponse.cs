namespace WebAppATM.Core.Services.Communication;

public class DepositTransactionResponse : BaseResponse
{
	public DepositTransactionResponse(bool success, string message) : base(success, message)
	{
	}
}
