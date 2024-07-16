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
using System.Windows.Shapes;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for ViewBookingDetailDialog.xaml
    /// </summary>
    public partial class ViewBookingDetailDialog : Window
    {
        private readonly IBookingDetailService _bookDetailService;
        public int idbooking { get; set; }
        public List<BookingDetail> bookingDetails { get; set; }

        public ViewBookingDetailDialog()
        {
            InitializeComponent();
            _bookDetailService = new BookingDetailService();
        }

        public void Load()
        {
            bookingDetails = _bookDetailService.GetBookingById(idbooking);
            dgBookingDetails.ItemsSource = null;
            dgBookingDetails.ItemsSource = bookingDetails;
        }

        private void dgBookingDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgBookingDetails.SelectedItems.Count > 0)
            {
                var bookingdetail = (BookingDetail)dgBookingDetails.SelectedItem;
                txtRoomIdDB.Text = bookingdetail.Room.RoomId.ToString();
                txtRoomNumDB.Text = bookingdetail.Room.RoomNumber;
                dpStartDateDB.SelectedDate = bookingdetail.StartDate.ToDateTime(TimeOnly.MinValue);
                dpEndDateDB.SelectedDate = bookingdetail.EndDate.ToDateTime(TimeOnly.MinValue);
                txtActualPrice.Text = bookingdetail.ActualPrice.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
