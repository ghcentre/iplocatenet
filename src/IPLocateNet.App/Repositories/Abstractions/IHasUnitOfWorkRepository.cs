namespace IPLocateNet.App.Repositories.Abstractions;

public interface IHasUnitOfWorkRepository
{
    IUnitOfWork UnitOfWork { get; }
}
