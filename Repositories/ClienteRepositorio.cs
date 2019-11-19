using System.Collections.Generic;
using System;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;
using ClienteApi.Models;
using System.Data.SqlClient;

namespace ClienteApi.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        IConfiguration _configuration;
        public ClienteRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Add(Cliente cliente)
        {
            
            var connectionString = this.GetConnection();
            var clientes = new List<Cliente>();
            int count=0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO clientes (Nome,Cpf,Email,Telefone) VALUES(@Nome,@CPF,@Email,@Telefone)";
                    count=con.Execute(query,cliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count==1;
            }
        }

        public void Delete(string pk)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(string pk)
        {
            throw new NotImplementedException();
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
            GetSection("TesteDb").Value;
            return connection;
        }

        public List<Cliente> GetPaginado()
        {
            var connectionString = this.GetConnection();
            var clientes = new List<Cliente>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM clientes";
                    clientes = con.Query<Cliente>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return clientes;
            }
        }

        public void Update(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }


}