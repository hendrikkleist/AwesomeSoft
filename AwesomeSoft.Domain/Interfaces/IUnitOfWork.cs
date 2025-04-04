namespace AwesomeSoft.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPeopleRepository People {  get; }
    int Complete();
}
