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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            RoomInfo.ID = Int32.Parse(row.Cells[0].Value.ToString());
            RoomInfo.Title = row.Cells[1].Value.ToString();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (PersonalInfo.isAuth != true)
            {
                this.Hide();
                Form Auth = new Auth();
                Auth.ShowDialog();
            }
            else
            {
                SelectNodeByName(treeView1, "Постояльцы");
            }
        }

        private void toolStripBtnAdd_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes[0].IsSelected == true)
            {
                Form AddUser = new Form2();
                AddUser.ShowDialog();
            }
            else if (treeView1.Nodes[1].IsSelected == true)
            {
                Form AddRoom = new Form3();
                AddRoom.ShowDialog();
            }
            else if (treeView1.Nodes[2].IsSelected == true)
            {
                Form AddPersonal = new Form4();
                AddPersonal.ShowDialog();
            }
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
                        dataGridView1.DataSource = UpdateGrid(dataReader);
                        dataGridView1.Columns[1].HeaderText = "ФИО";
                        dataGridView1.Columns[2].HeaderText = "Моб.телефон";
                        dataGridView1.Columns[3].HeaderText = "Паспорт";
                    }
                    dataReader.Close();
                    conn.Close();
                    GC.Collect();
                    dataGridView1.ContextMenuStrip = null;
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
                        dataGridView1.DataSource = UpdateGrid(dataReader);
                        dataGridView1.Columns[0].HeaderText = "№";
                        dataGridView1.Columns[1].HeaderText = "Название";
                        dataGridView1.Columns[2].HeaderText = "Тип";
                        dataGridView1.Columns[3].HeaderText = "Май";
                        dataGridView1.Columns[4].HeaderText = "Июнь";
                        dataGridView1.Columns[5].HeaderText = "Июль-Август";
                        dataGridView1.Columns[6].HeaderText = "Сентябрь";
                        dataGridView1.Columns[7].HeaderText = "Мебель";
                        dataGridView1.Columns[8].HeaderText = "Кол-во кроватей";
                    }
                    dataReader.Close();
                    conn.Close();
                    GC.Collect();
                    dataGridView1.ContextMenuStrip = contextMenuAddGuetToRoom;
                    break;
                }
                case 2:
                {
                    conn.Open();
                    MySqlDataReader dataReader;
                    string query = "SELECT * FROM `personal`";
                    MySqlCommand cmd = new MySqlCommand(query, conn);// Обращение к БД
                    dataReader = cmd.ExecuteReader(); // Отправка запроса
                    if (dataReader.HasRows)
                    {
                        dataGridView1.DataSource = UpdateGrid(dataReader);
                        dataGridView1.Columns[1].HeaderText = "ФИО";
                        dataGridView1.Columns[2].HeaderText = "Должность";
                        dataGridView1.Columns[3].HeaderText = "Мобильный телефон";
                    }
                    dataReader.Close();
                    conn.Close();
                    GC.Collect();
                    dataGridView1.ContextMenuStrip = null;
                    break;
                }
            }
        }
        private DataTable UpdateGrid(MySqlDataReader dataReader)
        {
            DataTable table = new DataTable();
            table.Load(dataReader);
            return table;
        }

        private void добавитьГостяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AddGuestToRoom = new Form5();
            AddGuestToRoom.Text = "Добавить гостя в" + RoomInfo.Title;
            AddGuestToRoom.ShowDialog();

        }
    }
    class RoomInfo
    {
        static public int ID { get; set; }
        static public string Title { get; set; }
    }
    class GuestInfo
    {
        static public int ID { get; set; }
        static public int roomID { get; set; }
        static public string Name { get; set; }
    }

    class PersonalInfo
    {
        static public bool isAuth { get; set; }
        static public bool isAdmin { get; set; }
        static public int ID { get; set; }
        static public string Name { get; set; }
    }

}
