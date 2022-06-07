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
    public partial class Form2 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBtnAccept_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (cueTextBox1.Text != "" & cueTextBox2.Text != "" & cueTextBox3.Text != "")
            {
                string qry = "INSERT INTO `guests` (fio, phone, passport)" + " VALUES (@fio, @phone, @passport);";
                MySqlCommand command = new MySqlCommand(qry, conn);// Обращение к БД
                command.Parameters.AddWithValue("@fio", cueTextBox1.Text);
                command.Parameters.AddWithValue("@phone", cueTextBox2.Text);
                command.Parameters.AddWithValue("@passport", cueTextBox3.Text);
                command.ExecuteNonQuery(); // Отправка запроса
                conn.Close();
                GC.Collect();
                MessageBox.Show(cueTextBox1.Text + " добавлен", "Закрыть");
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
