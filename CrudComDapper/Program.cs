using CRUD.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CRUD
{
    internal class Program
    {
        private const string CONNECTION_STRING = "Server=localhost,1433;TrustServerCertificate=True;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            var connectionSql = new SqlConnection(CONNECTION_STRING);
            connectionSql.Open();
            WriteUser();
            connectionSql.Close();

        }

        public static void ReadUsers()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                // GetAll = SELECT * FROM User
                var users = conn.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine($"ID:{user.Id} - Nome: {user.Name}");
                }
            }
        }

        public static void ReadUser()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                var user = conn.Get<User>(1);
                Console.WriteLine(user.Name);
            }
        }

        public static void WriteUser()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                var user = new User()
                {
                    Name = "Sistemas da informação",
                    Email = "si@gmail.com",
                    PasswordHash = "HASH",
                    Bio = "sistemas-i-programming",
                    Image = "https://",
                    Slug = "sistemas-da-informacao"
                };

                conn.Insert<User>(user);
                Console.WriteLine($"Usuário {user.Name}, foi adicionado com sucesso");
            }
        }

        public static void UpdateUser()
        {
            using(var conn = new SqlConnection(CONNECTION_STRING))
            {
                var user = new User()
                {
                    Id = 1,
                    Name = "Sistemas da informação SYSTEMS",
                    Email = "si@gmail.com",
                    PasswordHash = "HASHHHH",
                    Bio = "sistemas-i-programming",
                    Image = "https://",
                    Slug = "CRIAMOS SISTEMAS DO ZERO PARA VOCÊ"
                };

                conn.Update<User>(user);
                Console.WriteLine("Usuário atualizado com sucesso.");
            }
        }

        public static void DeleteUser()
        {
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                // Primeiro puxa o usuário do BD via ID.
                var user = conn.Get<User>(2011);
                // Depois excluí o mesmo...
                conn.Delete<User>(user);
                Console.WriteLine("Úsuário excluído do sistema.");
            }
        }
    }
}
