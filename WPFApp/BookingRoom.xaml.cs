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
    /// Interaction logic for BookingRoom.xaml
    /// </summary>
    public partial class BookingRoom : UserControl
    {
        public Customer Customer { get; set; }
        private readonly IRoomInformationService _roomInformationService;
        private readonly IReservationService _reservationService;
        public BookingRoom()
        {
            InitializeComponent();
            _roomInformationService = new RoomInformationService();
            _reservationService = new ReservationService();
            this.Loaded += Window_Loaded;
        }
        public void LoadRoomList()
        {
            try
            {
                var roomList = _roomInformationService.GetRoomInformations();
                dgData.ItemsSource = null;
                dgData.ItemsSource = roomList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of reservations");
            }
            finally
            {
                ResetInput();
            }
        }
        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;

            // Check if any row is selected
            if (dataGrid.SelectedIndex >= 0)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)RowColumn.Content).Text;
                RoomInformation room = _roomInformationService.GetRoomById(Int32.Parse(id));
                txtRoomID.Text = room.RoomID.ToString();
            }
        }
        private void ResetInput()
        {
            txtRoomID.Text = "";
            dpStartDay.Text = "";
            dpEndDay.Text = "";
        }
        private void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                Reservation reservation = new Reservation();
                reservation.Id = _reservationService.GetReservations().Count + 1;
                reservation.CustomerId = Customer.CustomerID;
                reservation.RoomId = Int32.Parse(txtRoomID.Text);
                reservation.StartDate = (DateTime)dpStartDay.SelectedDate;
                reservation.EndDate =(DateTime) dpEndDay.SelectedDate;
                bool result = _reservationService.AddReservations(reservation);
                if (result) MessageBox.Show("Booking successfully!");
                else MessageBox.Show("Error!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomList();
        }


    }
}
