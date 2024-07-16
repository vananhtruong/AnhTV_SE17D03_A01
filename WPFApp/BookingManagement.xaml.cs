using BussinessObject;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for BookingManagement.xaml
    /// </summary>
    public partial class BookingManagement : UserControl
    {
        private readonly IReservationService booking;
        public BookingManagement()
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
            List<BookingReservation> bookingDetails = booking.GetReservations();
            dgBookingHistory.ItemsSource = null;
            dgBookingHistory.ItemsSource = bookingDetails;
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
        private void dgBookingHistory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
