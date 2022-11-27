namespace WebAppATM.Core.Models;
public class User
{
	public Guid Id { get; protected set; }

	public string Name { get; set; }
	public string Surname { get; set; }
	public string Username { get; private set; }
	public string Password { get; private set; }
	public string Email { get; set; }
	public User(string name, string surname, string username, string password, string email)
	{
		Id = Guid.NewGuid();
		Name = name;
		Surname = surname;
		Username = username;
		Password = password;
		Email = email;
	}
}