using System;
using System.Collections.Generic;
using ClienteApi.Models;
using ClienteApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<Cliente>> GetList([FromServices]IClienteRepositorio clienteRepositorio)
        {
            return clienteRepositorio.GetPaginado();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Cliente> Get([FromServices]IClienteRepositorio clienteRepositorio, string id)
        {
            var result= clienteRepositorio.Get(id);
            if (result==null)
                return NotFound();
            return result;
        }
        [HttpPost]
        public ActionResult<Cliente> Post([FromServices]IClienteRepositorio clienteRepositorio, [FromBody] Cliente cliente)
        {
            if(!cliente.CPFisValid())
                ModelState.AddModelError("CPF","CPF invalido");
            if (ModelState.IsValid)
            {
                int result = clienteRepositorio.Add(cliente);

                return cliente;
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Cliente> Put([FromServices]IClienteRepositorio clienteRepositorio, string id, [FromBody] Cliente cliente)
        {
        //    if(!cliente.CPFisValid())
        //         ModelState.AddModelError("CPF","CPF invalido");
            if (ModelState.IsValid)
            {
                int result = clienteRepositorio.Update(id,cliente);
                if (result>0)
                    return cliente;
                
            }
            return BadRequest();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCliente([FromServices]IClienteRepositorio clienteRepositorio, string id)
        {
            clienteRepositorio.Delete(id);
            return Ok();
        }

    }
}