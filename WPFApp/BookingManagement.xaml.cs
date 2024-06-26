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
        private readonly IReservationService _reservationService;
        public BookingManagement()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
        }
        public void LoadReservations(List<Reservation> res = null)
        {
            try
            {
                List<Reservation> reservations;
                if (res != null)
                {
                    reservations = res;
                }
                else
                {
                    reservations = _reservationService.GetReservations();
                }
                dgData.ItemsSource = null;
                dgData.ItemsSource = reservations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of reservations");
            }
        }
        private void ResetInput()
        {
            dpStartDay.Text = "";
            dpEndDay.Text = "";
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startDate =(DateTime) dpStartDay.SelectedDate;
                DateTime endDate = (DateTime)dpEndDay.SelectedDate;
                var reservations = _reservationService.Search(startDate, endDate);
                LoadReservations(reservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadReservations();
        }
    }
}
