using DataAccessLayer;
using System.Windows;
using BussinessObject;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AddEditCustomerDialog.xaml
    /// </summary>
    public partial class AddEditCustomerDialog : Window
    {
        public Customer Customer { get; set; }

        public AddEditCustomerDialog(Customer customer = null)
        {
            InitializeComponent();
            if (customer != null)
            {
                
                Customer = customer;
                txtFullName.Text = customer.CustomerFullName;
                txtTelephone.Text = customer.Telephone;
                txtEmail.Text = customer.EmailAddress;
                dpBirthday.SelectedDate = customer.CustomerBirthday;
                txtPassword.Text = customer.Password;
            }
            else
            {
                Customer = new Customer();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFullName.Text) &&
                !string.IsNullOrEmpty(txtTelephone.Text) &&
                !string.IsNullOrEmpty(txtEmail.Text) &&
                dpBirthday.SelectedDate != null &&
                !string.IsNullOrEmpty(txtPassword.Text))
            {
                // All fields are filled, proceed with assigning values
                Customer.CustomerID = CustomerDAO.GenerateID();
                Customer.CustomerFullName = txtFullName.Text;
                Customer.Telephone = txtTelephone.Text;
                Customer.EmailAddress = txtEmail.Text;
                Customer.CustomerBirthday = dpBirthday.SelectedDate;
                Customer.CustomerStatus = "Active";
                Customer.Password = txtPassword.Text;

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
