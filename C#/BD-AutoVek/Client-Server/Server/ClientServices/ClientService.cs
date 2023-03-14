using System.Collections.Generic;

namespace Server
{
    public class ClientService : IClientService
    {
        private IRepository repository;
        
        public void Create(Client client)
        {
            repository.Add(client);
        }

        public List<Client> ReadAll()
        {
            return repository.FindAll();
        }

        public Client Read(int id)
        {
            return repository.Read(id);
        }

        public bool Update(Client client, int id)
        {
            if (repository.ExistById(id))
            {
                repository.ReWriteById(id, client);
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (repository.ExistById(id))
            {
                repository.DeleteById(id);
                return true;
            }

            return false;
        }
    }
}
