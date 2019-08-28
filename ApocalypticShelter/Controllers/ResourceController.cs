using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApocalypticShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _service;

        public ResourceController(IResourceService service)
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
    }
}