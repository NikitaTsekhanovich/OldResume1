using System.Collections.Generic;

namespace Server
{
    public interface IClientService
    {
        void Create(Client client);
        List<Client> ReadAll();
        Client Read(int id);
        bool Update(Client client, int id);
        bool Delete(int id);
    }
}