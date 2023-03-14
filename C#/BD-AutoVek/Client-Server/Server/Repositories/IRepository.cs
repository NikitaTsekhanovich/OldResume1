using System.Collections.Generic;

namespace Server
{
    public interface IRepository
    {
        void Add(Client client);
        List<Client> FindAll();
        Client Read(int id);
        bool ExistById(int id);
        void DeleteById(int id);
        void ReWriteById(int id, Client client);
    }
}