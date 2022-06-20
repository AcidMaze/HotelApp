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
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            GuestInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
            GuestInfo.Name = row.Cells[1].Value.ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadRoomInfo();
            LoadRoomGuest();
            LoadAllGuests();
        }


        private void LoadRoomGuest()
        {
            conn.Open();
            MySqlDataReader dataReader;
            string query = "SELECT * FROM `guests` WHERE `roomID` = " + RoomInfo.ID;
            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
            dataReader = cmd.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataGridView2.DataSource = UpdateGrid(dataReader);
                dataGridView2.Columns[4].Visible = false;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].HeaderText = "ФИО";
                dataGridView2.Columns[2].HeaderText = "Моб.телефон";
                dataGridView2.Columns[3].HeaderText = "Паспорт";
            }
            dataReader.Close();
            conn.Close();
            GC.Collect();
        }

        private void LoadRoomInfo()
        {
            conn.Open();
            MySqlDataReader dataReader;
            string query = "SELECT * FROM `rooms` WHERE `id` = '" + RoomInfo.ID + "' LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
            dataReader = cmd.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataReader.Read();
                cueTextBox4.Text = dataReader.GetString(1);
                cueTextBox2.Text = dataReader.GetInt32(2).ToString();
                richTextBox1.Text = dataReader.GetString(7);
                cueTextBox3.Text = dataReader.GetInt32(8).ToString();
            }
            dataReader.Close();
            conn.Close();
            GC.Collect();
        }

        private void LoadAllGuests()
        {
            conn.Open();
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
                dataGridView2.Columns[4].Visible = false;
            }
            dataReader.Close();
            conn.Close();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void заселенитьВКомнатуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(DateInfo.Arrival_date == null || DateInfo.Depart_date == null)
            {
                Form SelectDate = new Form6();
                DialogResult dialogResult = SelectDate.ShowDialog();
                if (dialogResult == DialogResult.Cancel)
                {
                    LoadRoomGuest();
                }
            }      
        }
    }
}
