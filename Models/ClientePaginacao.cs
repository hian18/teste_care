using System.Collections.Generic;

namespace ClienteApi.Models

{
    public class ClientePaginacao:Paginacao
    {
        public List<Cliente> items { get; set; }
    }
}