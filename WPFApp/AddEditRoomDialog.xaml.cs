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
                txtDescription.Text = room.RoomDetailDescription;
                txtMaxCapacity.Text = room.RoomMaxCapacity.ToString(); ;
                txtPrice.Text = room.RoomPricePerDay.ToString();
                var typeList = roomTypeService.GetRoomTypes();
                cboRoomType.ItemsSource = typeList;
                cboRoomType.DisplayMemberPath = "RoomTypeName";
                cboRoomType.SelectedValuePath = "RoomTypeId";
                cboRoomType.SelectedValue = room.RoomTypeId;
            }
            else
            {
                Room = new RoomInformation();
                var typeList = roomTypeService.GetRoomTypes();
                cboRoomType.ItemsSource = typeList;
                cboRoomType.DisplayMemberPath = "RoomTypeName";
                cboRoomType.SelectedValuePath = "RoomTypeId";
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
                Room.RoomNumber = txtRoomNumber.Text;
                Room.RoomDetailDescription = txtDescription.Text;
                Room.RoomMaxCapacity = int.Parse(txtMaxCapacity.Text);
                Room.RoomStatus = 1;
                Room.RoomPricePerDay = decimal.Parse(txtPrice.Text);
                Room.RoomTypeId =  (int)cboRoomType.SelectedValue;
                //Room.RoomType =(RoomType) cboRoomType.SelectedItem;

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
