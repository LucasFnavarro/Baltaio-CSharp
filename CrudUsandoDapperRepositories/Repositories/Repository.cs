using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Aula2.Repositories
{
    public class Repository<Tmodel> where Tmodel : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<Tmodel> Get()
            => _connection.GetAll<Tmodel>();

        public void Get(Tmodel model)
            => _connection.Get<Tmodel>(model);

        public void Create(Tmodel model)
            => _connection.Insert<Tmodel>(model);

        public void Update(Tmodel model)
            => _connection.Update<Tmodel>(model);

        public void Delete(Tmodel model)
        {
            var user = _connection.Get<Tmodel>(model);
            _connection.Delete<Tmodel>(user);
        }


    }
}