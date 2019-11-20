using System.Collections.Generic;
using ClienteApi.Models;

namespace ClienteApi.Repositories
{
    public interface IClienteRepositorio
    {
        int Add(Cliente cliente);
        int Update(string id,Cliente cliente);
        int Delete(string pk);
        Cliente Get(string pk);
        List<Cliente> GetPaginado(string cpf=null);

    }
}