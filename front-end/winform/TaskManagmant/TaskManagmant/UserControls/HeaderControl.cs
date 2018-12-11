using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagmant.Help;

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
            picUserProfile.Load(imageUrl);
            picUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            picUserProfile.BackColor = Color.Transparent;
        }

    }
}
