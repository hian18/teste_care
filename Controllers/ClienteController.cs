using System.Collections.Generic;
using ClienteApi.Models;
using ClienteApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClienteApi.Controllers
{
    [Route("api")]
    public class ClienteController : Controller
    {
        IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio){
            _clienteRepositorio=clienteRepositorio;
        }
        [Route("clientes")]
        [HttpGet]
        public List<Cliente> GetList()
        {
            return _clienteRepositorio.GetPaginado();

        }
        [Route("teste")]
        [HttpGet]
        public string Teste()=>"hello world";
    }
}