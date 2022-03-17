using System.Net;
using Microsoft.AspNetCore.Mvc;
using Volvo.Domain.Interface.Service;
using Volvo.Domain.Models;

namespace Volvo.Application.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private ITruckService _service { get; set; }
        public TrucksController(ITruckService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get());
            }
            catch (ArgumentException exception)
            {
                
                return StatusCode ((int) HttpStatusCode.InternalServerError, exception.Message);
            }
            
        }

        [HttpGet]
        [Route ("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException exception)
            {
                
                return StatusCode ((int) HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post ([FromBody] TruckDto truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(truck);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result);
                }else{
                    return BadRequest();
                }

            }
            catch (ArgumentException exception)
            {
                
                return StatusCode ((int) HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put ([FromBody] TruckDto truck)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Put(truck);
                if (result != null)
                {
                    // return Created(new Uri(Url.Link("GetWithId", new {id = result.Id})), result);
                    return Ok(result);
                }else{
                    return BadRequest();
                }

            }
            catch (ArgumentException exception)
            {
                
                return StatusCode ((int) HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException exception)
            {
                
                return StatusCode ((int) HttpStatusCode.InternalServerError, exception.Message);
            }
        }

    }
}