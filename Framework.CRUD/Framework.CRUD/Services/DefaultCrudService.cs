using System;
using System.Threading.Tasks;
using Framework.CRUD.Models;
using Framework.CRUD.Repo;
using Microsoft.AspNetCore.Identity;

namespace Framework.CRUD.Services
{
    public class DefaultCrudService<T> : ICrudService<T, Guid> where T : IDefaultEntity
    {
        private readonly ICrudRepo<T, Guid> _crudRepo;
        
        public DefaultCrudService(ICrudRepo<T, Guid> crudRepo)
        {
            _crudRepo = crudRepo;
        }
        
        public async Task<T> Get(Guid id)
        {
            return await _crudRepo.Get(id);
        }

        public async Task<T> Update(Guid id, T obj)
        {
            return await _crudRepo.Update(id, obj);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _crudRepo.Delete(id); 
        }

        public async Task<T> Insert(T obj)
        {
            if (!obj.Id.Equals(null)) return await _crudRepo.Insert(obj);
            return await _crudRepo.Insert(obj);
        }
    }
}