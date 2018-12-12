using TaskManagmant.Help;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagmant.UserControls
{
    public partial class HeaderControl : UserControl
    {
        public HeaderControl()
        {
            InitializeComponent();

            string imageUrl = $"{Global.UPLOADS}/UsersProfiles/";
            if (Global.USER != null)
            {
                lblUserName.Text = $"Hello {Global.USER.UserName}";
                if (Global.USER.ProfileImageName != null)
                    imageUrl += Global.USER.ProfileImageName;
                else
                    imageUrl += "guest.jpg";
            }
            else
            {
                imageUrl += "guest.jpg";
                lblUserName.Text = "Welcome";
            }
            try
            {
                picUserProfile.Load(imageUrl);
                picUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
                picUserProfile.BackColor = Color.Transparent;
            }
            catch
            {}
        }
    }
}
