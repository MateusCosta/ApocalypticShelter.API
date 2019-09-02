using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;
using ApocalypticShelter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApocalypticShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterStockController : ControllerBase
    {
        private readonly IShelterStockService _service;

        public ShelterStockController(IShelterStockService service)
        {
            _service = service;
        }

        // GET api/resources
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }

        // GET api/resources/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_service.Get(id));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateShelterStock([FromBody]ShelterStock shelterStock)
        {
            try
            {
                return Ok(_service.Create(shelterStock));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShelterStock([FromBody]ShelterStock shelterStock)
        {
            try
            {
                return Ok(_service.Update(shelterStock));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShelterStock(int id)
        {
            try { 
                return Ok(_service.Delete(id));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }


    }
}