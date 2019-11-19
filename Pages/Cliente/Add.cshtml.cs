using ClienteApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClienteApi.Models;

namespace ClienteApi.Pages
{
    public class AddModel : PageModel
    {

        IClienteRepositorio _clienteRepositorio;
        public AddModel(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }
        [BindProperty]
        public Cliente cliente { get; set; }

        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if(_clienteRepositorio.Add(cliente))
                Message="Cliente Cadastrado!";
            
            return Page();
        }
    }
}
