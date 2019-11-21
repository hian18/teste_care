using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClienteApi.Models

{
    public class Paginacao
    {
        public int Pagina { get; set; }
        public int QuantidaPorPagina { get; set; }
        public int Total { get; set; }
    }

}