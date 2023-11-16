using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly JardineriaContext context;
        //private ICargo _cargo;
        private IUser _user;
        private IRol _rol;

        public UnitOfWork(JardineriaContext _context)
        {
            context = _context;
        }

        // public ICargo Cargos {
        //     get{
        //         if(_cargo == null){
        //             _cargo = new CargoRepository(context);
        //         }
        //         return _cargo;
        //     }
        // }

        public IUser Users
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(context);
                }
                return _user;
            }
        }
        public IRol Rols
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(context);
                }
                return _rol;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}