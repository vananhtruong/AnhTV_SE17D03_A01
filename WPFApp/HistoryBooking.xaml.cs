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
    /// Interaction logic for HistoryBooking.xaml
    /// </summary>
    public partial class HistoryBooking : UserControl
    {
        public Customer Customer { get; set; }
        private readonly IRoomInformationService _roomInformationService;
        private readonly IReservationService _reservationService;
        public HistoryBooking()
        {
            InitializeComponent();
            _roomInformationService = new RoomInformationService();
            _reservationService = new ReservationService();
            this.Loaded += Window_Loaded; ;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadReservations();

        }
        public void LoadReservations()
        {
            try
            {
                var reservations = _reservationService.GetReservationsByCustomerId(Customer.CustomerID);
                dgData.ItemsSource = null;
                dgData.ItemsSource = reservations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of rooms");
            }
        }
    }
}
