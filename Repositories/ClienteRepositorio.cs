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

        public string GetConnection()
        {

            var connection = _configuration.GetSection("ConnectionStrings").
            GetSection("TesteDb").Value;
            return connection;
        }
        public ClienteRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Add(Cliente cliente)
        {

            var connectionString = this.GetConnection();
            var clientes = new List<Cliente>();
            var affectedRows = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO clientes (Id,Nome,Cpf,Email,Telefone) VALUES(@Id,@Nome,@CPF,@Email,@Telefone)";
                    affectedRows = con.Execute(query, cliente);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return affectedRows;
            }
        }

        public int Delete(string pk)
        {
            using (var con = new SqlConnection(this.GetConnection()))
            {
                var affectedRows = 0;
                try
                {
                    con.Open();
                    var query = $"DELETE FROM Clientes where id ='{pk}'";
                    affectedRows = con.Execute(query);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return affectedRows;
            }
        }


        public Cliente Get(string pk)
        {
            using (var con = new SqlConnection(this.GetConnection()))
            {
                Cliente c;
                try
                {
                    con.Open();
                    var query = $"SELECT * FROM clientes where Id = '{pk}'";
                    c = con.Query<Cliente>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();

                }

                return c;
            }
        }



        public List<Cliente> GetPaginado(string cpf=null)
        {
            var connectionString = this.GetConnection();
            List<Cliente> clientes;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM clientes";
                    if (cpf!=null){
                        query = $"SELECT * FROM clientes where CPF like {cpf}%";
                    }
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

        public int Update(string id, Cliente cliente)
        {
            using (var con = new SqlConnection(this.GetConnection()))
            {
                var affectedRows = 0;
                try
                {
                    con.Open();
                    var query = $"UPDATE Clientes SET Nome=@Nome,CPF=@CPF,Email=@Email,Telefone=@Telefone where Id ='{id}'";
                    affectedRows = con.Execute(query,cliente);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return affectedRows;
            }
        }

       
    }


}