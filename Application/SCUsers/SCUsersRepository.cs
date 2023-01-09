using TodoApi.Aplication;
using TodoApi.Infrastructure.Persistance;

namespace TodoApi
{
    public class SCUsersRepository 
    {
        IGenericRepository<ScUser> _repository;
        public async Task<IEnumerable<ScUser>> GetAllAsync()
        {
            return await _repository.GetAll();
        }
    }
   
}