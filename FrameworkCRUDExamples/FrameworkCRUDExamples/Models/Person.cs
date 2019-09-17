using System;
using System.ComponentModel.DataAnnotations;
using Framework.CRUD.Models;

namespace FrameworkCRUDExamples.Models
{
    public class Person : IDefaultEntity
    {
        public Guid Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public int Age { get; set; }
        public Address Address { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;

        public string GetId()
        {
            return this.Id.ToString();
        }
    }
}