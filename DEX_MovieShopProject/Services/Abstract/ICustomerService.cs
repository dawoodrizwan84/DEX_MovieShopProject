using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;

namespace DEX_MovieShopProject.Services.Abstract
{
    public interface ICustomerService
    {


        List<Customer> GetCustomer();
        void CreateCustomer(Customer newCustomer);

        bool UpdateCustomer(Customer newCustomer);

        Customer GetCustomerById(int id);
        bool DeleteCustomer(int id);

        bool CheckExists(string email);

       Customer GetCustomer(string email);


    }
}
