using System.Collections.Generic;
using ClienteApi.Models;

namespace ClienteApi.Repositories
{
    public interface IClienteRepositorio
    {
        bool Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(string pk);
        Cliente Get(string pk);
        List<Cliente> GetPaginado();

    }
}