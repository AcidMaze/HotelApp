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
    public partial class Form3 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        private bool connOpen = false;
        public Form3()
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBtnAccept_Click(object sender, EventArgs e)
        {
            if (cueTextBox1.Text != "" & cueTextBox2.Text != "" & cueTextBox3.Text != "")
            {
                string qry = "INSERT INTO `rooms` (title, type, furniture, bed)" + " VALUES (@title,@type,@furniture,@bed);";
                MySqlCommand command = new MySqlCommand(qry, conn);// Обращение к БД
                command.Parameters.AddWithValue("@title", cueTextBox1.Text);
                command.Parameters.AddWithValue("@type", cueTextBox2.Text);
                command.Parameters.AddWithValue("@furniture", richTextBox1.Text);
                command.Parameters.AddWithValue("@bed", cueTextBox3.Text);
                command.ExecuteNonQuery(); // Отправка запроса
                GC.Collect();
                MessageBox.Show(cueTextBox1.Text + " добавлен", "Закрыть");
                this.Close();
            }
            else
            {
                MessageBox.Show("Основные поля должны быть заполнены.", "Закрыть");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
