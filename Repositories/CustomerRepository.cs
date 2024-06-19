using BussinessObject;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public void SaveCustomer(Customer customer) => CustomerDAO.SaveCustomer(customer);
        public bool UpdateCustomer(Customer customer) => CustomerDAO.UpdateCustomer(customer);
        public void DeleteCustomer(int customerId) => CustomerDAO.DeleteCustomer(customerId);
        public List<Customer> GetCustomers() => CustomerDAO.GetCustomers();
        public List<Customer> SearchCustomers(string query) => CustomerDAO.SearchCustomers(query);
        public Customer CheckLogin(string email,string password) => CustomerDAO.CheckLogin(email, password);
        public bool UpdateProfile(Customer customer) => CustomerDAO.UpdateProfile(customer);
    }
}
