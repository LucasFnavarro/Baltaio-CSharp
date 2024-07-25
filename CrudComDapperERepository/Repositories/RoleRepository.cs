using CrudComDapperERepository.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CrudComDapperERepository.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _repository;

        public RoleRepository(SqlConnection repository)
            => _repository = repository;

        public IEnumerable<Role> Get()
            => _repository.GetAll<Role>();

        public User Get(int id)
            => _repository.Get<User>(id);

        public void Create(Role role)
        {
            if (role.Id != 0)
                _repository.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            if (role.Id != 0)
                _repository.Update<Role>(role);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;
                
            var role = _repository.Get<Role>(id);
            _repository.Delete<Role>(role);
        }
    }
}
