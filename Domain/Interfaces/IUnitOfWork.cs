namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        //ICargo Cargos { get; }
        IUser Users { get; }
        IRol Rols { get; }
        Task<int> SaveAsync();
    }
}