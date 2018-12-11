using System.Drawing;
using System.Windows.Forms;
using TaskManagmant.Help;

namespace TaskManagmant.Forms
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Location = new Point(0, 0);
            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Global.SIZE = Size;
            Font = new Font("Segoe UI", 12);

        }
    }
}
