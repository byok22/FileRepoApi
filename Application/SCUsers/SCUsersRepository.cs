using TodoApi.Aplication;
using TodoApi.Infrastructure.Persistance;


namespace TodoApi
{
    public class SCUsersRepository: IGenericRepository<SCUserModel> 
    {
        IGenericRepository<ScUser> _repository;

        public SCUsersRepository(IGenericRepository<ScUser> repository)
        {
            _repository = repository;
        }       
        public Task<SCUserModel> Add(SCUserModel entity)
        {
            ScUser scUser = new ScUser();
            scUser.PkuserId = entity.id;
            scUser.FkmesUserId = entity.FkmesUserId;
            scUser.EmployeeNumer = entity.EmployeeNumer;
            scUser.Ntuser = entity.Ntuser;
            scUser.FirstName = entity.FirstName;
            scUser.LastName = entity.LastName;
            scUser.SecondLastName = entity.SecondLastName;
            scUser.Email = entity.Email;
            scUser.FkroleId = entity.FkroleId;
            scUser.Available = entity.Available;
            scUser.CreatedAt = DateTime.Now;
            scUser.UpdatedAt = DateTime.Now;
            
            var result = _repository.Add(scUser);            
            return Task.FromResult(entity);
        }

        public Task Delete(SCUserModel entity)
        {
             var entityToDelete = _repository.GetById(entity.id).Result;
             return _repository.Delete(entityToDelete);
        }

        public Task<IEnumerable<SCUserModel>> GetAll()
        {
             var listofUsers = _repository.GetAll().Result;
            var listofUsersModel = new List<SCUserModel>();
            foreach(var user in listofUsers)
            {
                var usermodel = new SCUserModel();
                usermodel.id = user.PkuserId;
                usermodel.FkmesUserId = user.FkmesUserId;
                usermodel.EmployeeNumer = user.EmployeeNumer;
                usermodel.Ntuser = user.Ntuser;
                usermodel.FirstName = user.FirstName;
                usermodel.LastName = user.LastName;
                usermodel.SecondLastName = user.SecondLastName;
                usermodel.Email = user.Email;
                usermodel.FkroleId = user.FkroleId;
                usermodel.Available = user.Available;            
                listofUsersModel.Add(usermodel);
            }
            return Task.FromResult(listofUsersModel.AsEnumerable());

        }

        public Task<SCUserModel> GetById(int id)
        {
            var user = _repository.GetById(id).Result;
            var usermodel = new SCUserModel();
            usermodel.id = user.PkuserId;
            usermodel.FkmesUserId = user.FkmesUserId;
            usermodel.EmployeeNumer = user.EmployeeNumer;
            usermodel.Ntuser = user.Ntuser;
            usermodel.FirstName = user.FirstName;
            usermodel.LastName = user.LastName;
            usermodel.SecondLastName = user.SecondLastName;
            usermodel.Email = user.Email;
            usermodel.FkroleId = user.FkroleId;
            usermodel.Available = user.Available;
            return Task.FromResult(usermodel);
        }

        public Task Save()
        {
            return _repository.Save();
        }

        public Task Update(SCUserModel entity)
        {
            var entityToUpdate = _repository.GetById(entity.id).Result;
            entityToUpdate.FkmesUserId = entity.FkmesUserId;
            entityToUpdate.EmployeeNumer = entity.EmployeeNumer;
            entityToUpdate.Ntuser = entity.Ntuser;
            entityToUpdate.FirstName = entity.FirstName;
            entityToUpdate.LastName = entity.LastName;
            entityToUpdate.SecondLastName = entity.SecondLastName;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.FkroleId = entity.FkroleId;
            entityToUpdate.Available = entity.Available;        
            entityToUpdate.UpdatedAt = DateTime.Now;
            return _repository.Update(entityToUpdate);

        }
    }
   
}