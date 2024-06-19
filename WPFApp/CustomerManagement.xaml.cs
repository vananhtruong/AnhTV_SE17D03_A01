using Services;
using System.Windows;
using System.Windows.Controls;
using BussinessObject;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : UserControl
    {
        private readonly ICustomerService customerService;

        public CustomerManagement()
        {
            InitializeComponent();
            customerService = new CustomerService();
            LoadData();
        }

        private void LoadData()
        {
            dgCustomers.ItemsSource = null;
            var customers = customerService.GetCustomers(); 
            dgCustomers.ItemsSource = customers;
        }



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    var customers = customerService.SearchCustomers(txtSearch.Text);
                    dgCustomers.ItemsSource = null;
                    dgCustomers.ItemsSource = customers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LoadData();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addEditCustomerDialog = new AddEditCustomerDialog();
            if (addEditCustomerDialog.ShowDialog() == true)
            {
                var newCustomer = addEditCustomerDialog.Customer;
                customerService.SaveCustomer(newCustomer);
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                var addEditCustomerDialog = new AddEditCustomerDialog(selectedCustomer);
                if (addEditCustomerDialog.ShowDialog() == true)
                {
                    var updatedCustomer = addEditCustomerDialog.Customer;
                    customerService.UpdateCustomer(updatedCustomer);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Edit Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                if (MessageBox.Show($"Are you sure you want to delete Customer {selectedCustomer.CustomerFullName}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedCustomer.CustomerStatus = "Non-Active";
                    customerService.DeleteCustomer(selectedCustomer.CustomerID);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
