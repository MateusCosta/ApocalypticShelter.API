using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApocalypticShelter.Models;
using ApocalypticShelter.Services.Interfaces;
using ApocalypticShelter.ViewModels;
using ApocalypticShelter.ViewModels.TransactionViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApocalypticShelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
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
        public IActionResult CreateTransaction([FromBody] CreateTransactionViewModel transaction)
        {
            try
            {
                transaction.Validate();
                if (transaction.Invalid)
                {
                    return BadRequest( new ResultViewModel
                    {
                        Success = false,
                        Message = "Não foi possível inserir o produto",
                        Data = transaction.Notifications
                    });
                }
                return Ok(_service.Create(transaction));
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                return BadRequest(new ResultViewModel
                {
                    Success = false,
                    Message = "Ocorreu um erro. Contate o Administrador para mais informacoes",
                    Data = null
                });
            }
        }

        

    }
}