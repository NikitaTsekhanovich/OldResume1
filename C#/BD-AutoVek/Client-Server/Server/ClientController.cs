using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace Server
{
    public class ClientController
    {
        private IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public HttpResponseMessage Create(Client client)
        {
            clientService.Create(client);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        public HttpResponseMessage ReadAll()
        {
            var clients = clientService.ReadAll();
            if (clients != null && clients.Count != 0)
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonSerializer.Serialize(clients))
                };
            
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage ReadSingle(int id)
        {
            var client = clientService.Read(id);

            if (client != null)
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(client.Serialized)
                };
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage Update(int id, Client client)
        {
            var updated = clientService.Update(client, id);

            if (updated)
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotModified);
        }

        public HttpResponseMessage Delete(int id)
        {
            var deleted = clientService.Delete(id);

            if (deleted)
                return new HttpResponseMessage(HttpStatusCode.OK);
            return new HttpResponseMessage(HttpStatusCode.NotModified);
        }
    }
}