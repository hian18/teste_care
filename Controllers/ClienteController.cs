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
        public ActionResult<List<Cliente>> GetList([FromServices]IClienteRepositorio clienteRepositorio, [FromQuery] string cpf=null)
        {
            return clienteRepositorio.GetPaginado(null,cpf);
        }
        [HttpPost]
        [Route("ListarPaginado")]
        public ActionResult<ClientePaginacao> GetPaginado([FromServices]IClienteRepositorio clienteRepositorio, [FromBody] Paginacao paginacao,[FromQuery] string cpf=null)
        {
            ClientePaginacao clientePaginacao=new ClientePaginacao();
            if (paginacao==null){
                paginacao.Pagina=1; 
            }
            clientePaginacao.items=clienteRepositorio.GetPaginado(paginacao,cpf);

            return clientePaginacao;
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
           if(!cliente.CPFisValid())
                ModelState.AddModelError("CPF","CPF invalido");
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