using Domain.Entities;
using TodoApi.Aplication;
using TodoApi.Aplication.FileRepository.Repositories;
using TodoApi.Controllers.Common;
namespace TodoApi.Controllers.Services
{
    public class FileRepositoryService : IGenericService<FileRepositoryModel>
    {
        public  FileRepositoryRepo _repository = new FileRepositoryRepo();

        public FileRepositoryService(FileRepositoryRepo repository)
        {
            _repository = repository;
            
            
        }
        public async Task<FileRepositoryModel> Create(FileRepositoryModel entity)
        {
            return await _repository.Add(entity);
        }

        public Task Delete(FileRepositoryModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<FileRepositoryModel> Get(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<FileRepositoryModel> GetBySerialNumber(string serialNumber)
        {
          return  await _repository.GetBySerialNumber(serialNumber);
          
        }
       

        public Task<IEnumerable<FileRepositoryModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(FileRepositoryModel entity)
        {
            throw new NotImplementedException();
        }
    }
}