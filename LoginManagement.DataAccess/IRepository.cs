using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginManagement.DataAccess
{
    
        public interface IRepository<TEntity, TIdentity>
        {
            //Client has only these opertaions that one can do......
            IEnumerable<TEntity> GetAll();
            void AddNew(TEntity entity);
            TEntity FindById(TIdentity id);
            void Update(TEntity entity);
            void Remove(TIdentity id);
        }
    
}
