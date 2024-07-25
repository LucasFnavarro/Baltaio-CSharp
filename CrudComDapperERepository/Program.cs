using CrudComDapperERepository.Models;
using CrudComDapperERepository.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CrudComDapperERepository
{
    internal class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;TrustServerCertificate=True;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            ReadUsers(connection);
            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();
                  
            foreach(var user in users)
                Console.WriteLine(user.Name);
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var roleRepository = new RoleRepository(connection);
            var roles = roleRepository.Get();

            foreach(var role in roles)
                Console.WriteLine(role.Name);
        }

  
    }
}