using System;
using System.Threading.Tasks;
using Framework.CRUD.Extensions;
using Framework.CRUD.Models;
using Framework.CRUD.Services;
using Microsoft.AspNetCore.Mvc;


namespace Framework.CRUD.Controllers
{
    public abstract class BaseCrudController<TO, TI> : Controller where TO : IEntity
    {
        private readonly ICrudService<TO, TI> _service;

        protected BaseCrudController(ICrudService<TO, TI> service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(TI id)
        {
            var obj = await _service.Get(id);
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TO obj)
        {
            var response = ValidateRequestBody();

            if (response != null)
            {
                return response;
            }

            var responseObj = await _service.Insert(obj);
            var location = $"https://localhost:5001/api/person/{obj.GetId()}";
            return Created(new Uri(location), responseObj);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(TI id, [FromBody] TO obj)
        {
            var response = ValidateRequestBody();

            if (response != null)
            {
                return response;
            }

            var responseObj = await _service.Update(id, obj);
            return Ok(responseObj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(TI id)
        {
            await _service.Delete(id);
            return Ok();
        }

        private IActionResult ValidateRequestBody()
        {
            return !ModelState.IsValid ? BadRequest(ModelState.GetErrorMessages()) : null;
        }
    }
}