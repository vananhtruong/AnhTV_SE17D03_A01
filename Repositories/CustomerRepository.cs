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
        public void SaveCustomer(Customer customer) => CustomerDAO.getInstance().SaveCustomer(customer);
        public bool UpdateCustomer(Customer customer) => CustomerDAO.getInstance().UpdateCustomer(customer);
        public void DeleteCustomer(int customerId) => CustomerDAO.getInstance().DeleteCustomer(customerId);
        public List<Customer> GetCustomers() => CustomerDAO.getInstance().GetCustomers();
        public List<Customer> SearchCustomers(string query) => CustomerDAO.getInstance().SearchCustomers(query);
        public Customer CheckLogin(string email,string password) => CustomerDAO.getInstance().CheckLogin(email, password);
        public bool UpdateProfile(Customer customer) => CustomerDAO.UpdateProfile(customer);
    }
}
