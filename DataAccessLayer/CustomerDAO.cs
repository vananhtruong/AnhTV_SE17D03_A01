using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        public static List<Customer> listCustomer = new List<Customer>
        {
            new Customer(1, "Thao Huong", "0123456789", "abc@gmail.com", new DateTime(2003, 5, 15), "Active", "123"),
            new Customer(3, "Truong Van Anh", "0123456789", "123", new DateTime(2003, 5, 15), "Active", "123"),
            new Customer(2, "Thu Ha", "0987654321", "help@gmail.com", new DateTime(2003, 7, 15), "Active", "456")
        };

        public static List<Customer> GetCustomers()
        {
            return listCustomer;
        }

        public static void SaveCustomer(Customer customer)
        {
            listCustomer.Add(customer);
        }
        //public static void UpdateCustomer(Customer customer)
        //{
        //    foreach (Customer p in listCustomer.ToList())
        //    {
        //        if (p.CustomerID == customer.CustomerID)
        //        {
        //            p.CustomerID = customer.CustomerID;
        //            p.CustomerFullName = customer.CustomerFullName;
        //            p.Telephone = customer.Telephone;
        //            p.EmailAddress = customer.EmailAddress;
        //            p.CustomerBirthday = customer.CustomerBirthday;
        //            p.CustomerStatus = customer.CustomerStatus;
        //            p.Password = customer.Password;
        //        }
        //    }
        //}
        public static bool UpdateCustomer(Customer customer)
        {
            bool isUpdated = false;
            foreach (Customer p in listCustomer.ToList())
            {
                if (p.CustomerID == customer.CustomerID)
                {
                    p.CustomerID = customer.CustomerID;
                    p.CustomerFullName = customer.CustomerFullName;
                    p.Telephone = customer.Telephone;
                    p.EmailAddress = customer.EmailAddress;
                    p.CustomerBirthday = customer.CustomerBirthday;
                    p.CustomerStatus = customer.CustomerStatus;
                    p.Password = customer.Password;
                    isUpdated = true; 
                    break; 
                }
            }
            return isUpdated;
        }

        public static void DeleteCustomer(int customerId)
        {
            foreach (Customer p in listCustomer.ToList())
            {
                if (p.CustomerID == customerId)
                {
                    listCustomer.Remove(p);
                }
            }
        }

        public static List<Customer> SearchCustomers(string query)
        {
            return listCustomer.Where(c => c.CustomerFullName.Contains(query) ||
                                           c.EmailAddress.Contains(query) ||
                                           c.Telephone.Contains(query)).ToList();
        }
        public static Customer CheckLogin(string email, string password)
        {
            Customer customer = null;
            foreach (Customer p in listCustomer.ToList())
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
            foreach (Customer p in listCustomer.ToList())
            {
                if (p.CustomerID == customer.CustomerID)
                {
                    p.CustomerID = customer.CustomerID;
                    p.CustomerFullName = customer.CustomerFullName;
                    p.Telephone = customer.Telephone;
                    p.EmailAddress = customer.EmailAddress;
                    p.CustomerBirthday = customer.CustomerBirthday;
                    p.CustomerStatus = customer.CustomerStatus;
                    p.Password = customer.Password;
                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;

        }
        public static int GenerateID()
        {
            int id = 1;
            bool check = true;
            while (check)
            {
                check = false;
                foreach (var item in listCustomer)
                {
                    if (item.CustomerID == id) { id += 1; check = true; }
                }
            }

            



            return id;
        }
    }
}
