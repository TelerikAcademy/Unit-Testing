using System.Collections.Generic;

namespace PackageManager.Repositories.Contracts
{
    public interface IRepository<T>
    {
        void Add(T package);

        bool Update(T package);

        IEnumerable<T> GetAll();

        T Delete(T package);
    }
}
