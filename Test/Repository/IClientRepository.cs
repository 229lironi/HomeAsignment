using Test.Model;

namespace Test.Repository
{
    public interface IClientRepository
    {
        public IEnumerable<Client> GetAllClients();
        public Client GetClientById(int id);
    }
}
