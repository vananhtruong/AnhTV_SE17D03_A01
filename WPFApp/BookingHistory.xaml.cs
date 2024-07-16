using BussinessObject;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System.Windows;
using System.Windows.Controls;


namespace WPFApp
{
    /// <summary>
    /// Interaction logic for BookingHistory.xaml
    /// </summary>
    public partial class BookingHistory : UserControl
    {
        private readonly IReservationService booking;
        public Customer Customer { get; set; }
        public BookingHistory()
        {
            InitializeComponent();
            booking = new ReservationService();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            List<BookingReservation> bookingDetails = booking.GetReservationsByCustomerId(Customer.CustomerId);
            dgBookingHistory.ItemsSource = null;
            dgBookingHistory.ItemsSource = bookingDetails;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditBookingDialog addEditBookingDialog = new AddEditBookingDialog();
            addEditBookingDialog.Customer = Customer;
            if (addEditBookingDialog.ShowDialog() == true)
            {
                LoadData();
            }
        }
        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookingHistory.SelectedItem is BookingReservation selectedBooking)
            {
                if (MessageBox.Show($"Are you sure you want to view detail of booking {selectedBooking.BookingReservationId}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ViewBookingDetailDialog detailDialog = new ViewBookingDetailDialog
                    {
                        idbooking = selectedBooking.BookingReservationId
                    };
                    detailDialog.Load(); // Gọi Load() sau khi gán giá trị
                    detailDialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.", "Delete Booking", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //private void btnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    AddEditBookingDialog addEditBookingDialog = new AddEditBookingDialog();
        //    addEditBookingDialog.Customer = Customer;
        //    //addEditBookingDialog.Booking = 
        //    if (addEditBookingDialog.ShowDialog() == true)
        //    {
        //        LoadData();
        //    }
        //}

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookingHistory.SelectedItem is BookingReservation selectedBooking)
            {
                if (MessageBox.Show($"Are you sure you want to delete Customer {selectedBooking.BookingReservationId}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    booking.UpdateBooking(selectedBooking);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.", "Delete Booking", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void dgBookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }

        
    }
}
