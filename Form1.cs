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
    public partial class Form1 : Form
    {
        private MySqlConnection conn = DBUtils.GetDBConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            SelectNodeByName(treeView1, "Постояльцы");
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            Form AddUser = new Form2();
            AddUser.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void SelectNodeByName(TreeView treeView, string nameNode)
        {
            foreach (TreeNode item in treeView.Nodes)
            {
                if (item.Text == nameNode)
                {
                    treeView.SelectedNode = item;
                }
            }

        }

        private void toolStripBtnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (Convert.ToInt32(e.Node.Index))
            {
                case 0:
                {
                    conn.Open();
                    MySqlDataReader dataReader;
                    string query = "SELECT * FROM `guests`";
                    MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
                    dataReader = cmd.ExecuteReader(); // Отправка запроса
                    if (dataReader.HasRows)
                    {
                        DataTable table = new DataTable();
                        table.Load(dataReader);
                        dataGridView1.DataSource = table;
                        dataGridView1.Columns[1].HeaderText = "ФИО";
                        dataGridView1.Columns[2].HeaderText = "Моб.телефон";
                        dataGridView1.Columns[3].HeaderText = "Паспорт";
                    }
                    dataReader.Close();
                    conn.Close();
                    GC.Collect();
                    break;
                }
                case 1:
                {
                    conn.Open();
                    MySqlDataReader dataReader;
                    string query = "SELECT * FROM `rooms`";
                    MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
                    dataReader = cmd.ExecuteReader(); // Отправка запроса
                    if (dataReader.HasRows)
                    {
                        DataTable table = new DataTable();
                        table.Load(dataReader);
                        dataGridView1.DataSource = table;
                        dataGridView1.Columns[1].HeaderText = "Название";
                        dataGridView1.Columns[2].HeaderText = "Тип";
                        dataGridView1.Columns[3].HeaderText = "Май";
                        dataGridView1.Columns[4].HeaderText = "Июнь";
                        dataGridView1.Columns[5].HeaderText = "Июль-Август";
                        dataGridView1.Columns[6].HeaderText = "Сентябрь";
                    }
                    dataReader.Close();
                    conn.Close();
                    GC.Collect();
                    break;
                }
            }
        }

 
    }
}
