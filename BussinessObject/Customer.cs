
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string? CustomerFullName { get; set; }
        public string? Telephone { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime? CustomerBirthday { get; set; }
        public string? CustomerStatus { get; set; }
        public string? Password { get; set; }
        public Customer() { }
        public Customer(int customerID, string? customerFullName, string? telephone, string? emailAddress, DateTime? customerBirthday, string? customerStatus, string? password)
        {
            CustomerID = customerID;
            CustomerFullName = customerFullName;
            Telephone = telephone;
            EmailAddress = emailAddress;
            CustomerBirthday = customerBirthday;
            CustomerStatus = customerStatus;
            Password = password;
        }

        public virtual ICollection<BookingReservation> BookingReservations { get; set; } = new List<BookingReservation>();

        public override string? ToString()
        {
            return base.ToString();
        }
    }

}
