using System;
using Framework.CRUD.Controllers;
using Framework.CRUD.Services;
using FrameworkCRUDExamples.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrameworkCRUDExamples.Controllers
{
    [Route("/api/[controller]")]
    public class PersonController : BaseCrudController<Person, Guid>
    {
        public PersonController(ICrudService<Person, Guid> service) : base(service)
        {
            
        }
    }
}