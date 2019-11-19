using System.Collections.Generic;
using ClienteApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClienteApi.Models;

namespace ClienteApi.Pages
{
    public class ClienteIndexModel : PageModel
    {

        [BindProperty]
        public List<Cliente> lsclientes { get; set; }
        IClienteRepositorio _clienteRepositorio;
        public ClienteIndexModel(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        [BindProperty]
        public Cliente cliente { get; set; }

        [TempData]
        public string Message { get; set; }
        public void OnGet()
        {
            lsclientes=_clienteRepositorio.GetPaginado();
        }
    }
}
