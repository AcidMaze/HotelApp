using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            monthCalendar1.SelectionEnd.Date.ToString("yyyy-MM-dd");
            monthCalendar1.SelectionStart = GuestInfo.Arrival_Date;
            monthCalendar1.SelectionEnd = GuestInfo.Depart_Date;
            cueTextBox1.Text = GuestInfo.Name;
            cueTextBox2.Text = GuestInfo.Phone;
            cueTextBox3.Text = GuestInfo.Passport;
            cueTextBox4.Text = GuestInfo.Room;

        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            GuestInfo.Room = null;
            monthCalendar1.SelectionEnd = DateTime.Today;
            monthCalendar1.SelectionStart = DateTime.Today;
        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
