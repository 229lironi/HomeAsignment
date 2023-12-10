using Newtonsoft.Json;
using Test.Model;

namespace Test.Repository.ClientJsonRepository
{
    public class ClientJsonRepository : IClientRepository
    {
        private readonly string jsonPath;
        private readonly List<Client>? clientsList;

        public ClientJsonRepository(string jsonPath)
        {
            this.jsonPath = jsonPath;
            clientsList = LoadAllClients();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return clientsList;
        }

        public Client GetClientById(int id)
        {
            return clientsList.FirstOrDefault(c => c.Id == id);
        }

        #region Private Methods
        private List<Client> LoadAllClients()
        {
            return JsonConvert.DeserializeObject<List<Client>>(File.ReadAllText(jsonPath));
        }
        #endregion  Private Methods
    }
}
