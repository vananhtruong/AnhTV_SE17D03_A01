using BussinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository iCustomerRepository;
        public CustomerService()
        {
            iCustomerRepository = new CustomerRepository();
        }
        public void SaveCustomer(Customer customer)
        {
            iCustomerRepository.SaveCustomer(customer);
        }
        public bool UpdateCustomer(Customer customer)
        {
            return iCustomerRepository.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int customerId)
        {
            iCustomerRepository.DeleteCustomer(customerId);
        }
        public List<Customer> GetCustomers()
        {
            return iCustomerRepository.GetCustomers();
        }
        public List<Customer> SearchCustomers(string query)
        {
            return iCustomerRepository.SearchCustomers(query);
        }
        public Customer? CheckLogin(string email, string password)
        {
            return iCustomerRepository.CheckLogin(email, password);
        }
        public bool UpdateProfile(Customer customer)
        {
            return iCustomerRepository.UpdateProfile(customer);
        }


    }
}
