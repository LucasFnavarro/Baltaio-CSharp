using System;
using Aula2.Models;
using Aula2.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Aula2
{
    public class Program
    {
        private const string CONEXAO_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            var connexao = new SqlConnection(CONEXAO_STRING);
            connexao.Open();
            CriarRole(connexao);
            connexao.Open();
        }

        public static void ListarTodosUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ListarTodosRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Get();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }
    }
}
