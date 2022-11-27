using System.ComponentModel.DataAnnotations;

namespace WebAppATM.Controllers.Resources
{
	public class UserAccountTransactionsResource
	{
		[Required]
		[StringLength(Shared.Constants.User.UsernameLength)]
		public string UserName { get; set; }
		public int MyProperty { get; set; }
	}
}
