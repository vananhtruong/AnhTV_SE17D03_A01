using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AddEditBookingDialog.xaml
    /// </summary>
    public partial class AddEditBookingDialog : Window
    {
        public Customer Customer { get; set; }

        private readonly IRoomInformationService roomInformationService;
        private readonly IReservationService reservationService;
        public BookingReservation Booking { get; private set; }
        private RoomInformation room { get; set; }
        public List<BookingDetail> bookingDetailsDTOs { get; set; }

        public AddEditBookingDialog()
        {
            InitializeComponent();
            roomInformationService = new RoomInformationService();
            reservationService = new ReservationService();
            if (Booking is null)
            {
                Booking = new BookingReservation();
                bookingDetailsDTOs = new List<BookingDetail>();
            }
            //else
            //{
            //    bookingDetailsDTOs = Booking.BookingDetails;
            //}
            Loaded += LoadRooms;
            Loaded += LoadBookingDetails;
        }

        private void LoadRooms(object sender, RoutedEventArgs e)
        {
            var data = roomInformationService.GetRoomInformations();
            dgAvailableRooms.ItemsSource = null;
            dgAvailableRooms.ItemsSource = data;
        }

        private void LoadBookingDetails(object sender, RoutedEventArgs e)
        {
            dgBookingDetails.ItemsSource = null;
            dgBookingDetails.ItemsSource = bookingDetailsDTOs;

            txtTotalPrice.Text = CalculateTotalPrice().ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.SelectedDate == null || dpEndDate.SelectedDate == null)
            {
                MessageBox.Show("You should select a date");
                return;
            }

            if (dgAvailableRooms.SelectedItems.Count > 0)
            {
                room = (RoomInformation)dgAvailableRooms.SelectedItem;
                foreach(var r in bookingDetailsDTOs)
                {

                    if (r.Room.RoomId == room.RoomId)
                    {
                        MessageBox.Show("Room has in list");
                        return;
                    }
                }
                DateTime startDate = dpStartDate.SelectedDate.Value;
                DateTime endDate = dpEndDate.SelectedDate.Value;
                int daysDifference = (endDate - startDate).Days;
                var TotalPrice = (daysDifference * room.RoomPricePerDay);

                var bookingDetail = new BookingDetail()
                {
                    Room = room, // Sử dụng đối tượng RoomInformation hiện có
                    StartDate = DateOnly.FromDateTime(dpStartDate.SelectedDate.Value),
                    EndDate = DateOnly.FromDateTime(dpEndDate.SelectedDate.Value),
                    ActualPrice = TotalPrice,
                };

                bookingDetailsDTOs.Add(bookingDetail);
                LoadBookingDetails(sender, e);
            }
        }





        private decimal? CalculateTotalPrice()
        {
            decimal? total = 0;

            foreach (var item in bookingDetailsDTOs)
            {
                //total += item.ActualPrice;
                total += (item.ActualPrice * (item.EndDate.ToDateTime(new TimeOnly()) - item.StartDate.ToDateTime(new TimeOnly())).Days);
            }

            return total;
        }

        private void dgAvailableRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgAvailableRooms.SelectedItems.Count > 0)
            {
                room = (RoomInformation)dgAvailableRooms.SelectedItem;
                txtRoomId.Text = room.RoomId.ToString();
                txtRoomNumber.Text = room.RoomNumber;
                txtNumPerson.Text = room.RoomMaxCapacity.ToString();
                txtPrice.Text = room.RoomPricePerDay.ToString();
            }
        }

        private void dpDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                DateTime startDate = dpStartDate.SelectedDate.Value;
                DateTime endDate = dpEndDate.SelectedDate.Value;

                int daysDifference = (endDate - startDate).Days;
                var TotalPrice = (daysDifference * room.RoomPricePerDay);
                txtTotalPrice.Text = TotalPrice.ToString();

                if (startDate < DateTime.Today || endDate < DateTime.Today)
                {
                    txtTotalPrice.Text = "0";
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgBookingDetails.SelectedItems.Count > 0)
            {
                var bookingdetail = (BookingDetail)dgBookingDetails.SelectedItem;
                bookingDetailsDTOs.Remove(bookingdetail);
                LoadBookingDetails(sender, e);
            }
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
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Booking.BookingDate = DateOnly.FromDateTime(DateTime.Today);
                Booking.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                Booking.CustomerId = Customer.CustomerId;
                Booking.BookingStatus = 1;

                // Ensure RoomInformation entities are retrieved correctly
                foreach (var detail in bookingDetailsDTOs)
                {
                    var existingRoom = roomInformationService.GetRoomById(detail.Room.RoomId);
                    if (existingRoom != null)
                    {
                        detail.Room = existingRoom;
                    }
                }

                Booking.TotalPrice = CalculateTotalPrice();

                // Pass the booking and details without setting identity columns explicitly
                reservationService.AddReservations(Booking, bookingDetailsDTOs);
                //reset data
                Booking = null;
                bookingDetailsDTOs = null;
                DialogResult = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }


        }







    }
}
