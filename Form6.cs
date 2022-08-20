using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Conn;
using MySql.Data.MySqlClient;

namespace HotelApp
{
    public partial class Form6 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        private bool connOpen = false;
        public Form6()
        {

            InitializeComponent();
            try
            {
                if (connOpen == false)
                {
                    conn.Open();
                    connOpen = true;
                }
            }
            catch
            {
                connOpen = false;
                conn.Close();
            }
        }

        private void toolStripBtnAccept_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            monthCalendar1.SelectionEnd.Date.ToString("yyyy-MM-dd");
            DateInfo.Arrival_date = monthCalendar1.SelectionRange.Start;
            DateInfo.Depart_date = monthCalendar1.SelectionRange.End;
            string qry = "INSERT INTO `roms_orders` (idRoom, idGuest, arrival_date, depart_date)" + " VALUES (@idRoom, @idGuest, @arrival_date, @depart_date);";
            MySqlCommand command = new MySqlCommand(qry, conn);// Обращение к БД
            command.Parameters.AddWithValue("@idRoom", RoomInfo.ID);
            command.Parameters.AddWithValue("@idGuest", GuestInfo.ID);
            command.Parameters.AddWithValue("@idPersonal", PersonalInfo.ID);
            command.Parameters.AddWithValue("@arrival_date", DateInfo.Arrival_date);
            command.Parameters.AddWithValue("@depart_date", DateInfo.Depart_date);
            command.ExecuteNonQuery(); // Отправка запроса
            qry = "UPDATE `guests` SET `roomID` = " + RoomInfo.ID + " WHERE `id` = " + GuestInfo.ID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);// Обращение к БД
            cmd.ExecuteNonQuery(); // Отправка запроса
            MessageBox.Show(GuestInfo.Name + " заселён в комнату № " + RoomInfo.ID + " " + RoomInfo.Title, "Закрыть");
            DateInfo.Arrival_date = DateTime.Today;
            DateInfo.Depart_date = DateTime.Today;
            GC.Collect();
            this.Close();
        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            DateInfo.Arrival_date = DateTime.Today;
            DateInfo.Depart_date = DateTime.Today;
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
    class DateInfo
    {
        static public DateTime Arrival_date { get; set; }
        static public DateTime Depart_date { get; set; }
    }
}
