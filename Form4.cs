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
    public partial class Form4 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        public Form4()
        {
            InitializeComponent();
        }

        private void toolStripBtnAccept_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (cueTextBox1.Text != "" & cueTextBox2.Text != "" & cueTextBox3.Text != "")
            {
                string qry = "INSERT INTO `personal` (name, phone, dolznost)" + " VALUES (@name, @phone, @dolznost);";
                MySqlCommand command = new MySqlCommand(qry, conn);// Обращение к БД
                command.Parameters.AddWithValue("@name", cueTextBox1.Text);
                command.Parameters.AddWithValue("@phone", cueTextBox2.Text);
                command.Parameters.AddWithValue("@dolznost", cueTextBox3.Text);
                command.ExecuteNonQuery(); // Отправка запроса
                conn.Close();
                MessageBox.Show(cueTextBox1.Text + " добавлен", "Закрыть");
                GC.Collect();
                this.Close();
            }
            else
            {
                conn.Close();
                MessageBox.Show("Основные поля должны быть заполнены.", "Закрыть");
            }
        }
    }
}
