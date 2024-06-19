using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService
    {
        void SaveCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        List<Customer> GetCustomers();
        List<Customer> SearchCustomers(string query);
        Customer CheckLogin(string email, string password);
        bool UpdateProfile(Customer customer);
    }
}
