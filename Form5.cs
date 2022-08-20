using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Conn;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace HotelApp
{
    public partial class Form5 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        private bool connOpen = false;
        public Form5()
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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            GuestInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
            GuestInfo.Name = row.Cells[1].Value.ToString();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            GuestInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
            GuestInfo.Name = row.Cells[1].Value.ToString();
            GuestInfo.Phone = row.Cells[2].Value.ToString();
            GuestInfo.Passport = row.Cells[3].Value.ToString();
            GuestInfo.roomID = Int32.Parse(row.Cells[4].Value.ToString());
            if (connOpen == true)
            {
                MySqlDataReader dataReader;
                MySqlDataReader dataReader2;
                string query = "SELECT `arrival_date`, `depart_date` FROM `roms_orders` WHERE `idRoom` = " + RoomInfo.ID + " AND " + "`idGuest` = " + GuestInfo.ID;
                MySqlCommand command = new MySqlCommand(query, conn);// Обращение к БД
                dataReader = command.ExecuteReader(); // Отправка запроса
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    GuestInfo.Arrival_Date = dataReader.GetDateTime(0);
                    GuestInfo.Depart_Date = dataReader.GetDateTime(1);
                    dataReader.Close();
                    string qry = "SELECT `title` FROM `rooms` WHERE `id`= " + GuestInfo.roomID;
                    MySqlCommand cmd = new MySqlCommand(qry, conn);// Обращение к БД
                    dataReader2 = cmd.ExecuteReader(); // Отправка запроса
                    if (dataReader2.HasRows)
                    {
                        dataReader2.Read();
                        GuestInfo.Room = dataReader2.GetString(0);
                    }
                    dataReader2.Close();
                }
                dataReader.Close();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadRoomInfo();
            LoadRoomGuest();
            LoadAllGuests();
        }


        private void LoadRoomGuest()
        {
            MySqlDataReader dataReader;
            string query = "SELECT * FROM `guests` WHERE `roomID` = " + RoomInfo.ID;
            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
            dataReader = cmd.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataGridView2.DataSource = UpdateGrid(dataReader);
                dataGridView2.Columns[0].HeaderText = "№";
                dataGridView2.Columns[1].HeaderText = "ФИО";
                dataGridView2.Columns[2].HeaderText = "Моб.телефон";
                dataGridView2.Columns[3].HeaderText = "Паспорт";
                dataGridView2.Columns[4].Visible = false;
            }
            dataReader.Close();
            GC.Collect();
        }

        private void LoadRoomInfo()
        {
            MySqlDataReader dataReader;
            string query = "SELECT * FROM `rooms` WHERE `id` = '" + RoomInfo.ID + "' LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
            dataReader = cmd.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataReader.Read();
                cueTextBox4.Text = dataReader.GetString(1);
                cueTextBox2.Text = dataReader.GetInt32(2).ToString();
                richTextBox1.Text = dataReader.GetString(3);
                cueTextBox3.Text = dataReader.GetInt32(4).ToString();
            }
            dataReader.Close();
            GC.Collect();
        }

        private void LoadAllGuests()
        {
            MySqlDataReader dataReader;
            string query = "SELECT * FROM `guests`";
            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
            dataReader = cmd.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataGridView1.DataSource = UpdateGrid(dataReader);
                dataGridView1.Columns[0].HeaderText = "№";
                dataGridView1.Columns[1].HeaderText = "ФИО";
                dataGridView1.Columns[2].HeaderText = "Моб.телефон";
                dataGridView1.Columns[3].HeaderText = "Паспорт";
                dataGridView1.Columns[4].Visible = false;
            }
            dataReader.Close();
            GC.Collect();
        }


        private DataTable UpdateGrid(MySqlDataReader dataReader)
        {
            DataTable table = new DataTable();
            table.Load(dataReader);
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Visible = false;
                for (int c = 0; c < dataGridView1.Columns.Count; c++)
                {
                    if (dataGridView1[c, i].Value.ToString() == cueTextBox1.Text)
                    {
                        dataGridView1.Rows[i].Visible = true;
                        break;
                    }
                }
            }
        }



        private void заселенитьВКомнатуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MySqlDataReader dataReader;
            string query = "SELECT `roomID` FROM `guests`";
            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
            dataReader = cmd.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataReader.Read();
                int num =  dataReader.GetInt32(0);
                if (num > 0)
                {
                    MessageBox.Show("Гость уже проживает в номере № " + num, "Закрыть");
                    dataReader.Close();
                }
                else
                {
                    Form SelectDate = new Form6();
                    DialogResult dialogResult = SelectDate.ShowDialog();
                    if (dialogResult == DialogResult.Cancel)
                    {
                        dataReader.Close();
                        LoadRoomGuest();
                    }
                }
            }   
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            string name = GuestInfo.Name;
            DialogResult dialogResult = MessageBox.Show("Вы действительно выселить  - " + name + " из №" + RoomInfo.ID + " " + RoomInfo.Title + "?", "Выселить гостя " + name, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string qry = "UPDATE `guests` SET `roomID` = 0" + " WHERE `id` = " + GuestInfo.ID;
                MySqlCommand cmd = new MySqlCommand(qry, conn);// Обращение к БД
                cmd.ExecuteNonQuery(); // Отправка запроса
                string query = "DELETE FROM `roms_orders` WHERE `idRoom` = " + RoomInfo.ID + " AND " + "`idGuest` = " + GuestInfo.ID;
                MySqlCommand command = new MySqlCommand(query, conn);// Обращение к БД
                command.ExecuteNonQuery(); // Отправка запроса
                MessageBox.Show("Постоялец - " + name + "успешно выселен из №" + RoomInfo.ID + " " + RoomInfo.Title, "Закрыть");
                LoadRoomGuest();
                GC.Collect();
            }
            else if (dialogResult == DialogResult.No)
            {
                // Отмена
            }
        }

        private void информациияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form GuestInfForm = new Form7();
            GuestInfForm.Text = "Информация и постояльце - " + GuestInfo.Name;
            GuestInfForm.ShowDialog();
        }
    }
}
