using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.CRUD.Exceptions;
using Framework.CRUD.Models;

namespace Framework.CRUD.Repo
{
    public class DefaultRepo<T> : ICrudRepo<T, Guid> where T : IDefaultEntity
    {
        private readonly Dictionary<Guid, T> _inMemoryObjectDictionary = new Dictionary<Guid, T>();

        public async Task<T> Get(Guid id)
        {
            if (_inMemoryObjectDictionary.ContainsKey(id))
            {
                return _inMemoryObjectDictionary[id];
            }
            
            throw new NotFoundException($"Person with id: {id} was not found");
        }

        public async Task<T> Update(Guid id, T obj)
        {
            if (!_inMemoryObjectDictionary.ContainsKey(id)) throw new NotFoundException($"Person with id: {id} was not found", "CONFLICT");
            _inMemoryObjectDictionary[id] = obj;
            return _inMemoryObjectDictionary[id];
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!_inMemoryObjectDictionary.ContainsKey(id)) throw new NotFoundException($"Person with id: {id} was not found", "NOTFOUND");
            return _inMemoryObjectDictionary.Remove(id);
        }

        public async Task<T> Insert(T obj)
        {
            if (_inMemoryObjectDictionary.ContainsKey(obj.Id))
            {
                throw new ConflictException( $"Person with id: {obj.Id} exists");
            }
            
            _inMemoryObjectDictionary.Add(obj.Id, obj);
            return obj;
        }
    }
}