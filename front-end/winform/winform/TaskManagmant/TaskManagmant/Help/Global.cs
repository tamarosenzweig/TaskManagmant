using BOL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskManagmant.Forms;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Collections;

namespace TaskManagmant.Help
{
    public static class Global
    {
        public static string HOST { get; set; } = $"{ConfigurationManager.AppSettings["host"] }/api";

        public static User USER { get; set; }

        public static Size SIZE { get; set; }

        public static object UPLOADS { get; set; } = $"{ConfigurationManager.AppSettings["host"] }/Images";

        public static bool createDialog(Form form, string title, string msg, bool dialog)
        {
            DialogResult result;
            using (var popup = new Form())
            {
                popup.Size = new Size(400, 185);
                popup.AutoSize = true;
                popup.FormBorderStyle = FormBorderStyle.FixedDialog;
                popup.MinimizeBox = false;
                popup.MaximizeBox = false;
                popup.Text = title;
                var lbl = new Label();
                lbl.AutoSize = true;
                lbl.Padding = new Padding(20);
                lbl.MaximumSize = new Size(popup.Width - 20, popup.Height);
                lbl.Font = new Font("Microsoft Sans Serif", 14f);
                lbl.ForeColor = Color.Orange;
                lbl.Text = msg;
                popup.Controls.Add(lbl);
                // HERE you will add your dynamic button creation instead of  my hardcoded
                if (dialog)
                {
                    var btnYes = new Button { Text = "Yes" };
                    btnYes.Location = new Point((popup.Width / 2 - btnYes.Width) - 20, lbl.Location.Y + lbl.Height + 20);
                    btnYes.Click += (s, ea) => { ((Form)((Control)s).Parent).DialogResult = DialogResult.Yes; ((Form)((Control)s).Parent).Close(); };
                    popup.Controls.Add(btnYes);
                    var btnNo = new Button { Text = "No" };
                    btnNo.Location = new Point(popup.Width / 2 + 20, lbl.Location.Y + lbl.Height + 20);
                    btnNo.Click += (s, ea) => { ((Form)((Control)s).Parent).DialogResult = DialogResult.No; ((Form)((Control)s).Parent).Close(); };
                    popup.Controls.Add(btnNo);
                }
                else
                {
                    var btnOK = new Button { Text = "OK" };
                    btnOK.Location = new Point((popup.Width - btnOK.Width) / 2, lbl.Location.Y + lbl.Height + 20);

                    btnOK.Click += (s, ea) => { ((Form)((Control)s).Parent).DialogResult = DialogResult.OK; ((Form)((Control)s).Parent).Close(); };
                    popup.Controls.Add(btnOK);
                }
                popup.StartPosition = FormStartPosition.CenterParent;
                result = popup.ShowDialog();

            }
            return result == DialogResult.Yes ? true : false;
        }

        public static Byte[] ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return hashedBytes;
        }

        public static string ComputeHashToSha256(string input)
        {
            Byte[] hashedBytes = ComputeHash(input, new SHA256CryptoServiceProvider());

            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        public static string ToPercent(double num)
        {
            return $"{Math.Round(num * 10000) / 100}%";
        }

        public static double ToShortNumber(double num, int digits = 2)
        {
            if (digits <= 0)
                return Math.Round(num);
            double x = Math.Pow(10, digits);
            return Math.Round(num * x) / x;
        }

        public static double DateDiffInHours(DateTime date1, DateTime date2)
        {
            double hours = (date2 - date1).TotalHours;
            return hours;
        }

        public static double DateDiffInDays(DateTime date1, DateTime date2)
        {
            double days = (date2 - date1).TotalDays + 1;
            if (days < 1)
                days = 1;
            return days;
        }

        public static void UpdateCurrentUser(string value)
        {
            XmlDocument doc = new XmlDocument();
            string path = Path.GetFullPath("..\\..\\") + "app.config";
            doc.Load(path);
            IEnumerator ie = doc.SelectNodes("/configuration/appSettings/add").GetEnumerator();

            while (ie.MoveNext())
            {
                if ((ie.Current as XmlNode).Attributes["key"].Value == "currentUserId")
                {
                    (ie.Current as XmlNode).Attributes["value"].Value = value;
                }
            }
            doc.Save(path);
        }
    }
}
