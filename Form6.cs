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
        public Form6()
        {
            InitializeComponent();
        }

        private void toolStripBtnAccept_Click(object sender, EventArgs e)
        {
            DateInfo.Arrival_date = monthCalendar1.SelectionRange.Start.ToShortDateString();
            DateInfo.Depart_date = monthCalendar1.SelectionRange.End.ToShortDateString();
            conn.Open();
            string qry = "INSERT INTO `roms_orders` (idRoom, idGuest, arrival_date, depart_date)" + " VALUES (@idRoom, @idGuest, @arrival_date, @depart_date);";
            MySqlCommand command = new MySqlCommand(qry, conn);// Обращение к БД
            command.Parameters.AddWithValue("@idRoom", RoomInfo.ID);
            command.Parameters.AddWithValue("@idGuest", GuestInfo.ID);
            command.Parameters.AddWithValue("@arrival_date", DateInfo.Arrival_date);
            command.Parameters.AddWithValue("@depart_date", DateInfo.Depart_date);
            command.ExecuteNonQuery(); // Отправка запроса
            qry = "UPDATE `guests` SET `roomID` = " + RoomInfo.ID + " WHERE `id` = " + GuestInfo.ID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);// Обращение к БД
            cmd.ExecuteNonQuery(); // Отправка запроса
            conn.Close();
            MessageBox.Show(GuestInfo.Name + "заселён в комнату №" + RoomInfo.ID + " " + RoomInfo.Title, "Закрыть");
            DateInfo.Arrival_date = null;
            DateInfo.Depart_date = null;
            GC.Collect();
            this.Close();
        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            DateInfo.Arrival_date = null;
            DateInfo.Depart_date = null;
            this.Close();
        }
    }
    class DateInfo
    {
        static public string Arrival_date { get; set; }
        static public string Depart_date { get; set; }
    }
}
