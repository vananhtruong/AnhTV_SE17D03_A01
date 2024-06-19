using BussinessObject;
using Services;
using System.Windows;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for AddEditRoomDialog.xaml
    /// </summary>
    public partial class AddEditRoomDialog : Window
    {
        public RoomInformation Room { get; set; }
        private readonly IRoomTypeService roomTypeService;

        public AddEditRoomDialog(RoomInformation room = null)
        {
            InitializeComponent();
            roomTypeService = new RoomTypeService();

            if (room != null)
            {
                Room = room;
                txtRoomNumber.Text = room.RoomNumber;
                txtDescription.Text = room.RoomDescription;
                txtMaxCapacity.Text = room.RoomMaxCapacity.ToString(); ;
                txtPrice.Text = room.RoomPricePerDate.ToString();
                cboRoomType.SelectedValue = room.RoomTypeID;
                var typeList = roomTypeService.GetRoomTypes();
                cboRoomType.ItemsSource = typeList;
                cboRoomType.DisplayMemberPath = "RoomTypeName";
                cboRoomType.SelectedValuePath = "RoomTypeID"; 
            }
            else
            {
                Room = new RoomInformation();
                var typeList = roomTypeService.GetRoomTypes();
                cboRoomType.ItemsSource = typeList;
                cboRoomType.DisplayMemberPath = "RoomTypeName";
                cboRoomType.SelectedValuePath = "RoomTypeID";
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRoomNumber.Text) &&
                !string.IsNullOrEmpty(txtDescription.Text) &&
                !string.IsNullOrEmpty(txtMaxCapacity.Text) &&
                !string.IsNullOrEmpty(txtPrice.Text) &&
                !string.IsNullOrEmpty(cboRoomType.Text))
            {
                // All text fields are not null or empty, proceed with assigning values
                Room.RoomNumber = txtRoomNumber.Text;
                Room.RoomDescription = txtDescription.Text;
                Room.RoomMaxCapacity = int.Parse(txtMaxCapacity.Text);
                Room.RoomStatus = "Active";
                Room.RoomPricePerDate = decimal.Parse(txtPrice.Text);
                Room.RoomTypeID =  (int)cboRoomType.SelectedValue; 

                DialogResult = true;
                Close();
            }
            else
            {
                // Show a message indicating that all fields are required
                //MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
