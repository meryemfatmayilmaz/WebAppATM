namespace WebAppATM.Core.Repositories
{
	public interface IUnitOfWork
	{
		Task CompleteAsync();
	}
}
