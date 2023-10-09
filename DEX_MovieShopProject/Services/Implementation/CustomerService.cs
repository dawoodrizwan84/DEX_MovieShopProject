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

        public List<Customer>GetCustomer() 
        {
        return _db.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _db.Customers.Find(id);
        }




        public void CreateCustomer(Customer newCustomer)
        {
            _db.Customers.Add(newCustomer);
            _db.SaveChanges();
        }

        public bool UpdateCustomer(Customer newCustomer)
        {
            try 
            {
                _db.Customers.Update(newCustomer);
                _db.SaveChanges();
                return true;
            }

            catch (Exception ex) 
            
            {
                return false;
            }
        
        
        }

        public bool DeleteCustomer(int id)
        {
            try 
            {
                var data = this.GetCustomerById(id);
                if(data == null)
                {
                    return false;
                }
                _db.Customers.Remove(data);
                _db.SaveChanges();
                return true;
            }

            catch (Exception ex) 
            {
                return false;
            }
        
        }

        public bool CheckExists(string email)
        {
            return _db.Customers.Any(c => c.EmailAddress == email);
        }

        public Customer GetCustomer(string email)
        {
            return _db.Customers.Where(c=>c.EmailAddress == email).FirstOrDefault();
        }
    }
}
