﻿using System;
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
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _service;

        public ResourceController(IResourceService service)
        {
            _service = service;
        }

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
        public IActionResult CreateResource([FromBody]Resource resource)
        {
            try
            {
                return Ok(_service.Create(resource));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResource([FromBody]Resource resource)
        {
            try
            {
                return Ok(_service.Update(resource));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new { msg = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResource(int id)
        {
            try
            { 
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