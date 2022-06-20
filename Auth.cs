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
    public partial class Auth : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlDataReader dataReader;
            string cmdText = "SELECT * FROM `personal` WHERE login = '" + cueTextBox1.Text + "' AND password = '" + cueTextBox2.Text + "' LIMIT 1";
            MySqlCommand cmdAuth = new MySqlCommand(cmdText, conn);
            dataReader = cmdAuth.ExecuteReader(); // Отправка запроса
            if (dataReader.HasRows)
            {
                dataReader.Read();
                PersonalInfo.ID = dataReader.GetInt32(0);
                PersonalInfo.Name = dataReader.GetString(1);
                PersonalInfo.isAuth = true; // Пользователь авторизован
                PersonalInfo.isAdmin = dataReader.GetBoolean(6); // Пользователь авторизован
                dataReader.Close();
                this.Close();
                conn.Close();
                Form main = new Form1();
                main.Show();
            }
            else
            {
                MessageBox.Show("Вы ввели неверный логин или пароль!");
                conn.Close();
                dataReader.Close();
            }
        }

    }
}
