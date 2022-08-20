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
        private bool connOpen = false;
        public Form4()
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
            if (cueTextBox1.Text != "" & cueTextBox2.Text != "" & cueTextBox3.Text != "")
            {
                string qry = "INSERT INTO `personal` (name, phone, dolznost, login, password)" + " VALUES (@name, @phone, @dolznost, @login, @password);";
                MySqlCommand command = new MySqlCommand(qry, conn);// Обращение к БД
                command.Parameters.AddWithValue("@name", cueTextBox1.Text);
                command.Parameters.AddWithValue("@phone", cueTextBox2.Text);
                command.Parameters.AddWithValue("@dolznost", cueTextBox3.Text);
                command.Parameters.AddWithValue("@login", cueTextBox4.Text);
                command.Parameters.AddWithValue("@password", cueTextBox5.Text);
                command.ExecuteNonQuery(); // Отправка запроса
                MessageBox.Show(cueTextBox1.Text + " добавлен как сотрудник", "Закрыть");
                GC.Collect();
                this.Close();
            }
            else
            {
                MessageBox.Show("Основные поля должны быть заполнены.", "Закрыть");
            }
        }
    }
}
