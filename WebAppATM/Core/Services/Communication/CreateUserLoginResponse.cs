namespace WebAppATM.Core.Services.Communication;
public class CreateUserResponse : BaseResponse
{
	public Guid Id { get; set; }
	public CreateUserRequest User { get; private set; }
	public CreateUserResponse(bool success, string message, Guid id, CreateUserRequest user) : base(success, message)
	{
		Id = id;
		User = user;
	}
}