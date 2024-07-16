using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        private readonly FuminiHotelManagementContext dbcontext;

        private CustomerDAO()
        {
            if (instance == null)
            {
                dbcontext = new FuminiHotelManagementContext();
            }
        }

        //instance singleton
        public static CustomerDAO getInstance()
        {
            if (instance == null)
            {
                instance = new CustomerDAO();
            }
            return instance;
        }



        public List<Customer> GetCustomers()
        {
            var list = new List<Customer>();
            try
            {
                list = dbcontext.Customers.ToList();

                var sortedListAscending = list.OrderBy(c => c.CustomerFullName).ToList(); // tang dan
                var sortedListDescending = list.OrderByDescending(c => c.CustomerFullName).ToList();// giam dan
                var sortedListAscendingByDate = list.OrderBy(c => c.CustomerBirthday).ToList();



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public void SaveCustomer(Customer customer)
        {
            try
            {
                
                if(customer!=null)
                {
                    dbcontext.Add(customer);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public  bool UpdateCustomer(Customer customer)
        {
            bool isUpdated = false;
            try
            {
                if (customer != null)
                {
                    dbcontext.Update(customer);
                    dbcontext.SaveChanges();
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return isUpdated;
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                if (customerId != null)
                {
                    var customer = dbcontext.Customers.FirstOrDefault(x => x.CustomerId == customerId);
                    dbcontext.Remove(customer);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Customer> SearchCustomers(string query)
        {
            return dbcontext.Customers.Where(c => c.CustomerFullName.Contains(query) ||
                                           c.EmailAddress.Contains(query) ||
                                           c.Telephone.Contains(query)).ToList();
        }
        public  Customer CheckLogin(string email, string password)
        {
            Customer customer = null;
            foreach (Customer p in dbcontext.Customers.ToList())
            {
                if (p.EmailAddress == email)
                {
                    if(p.Password == password) customer = p;
                }
            }

            return customer;
        }
        public static bool UpdateProfile(Customer customer)
        {
            bool isUpdated = false;
            try
            {
                if (customer != null)
                {
                    instance.dbcontext.Update(customer);
                    instance.dbcontext.SaveChanges();
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isUpdated;

        }
    }
}
