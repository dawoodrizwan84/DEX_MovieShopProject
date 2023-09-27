using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using DEX_MovieShopProject.Services.Abstract;

namespace DEX_MovieShopProject.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _db;

        public CustomerService(AppDbContext db)

        {
            _db = db;


        }
        List<Customer> Customers { get; set; } = new List<Customer>();  
        public void CreateCustomer(Customer newCustomer)
        {
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
        }
    }
}
