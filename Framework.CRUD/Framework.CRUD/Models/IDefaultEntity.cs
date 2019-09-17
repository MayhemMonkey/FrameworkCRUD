using System;

namespace Framework.CRUD.Models
{
    public interface IDefaultEntity : IEntity
    {
        Guid Id { get; set; }
    }
}