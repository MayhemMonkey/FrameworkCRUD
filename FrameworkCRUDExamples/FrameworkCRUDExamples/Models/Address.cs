using System;
using Framework.CRUD.Models;

namespace FrameworkCRUDExamples.Models
{
    public class Address : IDefaultEntity
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        
        public string GetId()
        {
            return this.Id.ToString();
        }
    }
}