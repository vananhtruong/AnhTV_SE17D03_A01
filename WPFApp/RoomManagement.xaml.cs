using Services;
using System.Windows;
using System.Windows.Controls;
using BussinessObject;
using DataAccessLayer;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for RoomManagement.xaml
    /// </summary>
    public partial class RoomManagement : UserControl
    {
        private readonly IRoomInformationService roomInformationService;

        public RoomManagement()
        {
            InitializeComponent();
            roomInformationService = new RoomInformationService();

            LoadData();
        }
        private void LoadData()
        {
            dgRooms.ItemsSource = null;
            var rooms = roomInformationService.GetRoomInformations(); // Gọi phương thức
            dgRooms.ItemsSource = rooms;
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                try
                {
                    var rooms = roomInformationService.SearchRoom(txtSearch.Text);
                    dgRooms.ItemsSource = null;
                    dgRooms.ItemsSource = rooms;
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        //private void dgRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // Implement selection changed logic if necessary
        //}

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var addEditRoomDialog = new AddEditRoomDialog();
            if (addEditRoomDialog.ShowDialog() == true)
            {
                var newRoom = addEditRoomDialog.Room;
                newRoom.RoomID = RoomInformationDAO.Generateint();
                roomInformationService.SaveRoom(newRoom);
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is RoomInformation selectedRoom)
            {
                var addEditRoomDialog = new AddEditRoomDialog(selectedRoom);
                if (addEditRoomDialog.ShowDialog() == true)
                {
                    var updatedRoom = addEditRoomDialog.Room;
                    roomInformationService.UpdateRoom(updatedRoom);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a room to edit.", "Edit Room", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is RoomInformation selectedRoom)
            {
                if (MessageBox.Show($"Are you sure you want to delete Room {selectedRoom.RoomNumber}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    selectedRoom.RoomStatus = "Non-Active";
                    //roomInformationService.UpdateRoom(selectedRoom);
                    roomInformationService.DeleteRoom(selectedRoom);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.", "Delete Room", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


    }
}
